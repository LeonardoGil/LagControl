import { MovimentacaoGrid } from './../models/movimentacao.model';
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { TipoMovimentacaoEnum } from '../models/tipoMovimentacao.model';
import { MovimentacaoService } from '../services/movimentacao.service';
import { TipoMovimentacaoColumnTemplateTsComponent } from "../../../share/templates/TipoMovimentacao/TipoMovimentacao.Column.Template.component";

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
    
    TipoMovimentacaoColumnTemplateTsComponent],
  standalone: true,
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.scss'
})
export class MovimentacaoComponent implements AfterViewInit {
  
  movimentacoesDataSource: MatTableDataSource<MovimentacaoGrid> = new MatTableDataSource<MovimentacaoGrid>()
  colunas: string[] = ['descricao', 'observacao', 'valor', 'data', 'tipo', 'pendente', 'conta', 'categoria']

  @ViewChild(MatPaginator)
  paginator: MatPaginator = new MatPaginator;


  protected TipoMovimentacaoOptions = Object.keys(TipoMovimentacaoEnum)
                                            .filter(key => isNaN(Number(key)))
                                            .map(key => ({
                                                label: key,
                                                value: TipoMovimentacaoEnum[key as keyof typeof TipoMovimentacaoEnum]
                                            }))

  constructor(private movimentacaoService: MovimentacaoService) {

  }
  
  ngAfterViewInit(): void {

    let query = '?ContaIds=9ab68e5a-a829-40b9-9d32-b9746d3134f5'

    this.movimentacaoService.Listar(query).subscribe(
      (result) => {
        this.movimentacoesDataSource = new MatTableDataSource<MovimentacaoGrid>(result)
        this.movimentacoesDataSource.paginator = this.paginator
      }
    )
  } 

}

