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

        $extratoDia.Movimentacoes | ForEach-Object { Show-ExtratoMovimentacao $_ }

        Write-Host "Valor Final: $($extratoDia.ValorFinalDia)"
        Write-Host ""
    }

    if ($null -ne $extrato.ExtratoPendente) {
        Write-Host ""
        Write-Host " === Pendencias === " -ForegroundColor DarkYellow

        $extrato.ExtratoPendente.Movimentacoes | Sort-Object -Property Data | ForEach-Object { Show-ExtratoMovimentacaoPendente $_ }

        Write-Host "Valor Total: $($extrato.ExtratoPendente.ValorTotal)"
        Write-Host "Valor Final: $($extrato.ExtratoPendente.ValorFinal)"
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

    if ($mov.tipoMovimentacao -eq 1) { 
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

    if ($mov.tipoMovimentacao -eq 1) { 
        $sinal = '-' 
        $sinalColor = 'Red'
    }

    Write-Host "$sinal$($mov.Valor)" -ForegroundColor $sinalColor -NoNewline
    Write-Host " - $($mov.Descricao) " -NoNewline

    Write-Host "| Conta: $($mov.Conta) | Categoria: $($mov.Categoria)" -NoNewline
    Write-Host ""

}