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

        [Parameter()]
        [Guid]
        $contaId,

        [Parameter()]
        [Guid]
        $categoriaId,

        [Parameter()]
        [switch]
        $receita,

        [Parameter()]
        [switch]
        $pendente
    )

    $ErrorActionPreference = 'Break'

    $tipo = 1 # Despesa
    if ($receita.IsPresent) {
        $tipo = 0 
    } # Receita 

    if ($null -eq $contaId -or $contaId -eq [Guid]::Empty) {

        $contas = Invoke-RestMethod -Uri 'https://localhost:7081/Conta/Listar' -Method 'Get'
        
        $choices = $contas | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($contas, $_)) $($_.descricao)" , $_.descricao ) }

        $contaIndex = $host.UI.PromptForChoice("Informe a Conta", "", $choices, 0)

        $contaId = $contas[$contaIndex].Id
    }

    if ($null -eq $categoriaId -or $categoriaId -eq [Guid]::Empty) {

        $categorias = Invoke-RestMethod -Uri "https://localhost:7081/Categoria/Listar?Tipo=$tipo" -Method 'Get'
            
        $choices = $categorias | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($categorias, $_)) $($_.descricao)" , $_.descricao ) }

        $categoriaIndex = $host.UI.PromptForChoice("Informe a Categoria", "", $choices, 0)

        $categoriaId = $categorias[$categoriaIndex].Id
    }

    $body = [PSCustomObject]@{
        Descricao   = $descricao
        Observacao  = $observacao
        Valor       = $valor
        Data        = $data.ToString("o")
        ContaId     = $contaId
        CategoriaId = $categoriaId
        Tipo        = $tipo
        Pendente    = $pendente.IsPresent
    }

    if (-not $pendente.IsPresent -and (Get-Date).Date -lt $data.Date) {

        $choices = [ChoiceDescription[]]@(
            [ChoiceDescription]::new("&Sim" , "Sim" )
            [ChoiceDescription]::new("&Nao" , "Nao" )
        ) 

        $body.Pendente = ($host.UI.PromptForChoice("Data Futura", "Deseja marcar como Pendente?", $choices, 0) -eq 0)
    }

    Write-Verbose $body

    Invoke-RestMethod -Uri 'https://localhost:7081/Movimentacao/Adicionar' `
                      -Method 'Post' `
                      -Body ($body | ConvertTo-Json) `
                      -ContentType "application/json; charset=utf-8" `
                      -Headers @{ "Accept" = "application/json" }
    

    Write-Host 'Movimentação adicionada' -ForegroundColor DarkGreen
}