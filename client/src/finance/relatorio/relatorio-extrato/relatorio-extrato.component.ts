import { DateUtilsService, Periodo, PeriodoList } from './../../../share/services/date-utils.service';
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
  imports: [...commonProviders],
  templateUrl: './relatorio-extrato.component.html',
  styleUrl: './relatorio-extrato.component.css',
})
export class RelatorioExtratoComponent implements OnInit, OnDestroy {
  private dateUtilsService: DateUtilsService = inject(DateUtilsService);
  private relatorioService: RelatorioService = inject(RelatorioService);
  private appService: AppService = inject(AppService);
  private destroy$: Subject<void> = new Subject<void>();

  protected extrato!: ExtratoModel;
  protected periodos: Periodo[] = PeriodoList
  protected periodo: Periodo | undefined;

  constructor() {
    this.appService.definirTitulo('Extrato');
    this.appService.definirNevagacao(['Relatório', 'Extrato']);
  }

  ngOnInit(): void {
    this.periodo = this.periodoAtual();
    this.filter();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }

  private periodoAtual(): Periodo | undefined {
    const dataAtual = new Date();

    return this.periodos.find((periodo: Periodo) => periodo.Data.getMonth() === dataAtual.getMonth() &&
                                                    periodo.Data.getFullYear() === dataAtual.getFullYear());
  }

  protected filter()
  {
    if (!this.periodo)
      return

    const periodoMes = this.dateUtilsService.obterPeriodoMes(this.periodo.Data)

    let params: HttpParams = new HttpParams();

    params = params.append('ContaId', '9ab68e5a-a829-40b9-9d32-b9746d3134f5');
    params = params.append('DataInicio', this.dateUtilsService.formatarData(periodoMes.dataInicial));
    params = params.append('DataFim', this.dateUtilsService.formatarData(periodoMes.dataFinal));

    this.relatorioService
      .extrato(params)
      .pipe(takeUntil(this.destroy$))
      .subscribe((extrato) => (this.extrato = extrato));
  }

  formatarDataString(dateString: string): string {
    const date = new Date(dateString);

    return new Intl.DateTimeFormat('pt-BR').format(date);
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
        return '';
    }
  }

  protected getStyleTipoMovimentacao(tipo: TipoMovimentacaoEnum): string {
    switch (tipo) {
      case TipoMovimentacaoEnum.Despesa:
        return 'text-red-500';

      case TipoMovimentacaoEnum.Receita:
        return 'text-green-500';

      default:
        return '';
    }
  }

  protected getStyleSaldoMovimentacao(saldo: number): string {
    if (saldo < 0) return 'text-red-500';
    else return 'text-green-500';
  }
}
