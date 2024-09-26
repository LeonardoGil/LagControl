function New-Categoria {
    [CmdletBinding()]    
    param (
        [Parameter(Mandatory, Position=0)]
        [string]
        $descricao,

        [Parameter()]
        [switch]
        $despesa
    )

    $tipo = 0 # Receita
    if ($despesa) { $tipo = 1 } # Despesa 

    $body = [PSCustomObject]@{ 
        Descricao = $descricao 
        Tipo = $tipo
    } | ConvertTo-Json

    Invoke-RestMethod -Uri 'https://localhost:7081/Categoria/Adicionar' `
                      -Method 'Post' `
                      -Body $body `
                      -ContentType "application/json" `
                      -Headers @{ "Accept" = "application/json" }

    Write-Host "Categoria $descricao adicionado!" -ForegroundColor DarkGreen
}