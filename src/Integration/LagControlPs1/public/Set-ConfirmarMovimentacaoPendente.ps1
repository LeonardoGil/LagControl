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

    $skip = 0
    $take = 9
    $next = [ChoiceDescription]::new('&+ Proximo', 'Proximo') 
    $back = [ChoiceDescription]::new('&- Voltar', 'Voltar') 

    do {
        
        $selectedMovimentacoes = $movimentacoes | Select-Object -Skip $skip -First $take

        $choices = $selectedMovimentacoes | ForEach-Object { 
            $message = "&$([Array]::IndexOf($selectedMovimentacoes, $_)) $($_.descricao)"
            
            $helpMessage = "$(Get-Date $_.Data -Format 'dd/MM/yyyy') R$ $($_.Valor) $($_.descricao)"
            
            return [ChoiceDescription]::new($message, $helpMessage) 
        }

        if (($skip + $take) -lt $movimentacoes.Count) {
            $choices += $next
        }
   
        if ($skip -gt 0) {
            $choices += $back
        } 


        $selected = $host.UI.PromptForChoice("Escolha uma movimentação", "", $choices, '0')

        switch ($selected) {
            {[Array]::IndexOf($choices, $next) -eq $_} {  
                $skip += $take
            }

            {[Array]::IndexOf($choices, $back) -eq $_} {  
                $skip -= $take
            }
            
            Default {
                return $selectedMovimentacoes[$selected]
            }
        }

    } while ($true)
}