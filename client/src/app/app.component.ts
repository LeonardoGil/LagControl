import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatTableModule } from '@angular/material/table'
import { Financa } from './app.model';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MatTableModule, HttpClientModule],
  standalone: true,
  templateUrl: './app.component.html',
})
export class AppComponent {
  
  private API_URL = 'https://localhost:7081'
  
  protected Financas : Financa[] = []

  protected displayedColumns: string[] = ['descricao', 'valor'];

  constructor(private httpClient: HttpClient) {
    this.getItems().subscribe({
      next: (data: any) => {
        this.Financas = data as Financa[]
        console.log("Financas: ", this.Financas)
      },
      error: (error) => {
        console.error('Erro ao carregar os itens', error);
      }
    })
  }

  protected getItems(): Observable<any> {
    return this.httpClient.get(`${this.API_URL}/Movimentacao/Listar?ContaIds=9AB68E5A-A829-40B9-9D32-B9746D3134F5`);
  }
}
