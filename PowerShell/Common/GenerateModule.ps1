$Path = "C:\Users\Calvin\Source\Repos\Snips\PowerShell"
$ModuleName = "Common"
$Author = "Tappau"
$Description = "Powershell module of helpful tasks, I've required at somepoint"

#Create the module and related files
New-ModuleManifest -Path $Path\$ModuleName\$ModuleName.psd1 `
    -RootModule $Path\$ModuleName\$ModuleName.psm1 `
    -Description $Description `
    -powershellVersion 3.0 `
    -Author $Author
                