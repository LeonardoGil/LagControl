export enum TipoMovimentacaoEnum {
    Receita,
    Despesa,
    Transferencia
}

export const TipoMovimentacaoOptions = [
    { 
      label: '',
      value: null
    },
    { 
      label: 'Receita',
      value: 0 as TipoMovimentacaoEnum
    },
    {
      label: 'Despesa',
      value: 1  as TipoMovimentacaoEnum
    },
    {
      label: 'Transferencia',
      value: 2 as TipoMovimentacaoEnum
    }
  ]