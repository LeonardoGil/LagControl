function New-Categoria {
    [CmdletBinding()]    
    param (
        [Parameter(Mandatory, Position=0)]
        [string]
        $descricao,

        [Parameter()]
        [switch]
        $despesa,

        [Parameter()]
        [switch]
        $categoriaFilha
    )

    $tipo = [int]$despesa.IsPresent

    $categoria = [PSCustomObject]@{ 
        Descricao = $descricao 
        Tipo = $tipo
        categoriaPaiId = $null
    } 

    if ($categoriaFilha.IsPresent) { $categoria.categoriaPaiId = (Select-Categoria -tipo $tipo).Id }

    $body = $categoria | ConvertTo-Json

    Invoke-RestMethod -Uri 'https://localhost:7081/Categoria/Adicionar' `
                      -Method 'Post' `
                      -Body $body `
                      -ContentType "application/json" `
                      -Headers @{ "Accept" = "application/json" }

    Write-Host "Categoria $descricao adicionado!" -ForegroundColor DarkGreen
}