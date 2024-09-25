function New-Categoria {
    [CmdletBinding()]    
    param (
        [Parameter(Mandatory, Position=0)]
        [string]
        $descricao
    )

    $body = [PSCustomObject]@{ Descricao = $descricao } | ConvertTo-Json

    Invoke-RestMethod -Uri 'https://localhost:7081/Categoria/Adicionar' `
                      -Method 'Post' `
                      -Body $body `
                      -ContentType "application/json" `
                      -Headers @{ "Accept" = "application/json" }

    Write-Host "Categoria $descricao adicionado!" -ForegroundColor DarkGreen
}