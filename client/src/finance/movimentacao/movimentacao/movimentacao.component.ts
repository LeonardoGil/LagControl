import { inject } from '@angular/core';
import { ChangeDetectionStrategy, Component, ViewChild, AfterViewInit } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { format } from 'date-fns';

import { commonProviders } from './../../../share/providers/common.provider';

import { MAT_DATE_LOCALE, provideNativeDateAdapter } from '@angular/material/core';

import { CategoriaService } from './../../categoria/services/categoria.service';
import { MovimentacaoService } from './../services/movimentacao.service';

import { Categoria } from '../../categoria/models/categoria.model';
import { TipoMovimentacaoEnum } from '../models/tipoMovimentacao.model';
import { MovimentacaoGridComponent } from "./movimentacao-grid/movimentacao-grid.component";

@Component({
  imports: [
    ...commonProviders,
    
    MovimentacaoGridComponent
],
  providers: [
    provideNativeDateAdapter(),
    {
      provide: MAT_DATE_LOCALE, 
      useValue: 'pt-br'
    },
  ],
  standalone: true,
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MovimentacaoComponent implements AfterViewInit {
  
  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  private CategoriaService: CategoriaService = inject(CategoriaService)
  
  ngAfterViewInit(): void {
    this.CategoriaService.Listar(new HttpParams()).subscribe((categorias: Categoria[]) => this.categorias = categorias)
    
    this.filterModel.DataInicial = new Date(2025, 2, 1)
    this.filterModel.DataFinal = new Date(2025, 2, 28)

    this.filterMovimentacoes(undefined)
  }
  
  categorias: Categoria[] = []
  filterModel = new MovimentacaoFilter()

  protected TipoMovimentacaoOptions = Object.keys(TipoMovimentacaoEnum)
                                            .filter(key => isNaN(Number(key)))
                                            .map(key => ({
                                                label: key,
                                                value: TipoMovimentacaoEnum[key as keyof typeof TipoMovimentacaoEnum]
                                            }))
 
  filterMovimentacoes(teste: any) {
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
    
    this.movimentacaoService.Listar(params).subscribe()
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