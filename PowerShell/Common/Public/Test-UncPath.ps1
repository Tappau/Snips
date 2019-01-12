function Test-UncPath {
    param (
        [Parameter(Mandatory=$true)]
        $Path
    )
    if($Path.StartsWith("\\")){ return $true } else { return $false }    
}