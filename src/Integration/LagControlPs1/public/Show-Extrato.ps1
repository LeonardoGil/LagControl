function Show-Extrato {
    
    [CmdletBinding()]
    param (
        [Parameter()]
        [Guid]
        $contaId
    )
    
    $ErrorActionPreference = 'Break'

    if ($null -eq $contaId -or 
        $contaId -eq [Guid]::Empty) {

        $contas = Invoke-RestMethod -Uri 'https://localhost:7081/Conta/Listar' -Method 'Get'
        $choices = $contas | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($contas, $_)) $($_.Descricao)" , $_.Descricao ) }
        $contaIndex = $host.UI.PromptForChoice("Informe a Conta", "", $choices, 0)
        $contaId = $contas[$contaIndex].Id
    }

    $extrato = Invoke-RestMethod -Uri "https://localhost:7081/conta/extrato/$contaId" -Method 'Get'

    Write-Host "Extrato do Banco $($extrato.Conta.ToUpper()). Periodo: $($extrato.DataInicio) a $($extrato.DataFim)" 
    Write-Host ""

    foreach ($extratoDia in $extrato.ExtratosDia)
    {
        $mes = ($extratoDia.Dia -split '-')[1]
        $dia = ($extratoDia.Dia -split '-')[2]

        Write-Host " === Dia $dia/$mes === "  -ForegroundColor DarkYellow
        Write-Host "Valor Inicial: $($extratoDia.ValorInicialDia)"

        foreach ($mov in $extratoDia.Movimentacoes) {
            Show-ExtratoMovimentacao $mov
            Write-Host ""
        }

        Write-Host "Valor Final: $($extratoDia.ValorFinalDia)"
        Write-Host ""
    }

    if ($null -ne $extrato.ExtratoPendente) {
        Write-Host ""
        Write-Host " === Pendencias === " -ForegroundColor DarkYellow

        foreach ($mov in $extrato.ExtratoPendente.Movimentacoes) {
            Show-ExtratoMovimentacao $mov -showData
            Write-Host ""
        }

        Write-Host "Valor Total: $($extrato.ExtratoPendente.ValorTotal)"
        Write-Host "Valor Final: $($extrato.ExtratoPendente.ValorFinal)"
    }

}

function Show-ExtratoMovimentacao {
    
    [CmdletBinding()]
    param (
        [Parameter(Position=0)]
        [PSCustomObject]
        $mov,

        [Parameter()]
        [switch]
        $showData
    )    

    $sinal = '+'
    $color = 'Green'

    if ($mov.tipoMovimentacao -eq 1) { 
        $sinal = '-' 
        $color = 'Red'
    }

    Write-Host "$sinal $($mov.Valor)" -ForegroundColor $color  -NoNewline

    if ($showData) {
        Write-Host " - $($mov.Descricao) | Data: $(Get-Date $mov.Data -Format 'dd/MM') | Conta: $($mov.Conta) | Categoria: $($mov.Categoria)" -NoNewline
    }
    else {
        Write-Host " - $($mov.Descricao) | Conta: $($mov.Conta) | Categoria: $($mov.Categoria)" -NoNewline
    }
}