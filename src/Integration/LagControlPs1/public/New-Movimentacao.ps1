function New-Movimentacao {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory)]
        [decimal]
        $valor,

        [Parameter(Mandatory)]
        [string]
        $descricao,

        [Parameter()]
        [string]
        $observacao,

        [Parameter()]
        [datetime]
        $data = (Get-Date),

        [Parameter(Mandatory)]
        [guid]
        $ContaId,

        [Parameter(Mandatory)]
        [guid]
        $CategoriaId
    )

    $body = [PSCustomObject]@{
        Descricao = $descricao
        Observacao = $observacao
        Valor = $valor
        Data = $data.ToString("o")
        ContaId = $ContaId
        CategoriaId = $CategoriaId
    } | ConvertTo-Json

    Write-Output $body

    Invoke-RestMethod -Uri 'https://localhost:7081/Movimentacao/Adicionar' `
                      -Method 'Post' `
                      -Body $body `
                      -ContentType "application/json" `
                      -Headers @{ "Accept" = "application/json" }
}