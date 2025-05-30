function Show-Extrato {
    
    [CmdletBinding()]
    param (
        [Parameter()]
        [Guid]
        $contaId,

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

    $url = Get-ExtratoUrl -dataInicio $dataInicio -dataFim $dataFim -contaId $contaId

    $extrato = Invoke-RestMethod -Uri $url -Method 'Get'    
    
    Write-Host "Extrato do Banco $($extrato.Conta.ToUpper()). Periodo: $($extrato.DataInicio) a $($extrato.DataFim)" 
    Write-Host ""

    foreach ($extratoDia in $extrato.ExtratosDia)
    {
        $mes = ($extratoDia.Dia -split '-')[1]
        $dia = ($extratoDia.Dia -split '-')[2]

        Write-Host " === Dia $dia/$mes === "  -ForegroundColor DarkYellow
        Write-Host "Valor Inicial: $($extratoDia.ValorInicialDia)"

        $extratoDia.Movimentacoes | ForEach-Object { Show-ExtratoMovimentacao $_ }

        Write-Host "Valor Final: $($extratoDia.ValorFinalDia)"
        Write-Host ""
    }

    if ($null -ne $extrato.ExtratoPendente) {
        Write-Host ''
        Write-Host ' === Pendencias === ' -ForegroundColor DarkYellow

        $extrato.ExtratoPendente.Movimentacoes | Sort-Object -Property Data | ForEach-Object { Show-ExtratoMovimentacaoPendente $_ }

        Write-Host ''
        Write-Host 'Valor Total Receita: ' -NoNewline
        Write-Host "$($extrato.ExtratoPendente.ValorTotalReceita)" -ForegroundColor Green

        Write-Host 'Valor Total Despesa: ' -NoNewline
        Write-Host "$($extrato.ExtratoPendente.ValorTotalDespesa)" -ForegroundColor Red

        Write-Host "Saldo Previsto: $($extrato.ExtratoPendente.SaldoPrevisto)"
    }

}

function Show-ExtratoMovimentacao {
    
    [CmdletBinding()]
    param (
        [Parameter(Position=0)]
        [PSCustomObject]
        $mov
    )    

    $sinal = '+'
    $color = 'Green'

    if ($mov.tipo -eq 1) { 
        $sinal = '-' 
        $color = 'Red'
    }

    Write-Host "$sinal $($mov.Valor)" -ForegroundColor $color  -NoNewline
    Write-Host " - $($mov.Descricao) | Conta: $($mov.Conta) | Categoria: $($mov.Categoria)" -NoNewline
    Write-Host ""

}

function Show-ExtratoMovimentacaoPendente {
    
    [CmdletBinding()]
    param (
        [Parameter(Position=0)]
        [PSCustomObject]
        $mov
    )    

    $date = (Get-Date -Date $mov.Data).Date

    if ($date -lt (Get-Date).Date) {
        Write-Host "$(Get-Date $mov.Data -Format 'dd/MM') " -ForegroundColor DarkRed -NoNewline
    }
    elseif ($date -eq (Get-Date).Date -or $date -eq (Get-Date).AddDays(1).Date) {
        Write-Host "$(Get-Date $mov.Data -Format 'dd/MM') " -ForegroundColor DarkYellow -NoNewline
    }
    else {
        Write-Host "$(Get-Date $mov.Data -Format 'dd/MM') " -NoNewline
    }

    $sinal = '+'
    $sinalColor = 'Green'

    if ($mov.tipo -eq 1) { 
        $sinal = '-' 
        $sinalColor = 'Red'
    }

    Write-Host "$sinal$($mov.Valor)" -ForegroundColor $sinalColor -NoNewline
    Write-Host " - $($mov.Descricao) " -NoNewline

    Write-Host "| Conta: $($mov.Conta) | Categoria: $($mov.Categoria)" -NoNewline
    Write-Host ""

}

function Get-ExtratoUrl {
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
    
    $baseUri = "https://localhost:7081/Relatorio/Extrato"
    $queryParams = "?contaId=$contaId&dataInicio=$dataInicioFormatada&dataFim=$dataFimFormatada"
 
    $url = $baseUri + $queryParams
    Write-Verbose "Url: $url"

    return $url
}