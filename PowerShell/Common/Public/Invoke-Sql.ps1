<#
.SYNOPSIS
    Execute provided SQL against provided Server Instance accepts parameters 
.DESCRIPTION
    Will execute SQL against instance, If UserName and password are not provided then will use integrated security
    if TargetDatabase not provided then query should contain fully qualified paths for query.
.PARAMETER ServerInstance
    Name of instance to execute against
.PARAMETER Query
    String Query to run
.PARAMETER Parameters
    Dictionary of parameter names and values.
.PARAMETER TargetDatabase
    If Provided will define Target Database parameter on connection string
.PARAMETER UserName
    User to execute as
.PARAMETER Password
    SecureString password to utilise
.PARAMETER NonQuery
    States that this query does not return results i.e. Action Queries (CREATE, ALTER, DROP, INSERT, UPDATE, DELETE)
.EXAMPLE
    Invoke-Sql -ServerInstance localhost\sqlexpress -Query "SELECT * FROM Person"
    Will execute and return object of results
.EXAMPLE 
    Invoke-Sql -ServerInstance localhost\sqlexpress -Query "SELECT FirstName, LastName FROM Person WHERE FirstName=@fname" -Parameters @{fname = 'John'}
    Will execute the query and return object of the results
.EXAMPLE
    Invoke-Sql -ServerInstance localhost\sqlexpress -Query "INSERT INTO Person(FirstName, LastName) VALUES('Jane', 'Doe')" -NonQuery
    Will execute returning if number of rows affected.
.NOTES
    Only executable against Microsoft SQL Server instances.
#>
function Invoke-Sql {
    [CmdletBinding()]
    param (
        [parameter(Mandatory = $true)]
        [String] $ServerInstance,

        [parameter(Mandatory = $true)]
        [string] $Query,

        [parameter(Mandatory = $false)]
        [hashtable]$Parameters,

        [parameter(Mandatory = $false)]
        [string] $TargetDatabase,

        [parameter(HelpMessage = "UserName to use")]
        [string]$UserName, 

        [parameter(Mandatory = $false)]
        [securestring]$Password,

        [parameter(Mandatory = $false)]
        [switch] $NonQuery
    )
    
    begin {
        $connectionString = "Data Source=$ServerInstance;"
        if ($TargetDatabase) {
            $connectionString += "Initial Catalog=$TargetDatabase;"
        }
        
        $conn = New-Object system.data.SqlClient.sqlconnection
        if ($UserName -and $Password) {
            Write-Verbose "Using specified credentials"
            $creds = New-Object System.Data.SqlClient.SqlCredential($UserName, $Password)
        }
        else {
            $connectionString += "Integrated Security = True;"
        }

        $conn.ConnectionString = $connectionString
        if ($null -ne $creds) {
            $conn.Credential = $creds
        }
    }
    
    process {        
        try {
            if ($NonQuery) {
                #Execute as NonQuery            
                Write-verbose "Creating SQL Command..."
                $cmd = New-Object system.data.SqlClient.SqlCommand($Query, $conn)
                Write-Output "Opening SQL Connection..."
                $conn.Open()            
                Write-output "Executing SQL Command..."
                $result = $cmd.ExecuteNonQuery()
                if($result -gt 0){
                    Write-Output "Successfully Executed Command"
                    return $result
                }else{
                    Write-Error
                }
            }
            else {
                #then execute as required returning object of results
                $cmd = New-Object system.data.SqlClient.SqlCommand($Query, $conn)
                if ($Parameters.Count -gt 0) {
                    $cmd.Parameters.Clear()
                    foreach ($p in $Parameters.Keys) {
                        [void] $cmd.Parameters.AddWithValue("@$p", $Parameters[$p])
                    }
                }
                Write-Output "Opening SQL Connection..."    
                $conn.Open()
                $reader = $cmd.ExecuteReader()
                $results = @()
                while ($reader.Read()) {
                    $row = @{}
                    for ($i = 0; $i -lt $reader.FieldCount; $i++) {
                        Write-Verbose "Adding $($reader.GetName($i)) to psobject"
                        $row[$reader.GetName($i)] = $reader.GetValue($i)
                    }
                    $results += New-Object psobject -Property $row
                }
                $conn.Close()
                return $results
            }               
        }
        catch [system.data.SqlClient.sqlexception] {
            Write-Error "One or more of the rows being affected were locked. Please check your query and data then try again."
        }
        catch {
            Write-Error "An error occurred while attempting to open the database connection and execute a command"
        }
        finally {
            if ($conn.State -eq 'Open') {
                Write-Output "Closing connection..."
                $conn.Close()
            }
        }
    }
    
    end {
        $conn.Dispose()
    }
}