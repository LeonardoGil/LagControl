using namespace System.IO
using namespace System

$scriptsPath = [Path]::Combine($PSScriptRoot, '*')

Get-ChildItem -Path $scriptsPath -Filter '*.ps1' -Recurse | 
    Select-Object -ExpandProperty FullName | 
        ForEach-Object { Import-Module -Name $_ }

$functionsToExport = @(
    'Show-Extrato',
    'Show-DespesasPorCategoria',
    
    'New-Movimentacao',
    'New-Categoria',
    
    'Set-ConfirmarMovimentacaoPendente',
    'Remove-Movimentacao'
)

$variablesToExport = @()
$aliasToExport = @()

Export-ModuleMember -Function $functionsToExport -Variable $variablesToExport -Alias $aliasToExport