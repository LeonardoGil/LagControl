import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { MovimentacaoGrid } from '../models/movimentacao.model';
import { TipoMovimentacaoEnum } from '../models/tipoMovimentacao.model';

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

    HttpClientModule
  ],
  standalone: true,
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.css'
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

  constructor(private httpClient: HttpClient) {

  }
  
  ngAfterViewInit(): void {
    this.ObterDadosGrid().subscribe(
      (result) => {
        this.movimentacoesDataSource = new MatTableDataSource<MovimentacaoGrid>(result)
        this.movimentacoesDataSource.paginator = this.paginator
      }
    )
  }

  ObterDadosGrid() : Observable<MovimentacaoGrid[]> {
    return this.httpClient.get<MovimentacaoGrid[]>('https://localhost:7081/Movimentacao/Listar?ContaIds=9ab68e5a-a829-40b9-9d32-b9746d3134f5');
  }
}

