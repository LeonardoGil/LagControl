export interface ContaSaldo {
    Id: string
    Descricao: string
    Saldo: number
    SaldoPrevisto: number
    DataUltimaMovimentacao: Date | null
}