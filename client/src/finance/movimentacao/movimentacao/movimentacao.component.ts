import { MovimentacaoGrid } from './../models/movimentacao.model';
import { ChangeDetectionStrategy, Component, ViewChild, AfterViewInit, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpParams } from '@angular/common/http';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MAT_DATE_LOCALE, provideNativeDateAdapter } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';

import { TipoMovimentacaoEnum } from '../models/tipoMovimentacao.model';
import { MovimentacaoService } from '../services/movimentacao.service';
import { TipoMovimentacaoColumnTemplateTsComponent } from "../../../share/templates/TipoMovimentacao/TipoMovimentacao.Column.Template.component";

import { format } from 'date-fns';

@Component({
  selector: 'app-movimentacao',
  imports: [MatTableModule,
    MatPaginatorModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatSlideToggleModule,
    FormsModule, 
    MatDatepickerModule,
    
    
    TipoMovimentacaoColumnTemplateTsComponent],
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
  
  movimentacoesDataSource: MatTableDataSource<MovimentacaoGrid> = new MatTableDataSource<MovimentacaoGrid>()
  colunas: string[] = ['descricao', 'observacao', 'valor', 'data', 'tipo', 'pendente', 'conta', 'categoria']

  @ViewChild(MatPaginator)
  paginator!: MatPaginator

  filterModel = new MovimentacaoFilter()

  protected TipoMovimentacaoOptions = Object.keys(TipoMovimentacaoEnum)
                                            .filter(key => isNaN(Number(key)))
                                            .map(key => ({
                                                label: key,
                                                value: TipoMovimentacaoEnum[key as keyof typeof TipoMovimentacaoEnum]
                                            }))

  constructor(private movimentacaoService: MovimentacaoService) {

  }
  
  ngAfterViewInit(): void {

    this.filterModel.DataInicial = new Date(2025, 2, 1)
    this.filterModel.DataFinal = new Date(2025, 2, 28, 23, 59, 59)

    this.filterMovimentacoes(undefined)
  } 

  filterMovimentacoes(teste: any) {
    let params = new HttpParams()

    params = params.set('ContaIds', '9ab68e5a-a829-40b9-9d32-b9746d3134f5')
    params = params.set('ApenasPendentes', this.filterModel.Pendente.toString())

    if (this.filterModel.Descricao !== undefined && this.filterModel.Descricao != '') {
        params = params.set('Descricao', this.filterModel.Descricao)
    }

    if (this.filterModel.DataInicial !== undefined && this.filterModel.DataFinal !== undefined) {
        params = params.set('DataInicial', format(this.filterModel.DataInicial, 'yyyy-MM-dd\'T\'HH:mm:ss'))
        params = params.set('DataFinal', format(this.filterModel.DataFinal, 'yyyy-MM-dd\'T\'HH:mm:ss'))
    }
    
    this.movimentacaoService.Listar(params).subscribe(
      (result) => {
        this.movimentacoesDataSource = new MatTableDataSource<MovimentacaoGrid>(result)
        this.movimentacoesDataSource.paginator = this.paginator
      }
    )
  }
}

export class MovimentacaoFilter {
  Descricao!: string
  Tipo!: TipoMovimentacaoEnum
  Pendente: Boolean = false

  DataInicial!: Date
  DataFinal!: Date
}