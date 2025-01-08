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

    $tipo = [int](-not $receita.IsPresent)

    if ($null -eq $contaId -or $contaId -eq [Guid]::Empty) {

        $contaId = (Select-Conta).Id
    }

    if ($null -eq $categoriaId -or $categoriaId -eq [Guid]::Empty) {

        $categoriaId = (Select-Categoria -tipo $tipo).Id
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