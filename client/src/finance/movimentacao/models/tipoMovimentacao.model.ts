export enum TipoMovimentacaoEnum {
    Receita = 0,
    Despesa = 1,
    Transferencia = 2
}

export const TipoMovimentacaoOptions = [
    { 
      label: '',
      value: null
    },
    { 
      label: 'Receita',
      value: TipoMovimentacaoEnum.Receita
    },
    {
      label: 'Despesa',
      value: TipoMovimentacaoEnum.Despesa
    },
    {
      label: 'Transferencia',
      value: TipoMovimentacaoEnum.Transferencia
    }
  ]