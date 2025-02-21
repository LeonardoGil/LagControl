import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { Observable } from 'rxjs';
import { MovimentacaoGrid } from '../models/movimentacao.model';

@Component({
  selector: 'app-movimentacao',
  imports: [MatTableModule,
    HttpClientModule
  ],
  standalone: true,
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.css'
})
export class MovimentacaoComponent {
  protected Movimentacoes: MovimentacaoGrid[] = []
  protected Colunas: string[] = ['descricao',
                                  'observacao',
                                  'valor',
                                  'data',
                                  'tipo',
                                  'pendente',
                                  'conta',
                                  'categoria'
  ]

  constructor(private httpClient: HttpClient) {
    this.ObterDadosGrid().subscribe(
      (result) => {
        this.Movimentacoes = result
        console.log(this.Movimentacoes)
      }
    )
  }

  ObterDadosGrid() : Observable<MovimentacaoGrid[]> {
    return this.httpClient.get<MovimentacaoGrid[]>('https://localhost:7081/Movimentacao/Listar?ContaIds=9ab68e5a-a829-40b9-9d32-b9746d3134f5');
  }
}

