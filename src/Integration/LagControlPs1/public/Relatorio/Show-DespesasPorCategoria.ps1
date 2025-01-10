function Show-DespesasPorCategoria() {

    [CmdletBinding()]
    param (
        [Parameter()]
        [Guid]
        $ContaId,
        
        [Parameter()]
        [Nullable[DateTime]]
        $dataInicio,

        [Parameter()]
        [Nullable[DateTime]]
        $dataFim
    )
    
    $ErrorActionPreference = 'Stop'

    if ($null -eq $contaId -or 
        $contaId -eq [Guid]::Empty) {

        $contaId = (Select-Conta).Id
    }

    $dataInicio = Get-DatePrimeiroDiaSeForNull $dataInicio
    $dataFim = Get-DateUltimoDiaSeForNull $dataFim

    if ($dataInicio -gt $dataFim) {
        Write-Host 'DataInicio não pode ser maior de DataFim' -ForegroundColor DarkYellow
        return
    }

    $url = Get-DespesasPorCategoriaUrl -contaId $contaid -dataInicio $dataInicio -dataFim $dataFim

    Write-Verbose $url

    $relatorio = Invoke-RestMethod -Uri $url -Method 'Get'

    Write-Host "Conta: $($relatorio.Conta)"

    foreach ($despesaPorCategoria in $relatorio.DespesasPorCategoriaGroup | Sort-Object ValorTotal -Descending) {
        Write-Host "Categoria: $($despesaPorCategoria.Categoria)"
        Write-Host "Valor Total: $($despesaPorCategoria.ValorTotal)"
        
        $despesaPorCategoria.Movimentacoes | Sort-Object Data -Descending  | ForEach-Object { Show-DespesasPorCategoriaMovimentacoes -mov $_ }
        
        Write-Host ""
    }
}

function Show-DespesasPorCategoriaMovimentacoes() {
    [CmdletBinding()]
    param (
        [Parameter(Position=0)]
        [PSCustomObject]
        $mov
    )    

    $data = (Get-Date -Date $mov.Data)

    $sinal = '+'
    $color = 'Green'

    if ($mov.tipoMovimentacao -eq 1) { 
        $sinal = '-' 
        $color = 'Red'
    }

    Write-Host $data.ToString('dd/MM') -NoNewline
    Write-Host " $sinal $($mov.Valor)" -ForegroundColor $color  -NoNewline
    Write-Host " - $($mov.Descricao) | Conta: $($mov.Conta)" -NoNewline
    Write-Host ""
}

function Get-DespesasPorCategoriaUrl {
    [CmdletBinding()]
    param (
        [Parameter()]
        [Guid]
        $contaId,

        [Parameter()]
        [DateTime]
        $dataInicio,

        [Parameter()]
        [DateTime]
        $dataFim
    )


    $dataFormat = 'yyyy-MM-dd'

    $dataInicioFormatada = $dataInicio.ToString($dataFormat)
    $dataFimFormatada = $dataFim.ToString($dataFormat)
    
    $baseUri = "https://localhost:7081/Relatorio/Despesas-por-Categoria"
    $queryParams = "?contaId=$contaId&dataInicio=$dataInicioFormatada&dataFim=$dataFimFormatada"
 
    $url = $baseUri + $queryParams
    Write-Verbose "Url: $url"

    return $url
}