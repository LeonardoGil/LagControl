import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MovimentacaoGrid } from "../models/movimentacao.model";
import { Observable } from "rxjs";


@Injectable({providedIn: 'root'})
export class MovimentacaoService {
  constructor(private httpClient: HttpClient) {}
  
  Listar(params: HttpParams) : Observable<MovimentacaoGrid[]> {
    return this.httpClient.get<MovimentacaoGrid[]>('https://localhost:7081/Movimentacao/Listar', { params: params })
  }
}