import { Movimentacao } from './../../movimentacao/models/movimentacao.model';
export interface ExtratoModel {
    Conta: string
    
    DataInicio: Date
    DataFim: Date

    SaldoInicial: number
    SaldoFinal: number

    ExtratosDia: ExtratoDiaModel[]
}

export interface ExtratoDiaModel {
    Dia: string

    Movimentacoes: Movimentacao[]

    ValorTotal: number
    ValorInicialDia: number
    ValorFinalDia: number
}
