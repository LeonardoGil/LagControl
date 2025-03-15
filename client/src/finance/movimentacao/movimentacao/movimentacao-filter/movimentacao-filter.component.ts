import { ChangeDetectionStrategy, Component, OnInit, OnDestroy, inject } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Subject, takeUntil } from 'rxjs';
import { format } from 'date-fns';

import { commonProviders } from './../../../../share/providers/common.provider';

import { Conta } from '../../../conta/models/conta.model';
import { Categoria } from './../../../categoria/models/categoria.model';
import { TipoMovimentacaoEnum, TipoMovimentacaoOptions } from '../../models/tipoMovimentacao.model';

import { CategoriaService } from './../../../categoria/services/categoria.service';
import { MovimentacaoService } from '../../services/movimentacao.service';
import { DateUtilsService } from './../../../../share/services/date-utils.service';
import { ContaService } from '../../../conta/services/conta.service';

@Component({
  selector: 'app-movimentacao-filter',
  standalone: true,
  imports: [
    ...commonProviders
  ],
  templateUrl: './movimentacao-filter.component.html',
  styleUrl: './movimentacao-filter.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoFilterComponent implements OnInit, OnDestroy {

  private dateUtilsService: DateUtilsService = inject(DateUtilsService)
  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  protected categoriaService: CategoriaService = inject(CategoriaService)
  protected contaService: ContaService = inject(ContaService)
  
  private destroy$: Subject<void> = new Subject();

  protected categorias: Categoria[] = []
  protected contas: Conta[] = []
  protected tipoMovimentacaoOptions = TipoMovimentacaoOptions
  protected filterModel = new MovimentacaoFilter()
  
  ngOnInit(): void { 
    this.carregarConta()
    this.carregarCategoria()

    const periodo = this.dateUtilsService.obterPeriodoMes();

    this.filterModel.DataInicial = periodo.dataInicial
    this.filterModel.DataFinal = periodo.dataFinal

    this.filtrarMovimentacoes()
  }
  
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  } 

  private carregarConta(): void {
    this.contaService.contas$.pipe(takeUntil(this.destroy$)).subscribe((contas: Conta[]) => this.contas = contas);
    this.contaService.listar().subscribe();
  }

  private carregarCategoria(): void {
    this.categoriaService.categorias$.pipe(takeUntil(this.destroy$)).subscribe((categorias) => this.categorias = categorias);
    this.categoriaService.listar().subscribe();
  }
 
  protected filtrarMovimentacoes(): void {
    let params = new HttpParams()

    params = params.set('ApenasPendentes', this.filterModel.Pendente.toString())

    if (this.filterModel.Descricao !== undefined && this.filterModel.Descricao != '') {
        params = params.set('Descricao', this.filterModel.Descricao)
    }

    if (this.filterModel.CategoriaId !== undefined && this.filterModel.CategoriaId.length > 0) {
      params = params.set('CategoriaIds', this.filterModel.CategoriaId.join(','))
    } 

    if (this.filterModel.ContaId !== undefined && this.filterModel.ContaId.length > 0) {
      params = params.set('ContaIds', this.filterModel.ContaId.join(','))
    } 

    if (this.filterModel.Tipo !== undefined) {
      params = params.set('Tipo', this.filterModel.Tipo)
    }

    if (this.filterModel.DataInicial !== undefined && this.filterModel.DataInicial != null) {
        this.filterModel.DataInicial.setHours(0, 0, 0)
        params = params.set('DataInicial', format(this.filterModel.DataInicial, 'yyyy-MM-dd\'T\'HH:mm:ss'))
    }

    if (this.filterModel.DataFinal !== undefined && this.filterModel.DataFinal != null) {
        this.filterModel.DataFinal.setHours(23, 59, 59)  
        params = params.set('DataFinal', format(this.filterModel.DataFinal, 'yyyy-MM-dd\'T\'HH:mm:ss'))
    }
    
    this.movimentacaoService.listar(params).pipe(takeUntil(this.destroy$)).subscribe()
  }
}

export class MovimentacaoFilter {
  Descricao!: string
  Tipo!: TipoMovimentacaoEnum
  Pendente: boolean = false

  CategoriaId!: string[]
  ContaId!: string[]

  DataInicial!: Date
  DataFinal!: Date
}
