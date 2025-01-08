function Select-Conta {
    
    [CmdletBinding()]
    param ()

    $contas = Invoke-RestMethod -Uri 'https://localhost:7081/Conta/Listar' -Method 'Get'
    
    $choices = $contas | ForEach-Object { [ChoiceDescription]::new("&$([Array]::IndexOf($contas, $_)) $($_.Descricao)" , $_.Descricao ) }
    
    $contaIndex = $host.UI.PromptForChoice("Informe a Conta", "", $choices, 0)
    
    return $contas[$contaIndex]
}