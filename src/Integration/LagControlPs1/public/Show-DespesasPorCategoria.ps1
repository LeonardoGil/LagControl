function Show-DespesasPorCategoria() {

    [CmdletBinding()]
    param (
        [Parameter()]
        [Guid]
        $ContaId,

        [Alias('i')]
        [Parameter()]
        [switch]
        $interactive
    )
    
    $ErrorActionPreference = 'Stop'

    if ($null -eq $contaId -or $contaId -eq [Guid]::Empty) {

        $contas = Invoke-RestMethod -Uri 'https://localhost:7081/Conta/Listar' -Method 'Get'
        $choices = $contas | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($contas, $_)) $($_.Descricao)" , $_.Descricao ) }
        $contaIndex = $host.UI.PromptForChoice("Informe a Conta", "", $choices, 0)
        $contaId = $contas[$contaIndex].Id
    }

    $relatorio = Invoke-RestMethod -Uri "https://localhost:7081/conta/Despesas-por-Categoria/$contaId" -Method 'Get'

    Write-Host "Conta: $($relatorio.Conta)"

    foreach ($despesasPorCategoria in $relatorio.DespesasPorCategoriaGroup | Sort-Object ValorTotal -Descending) {
        Write-Host "Categoria: $($despesasPorCategoria.Categoria)"
        Write-Host "Valor Total: $($despesasPorCategoria.ValorTotal)"
        # Show-Movimentacoes $despesasPorCategoria.Movimentacoes
        Write-Host ""
    }
}

function Show-Movimentacoes() {
    # [CmdletBinding()]
    # param (
    #     [Parameter(Mandatory)]
    #     [PSCustomObject[]]
    #     $Movimentacoes
    # )

    # foreach ($mov in $Movimentacoes) {
    #       TODO
    # }
}