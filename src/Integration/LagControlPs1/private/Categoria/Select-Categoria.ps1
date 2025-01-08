function Select-Categoria {
    
    [CmdletBinding()]
    param (
        [Parameter()]
        [int]
        $tipo = 0
    )
    
    $categorias = Invoke-RestMethod -Uri "https://localhost:7081/Categoria/Listar?Tipo=$tipo" -Method 'Get'
            
    $choices = $categorias | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($categorias, $_)) $($_.descricao)" , $_.descricao ) }

    $categoriaIndex = $host.UI.PromptForChoice("Informe a Categoria", "", $choices, 0)

    return $categorias[$categoriaIndex]
}