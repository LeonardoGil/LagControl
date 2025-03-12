import { TipoMovimentacaoEnum } from "./tipoMovimentacao.model"

export class Movimentacao {
    Id: string = ''
    Descricao: string = ''
    Observacao: string = ''
    Valor: number = 0
    Data: Date = new Date()
    ContaId: string = ''
    CategoriaId: string = ''
    Tipo: TipoMovimentacaoEnum = TipoMovimentacaoEnum.Despesa
    Pendente: boolean = false
} 


