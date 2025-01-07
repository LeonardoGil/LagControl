function Get-DatePrimeiroDiaSeForNull {

    [CmdletBinding()]
    param (
        [Parameter(Position=0)]
        [Nullable[datetime]]
        $data
    )

    if ($null -eq $data) {
        $data = Get-Date -Day 1
    }
    
    return $data
}