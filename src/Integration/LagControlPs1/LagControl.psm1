using namespace System.IO
using namespace System

$scriptsPath = [Path]::Combine($PSScriptRoot, '*')

Get-ChildItem -Path $scriptsPath -Filter '*.ps1' -Recurse | 
    Select-Object -ExpandProperty FullName | 
        ForEach-Object { Import-Module -Name $_ }

$functionsToExport = @(
    "New-Movimentacao"
)

$variablesToExport = @()
$aliasToExport = @()

Export-ModuleMember -Function $functionsToExport -Variable $variablesToExport -Alias $aliasToExport