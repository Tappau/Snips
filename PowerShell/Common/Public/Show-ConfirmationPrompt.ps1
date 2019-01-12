function Show-ConfirmationPrompt {
    param (
        [string]$Message
    )
    do {
        $reply = Read-Host -Prompt ($Message + " (Y/N) ?")
    } until ("y","Y","n","N" -contains $reply)
    return ("y", "Y" -contains $reply)
}