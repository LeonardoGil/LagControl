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
        $choices = $contas | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($contas, $_)) $($_.descricao)" , $_.descricao ) }
        $contaIndex = $host.UI.PromptForChoice("Informe a Conta", "", $choices, 0)
        $contaId = $contas[$contaIndex].Id
    }

    $extrato = Invoke-RestMethod -Uri "https://localhost:7081/conta/extrato/$contaId" -Method 'Get'

    Write-Host "Extrato do Banco $($extrato.Conta.ToUpper()). Periodo: $($extrato.DataInicio) a $($extratoRequest.DataFim)" 
    Write-Host ""

    foreach ($extratoDia in $extrato.extratosDia)
    {
        $mes = ($extratoDia.Dia -split '-')[1]
        $dia = ($extratoDia.Dia -split '-')[2]

        Write-Host " === Dia $dia/$mes === "
        Write-Host "Valor Inicial: $($extratoDia.ValorInicialDia)"

        foreach ($mov in $extratoDia.movimentacoes) {
            
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

        Write-Host "Valor Final: $($extratoDia.ValorFinalDia)"
        Write-Host ""
    }
}