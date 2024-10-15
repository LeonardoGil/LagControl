function Set-ConfirmarMovimentacaoPendente {

    [CmdletBinding()]
    param (

    )

    $movimentacoes = Invoke-RestMethod -Method 'Get' -Uri 'https://localhost:7081/Movimentacao/Listar?ApenasPendentes=true'

    $movimentacao = Show-ConfirmarMovimentacaoPendenteOptions $movimentacoes

    $body = [PSCustomObject]@{
        Id = $movimentacao.Id
    } 

    Invoke-RestMethod -Method 'Post' -Uri 'https://localhost:7081/Movimentacao/Confirmar-Pendente' -Body ($body | ConvertTo-Json) -ContentType "application/json; charset=utf-8" -Headers @{ "Accept" = "application/json" }
}

function Show-ConfirmarMovimentacaoPendenteOptions {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [PSCustomObject]
        $movimentacoes
    )

    $choices = $movimentacoes | ForEach-Object { 

        $value = "&$([Array]::IndexOf($movimentacoes, $_)) $(Get-Date $_.Data -Format 'dd/MM') $($_.ValorTotal) $($_.descricao)"

        return [ChoiceDescription]::new($value , $_.descricao) 
    }

    $movimentacao = $host.UI.PromptForChoice("Escolha uma movimentação", "", $choices, 0)

    return $movimentacoes[$movimentacao]
}