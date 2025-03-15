import { TipoMovimentacaoEnum } from "./tipoMovimentacao.model"

export interface MovimentacaoGrid {
    Id: string

    Descricao: string

    Observacao: string

    Valor: number

    Data: string

    Tipo: TipoMovimentacaoEnum

    Pendente: boolean

    Conta: string

    ContaTransferencia: string

    Categoria: string
  }