import { TipoMovimentacaoEnum } from "./tipoMovimentacao.model"

export interface MovimentacaoGrid {
    Id: String

    Descricao: String

    Observacao: String

    Valor: Number

    Data: String

    TipoMovimentacao: TipoMovimentacaoEnum

    Pendente: Boolean

    Conta: String

    ContaTransferencia: String

    Categoria: String
  }