function Set-ConfirmarMovimentacaoPendente {

    [CmdletBinding()]
    param (
        [Parameter()]
        [string]
        $Descricao,

        [Parameter()]
        [string]
        $Observacao,

        [Parameter()]
        [decimal]
        $Valor,

        [Parameter()]
        [datetime]
        $Data
    )

    $movimentacoes = Invoke-RestMethod -Method 'Get' -Uri 'https://localhost:7081/Movimentacao/Listar?ApenasPendentes=true'

    Write-Output $movimentacoes.GetType()

    $movimentacao = Show-ConfirmarMovimentacaoPendenteOptions $movimentacoes 

    $body = New-ConfirmarMovimentacaoPendenteObject $movimentacao

    Invoke-RestMethod -Method 'Post' -Uri 'https://localhost:7081/Movimentacao/Confirmar-Pendente' -Body ($body | ConvertTo-Json) -ContentType "application/json; charset=utf-8" -Headers @{ "Accept" = "application/json" }
}

function New-ConfirmarMovimentacaoPendenteObject {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory, ValueFromPipeline)]
        [PSCustomObject]
        $movimentacao
    )

    $body = [PSCustomObject]@{
        Id = $movimentacao.Id
    }
    
    return $body
}


function Show-ConfirmarMovimentacaoPendenteOptions {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [PSCustomObject[]]
        $movimentacoes
    )

    $choices = $movimentacoes | ForEach-Object { 
        $message = "&$([Array]::IndexOf($movimentacoes, $_)) $($_.descricao)"
        $helpMessage = "$(Get-Date $_.Data -Format 'dd/MM/yyyy') R$ $($_.Valor) $($_.descricao)"
        return [ChoiceDescription]::new($message , $helpMessage) 
    }

    $movimentacao = $host.UI.PromptForChoice("Escolha uma movimentação", "", $choices, 0)

    return $movimentacoes[$movimentacao]
}