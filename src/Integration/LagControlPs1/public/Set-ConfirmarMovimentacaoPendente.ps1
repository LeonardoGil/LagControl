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
        [Nullable[decimal]]
        $Valor,

        [Parameter()]
        [Nullable[datetime]]
        $Data
    )

    $movimentacoes = Invoke-RestMethod -Method 'Get' -Uri 'https://localhost:7081/Movimentacao/Listar?ApenasPendentes=true'

    $movimentacao = Show-ConfirmarMovimentacaoPendenteOptions $movimentacoes 

    if ($null -eq $movimentacao) {
        Write-Host 'Movimentação inválida' -ForegroundColor DarkYellow
        return
    }

    $body = [PSCustomObject]@{
        Id = $movimentacao.Id
    }

    if ($null -ne $Valor) {
        $body | Add-Member -MemberType NoteProperty -Name "Valor" -Value $Valor
    }

    if ($null -ne $Data) {
        $body | Add-Member -MemberType NoteProperty -Name "Data" -Value $Data.ToString("o")
    }

    Invoke-RestMethod -Method 'Post' -Uri 'https://localhost:7081/Movimentacao/Confirmar-Pendente' -Body ($body | ConvertTo-Json) -ContentType "application/json; charset=utf-8" -Headers @{ "Accept" = "application/json" }
}

function Show-ConfirmarMovimentacaoPendenteOptions {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [PSCustomObject[]]
        $movimentacoes
    )

    foreach ($movimentacao in $movimentacoes) {
        
        $index = [Array]::IndexOf($movimentacoes, $movimentacao)
        
        $data = Get-Date $movimentacao.Data -Format 'dd/MM/yyyy'

        Write-Host "$index - $data R$ $($movimentacao.Valor) $($movimentacao.descricao)"
    }

    Write-Host

    $movimentacaoIndex = Read-Host 'Selecione uma movimentação:'

    if ($movimentacaoIndex -as [int] -and 
        $movimentacaoIndex -ge 0 -and 
        $movimentacaoIndex -lt $movimentacoes.Count) { return $movimentacoes[$movimentacaoIndex] }

    return $null
}