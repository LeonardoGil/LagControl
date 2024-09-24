using namespace System.Management.Automation.Host

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
        [Guid]
        $contaId,

        [Parameter()]
        [Guid]
        $categoriaId
    )

    if ($null -eq $categoriaId -or $categoriaId -eq [Guid]::Empty) {

        $categorias = Invoke-RestMethod -Uri 'https://localhost:7081/Categoria/Listar' -Method 'Get'
        
        $choices = $categorias | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($categorias, $_)) $($_.descricao)" , $_.descricao ) }

        $categoriaIndex = $host.UI.PromptForChoice("Informe a Categoria", "", $choices, 0)

        $categoriaId = $categorias[$categoriaIndex].Id
    }

    $body = [PSCustomObject]@{
        Descricao = $descricao
        Observacao = $observacao
        Valor = $valor
        Data = $data.ToString("o")
        ContaId = $contaId
        CategoriaId = $categoriaId
    } | ConvertTo-Json

    Invoke-RestMethod -Uri 'https://localhost:7081/Movimentacao/Adicionar' `
                      -Method 'Post' `
                      -Body $body `
                      -ContentType "application/json" `
                      -Headers @{ "Accept" = "application/json" }
}