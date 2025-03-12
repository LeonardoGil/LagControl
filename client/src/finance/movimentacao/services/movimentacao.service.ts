import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MovimentacaoGrid } from "../models/movimentacao-grid.model";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { Movimentacao } from "../models/movimentacao.model";


@Injectable({providedIn: 'root'})
export class MovimentacaoService {
  constructor(private httpClient: HttpClient) {}
  
  private movimentacaoSubject = new BehaviorSubject<MovimentacaoGrid[]>([])
  private params = new HttpParams()
  
  movimentacoes$ = this.movimentacaoSubject.asObservable()

  Listar(params?: HttpParams) : Observable<MovimentacaoGrid[]> {
    
    if (params) {
      this.params = params
    }
    
    return this.httpClient.get<MovimentacaoGrid[]>('https://localhost:7081/Movimentacao/Listar', { params: this.params }).pipe(
      tap(data => this.movimentacaoSubject.next(data))
    )
  }

  Adicionar(movimentacao: Movimentacao): Observable<any> {
    return this.httpClient.post('https://localhost:7081/Movimentacao/Adicionar', movimentacao).pipe()
  }

  excluir(id: string): Observable<any> {
    return this.httpClient.delete('https://localhost:7081/Movimentacao/Excluir/' + id).pipe()
  }
}