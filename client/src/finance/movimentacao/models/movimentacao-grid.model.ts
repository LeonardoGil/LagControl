import { Categoria } from './../../categoria/models/categoria.model';
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

    ContaId: string

    ContaTransferencia: string

    Categoria: string

    CategoriaId: string
  }