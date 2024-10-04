function Remove-Movimentacao {
    [CmdletBinding()]
    param(
    
        [Parameter()]
        [Guid]
        $movimentacaoId,

        [Alias('i')]
        [Parameter()]
        [Switch]
        $interativo
    )

    $ErrorActionPreference = 'Stop'

    if ($interativo.IsPresent) {
        
        $movimentacoes = Invoke-RestMethod -Uri "https://localhost:7081/Movimentacao/Listar/Ultimas-Movimentacoes" -Method 'Get'

        foreach ($mov in $movimentacoes) {
            Write-Host "$(Get-Date $mov.Data -Format 'dd/MM') R$ $($mov.Valor)  $($mov.Descricao)"
        }

        $choices = $movimentacoes | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($movimentacoes, $_)) $($_.descricao)" , $_.descricao ) }

        $movimentacaoIndex = $host.UI.PromptForChoice("Selecione ", "", $choices, 0)

        $movimentacaoId = $movimentacoes[$movimentacaoIndex].Id
    }
    else {
        if ($null -eq $movimentacaoId) {
            Write-Host 'Informe a MovimentacaoId ou use o modo Interativo -i' -ForegroundColor DarkYellow
            return 
        }
    }

    Invoke-RestMethod -Uri "https://localhost:7081/Movimentacao/Excluir/$movimentacaoId" -Method 'Delete'
    Write-Host 'Movimentacao excluida' -ForegroundColor Green
}