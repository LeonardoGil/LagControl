import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MovimentacaoGrid } from "../models/movimentacao.model";
import { BehaviorSubject, Observable, tap } from "rxjs";


@Injectable({providedIn: 'root'})
export class MovimentacaoService {
  constructor(private httpClient: HttpClient) {}
  
  private movimentacaoSubject = new BehaviorSubject<MovimentacaoGrid[]>([]);
  movimentacoes$ = this.movimentacaoSubject.asObservable();

  Listar(params: HttpParams) : Observable<MovimentacaoGrid[]> {
    return this.httpClient.get<MovimentacaoGrid[]>('https://localhost:7081/Movimentacao/Listar', { params: params }).pipe(
      tap(data => this.movimentacaoSubject.next(data))
    )
  }


}