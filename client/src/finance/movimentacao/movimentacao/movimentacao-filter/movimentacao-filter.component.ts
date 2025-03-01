import { DateUtilsService } from './../../../../share/services/date-utils.service';
import { ChangeDetectionStrategy, Component, OnInit, OnDestroy, inject } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { format } from 'date-fns';

import { MAT_DATE_LOCALE, provideNativeDateAdapter } from '@angular/material/core';

import { commonProviders } from './../../../../share/providers/common.provider';

import { Categoria } from '../../../categoria/models/categoria.model';
import { TipoMovimentacaoEnum } from '../../models/tipoMovimentacao.model';

import { CategoriaService } from './../../../categoria/services/categoria.service';
import { MovimentacaoService } from '../../services/movimentacao.service';

@Component({
  selector: 'app-movimentacao-filter',
  standalone: true,
  imports: [
    commonProviders
  ],
  providers: [
    provideNativeDateAdapter(),
    {
      provide: MAT_DATE_LOCALE, 
      useValue: 'pt-br'
    }
  ],
  templateUrl: './movimentacao-filter.component.html',
  styleUrl: './movimentacao-filter.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoFilterComponent implements OnInit, OnDestroy {

  private dateUtilsService: DateUtilsService = inject(DateUtilsService)

  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  private categoriaService: CategoriaService = inject(CategoriaService)
  private subscription!: Subscription
  
  categorias: Categoria[] = []
  filterModel = new MovimentacaoFilter()
  
  ngOnInit(): void {
    this.categoriaService.Listar(new HttpParams()).subscribe((categorias: Categoria[]) => this.categorias = categorias)
    
    const periodo = this.dateUtilsService.obterPeriodoMes();

    this.filterModel.DataInicial = periodo.dataInicial
    this.filterModel.DataFinal = periodo.dataFinal

    this.filterMovimentacoes()
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  } 

  protected TipoMovimentacaoOptions = [
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
 
  filterMovimentacoes() {
    let params = new HttpParams()

    params = params.set('ContaIds', '9ab68e5a-a829-40b9-9d32-b9746d3134f5')
    params = params.set('ApenasPendentes', this.filterModel.Pendente.toString())

    if (this.filterModel.Descricao !== undefined && this.filterModel.Descricao != '') {
        params = params.set('Descricao', this.filterModel.Descricao)
    }

    if (this.filterModel.CategoriaId !== undefined && this.filterModel.CategoriaId != '') {
      params = params.set('CategoriaIds', this.filterModel.CategoriaId)
    } 

    if (this.filterModel.Tipo !== undefined) {
      params = params.set('Tipo', this.filterModel.Tipo)
    }

    if (this.filterModel.DataInicial !== undefined && this.filterModel.DataInicial != null 
      && this.filterModel.DataFinal !== undefined && this.filterModel.DataFinal != null) {

        this.filterModel.DataFinal.setHours(0, 0, 0)
        params = params.set('DataInicial', format(this.filterModel.DataInicial, 'yyyy-MM-dd\'T\'HH:mm:ss'))
      
        this.filterModel.DataFinal.setHours(23, 59, 59)  
        params = params.set('DataFinal', format(this.filterModel.DataFinal, 'yyyy-MM-dd\'T\'HH:mm:ss'))
    }
    
    this.subscription = this.movimentacaoService.Listar(params).subscribe()
  }
}

export class MovimentacaoFilter {
  Descricao!: string
  Tipo!: TipoMovimentacaoEnum
  Pendente: boolean = false

  CategoriaId!: string
  ContaId!: string

  DataInicial!: Date
  DataFinal!: Date
}