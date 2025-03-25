import { AppService } from './../../../app/app.service';
import { HttpParams } from '@angular/common/http';
import { ExtratoModel } from '../models/extrato.model';
import { RelatorioService } from '../services/relatorio.service';
import { commonProviders } from './../../../share/providers/common.provider';
import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { TipoMovimentacaoEnum } from '../../movimentacao/models/tipoMovimentacao.model';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-relatorio-extrato',
  standalone: true,
  imports: [
    ...commonProviders,
  ],
  templateUrl: './relatorio-extrato.component.html',
  styleUrl: './relatorio-extrato.component.css',
})
export class RelatorioExtratoComponent implements OnInit, OnDestroy {
  
  private relatorioService: RelatorioService = inject(RelatorioService);
  private appService: AppService = inject(AppService);
  private destroy$: Subject<void> = new Subject<void>();

  protected extrato!: ExtratoModel
  
  constructor() {
    this.appService.definirTitulo('Extrato')
    this.appService.definirNevagacao(['Relatório', 'Extrato']);
  }
  
  ngOnInit(): void {
    let params: HttpParams = new HttpParams()

    params = params.append('ContaId', '9ab68e5a-a829-40b9-9d32-b9746d3134f5')
    params = params.append('DataInicio', '2025-03-01')
    params = params.append('DataFim', '2025-03-31')
    
    this.relatorioService.extrato(params).pipe(takeUntil(this.destroy$)).subscribe(extrato => this.extrato = extrato)
  } 

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe(); throw new Error('Method not implemented.');
  }

  formatarDataString(dateString: string): string {
    const date = new Date(dateString);

    return new Intl.DateTimeFormat("pt-BR").format(date);
  }

  protected trackExtratoDia(index: number, obj: any): string {
    return obj.Dia; 
  }

  protected obterIconTipoMovimentacao(tipo: TipoMovimentacaoEnum): string {
    switch (tipo) {
      case TipoMovimentacaoEnum.Despesa:
        return 'arrow_drop_down';

      case TipoMovimentacaoEnum.Receita:
        return 'arrow_drop_up';

      default:
        return ''
    }
  }

  protected getStyleTipoMovimentacao(tipo: TipoMovimentacaoEnum): string {
    switch (tipo) {
      case TipoMovimentacaoEnum.Despesa:
        return 'text-red-500';

      case TipoMovimentacaoEnum.Receita:
        return 'text-green-500';

      default:
        return ''
    }
  }

  protected getStyleSaldoMovimentacao(saldo: number): string {
    if (saldo < 0)
      return 'text-red-500';
    else 
      return 'text-green-500';
  }
}