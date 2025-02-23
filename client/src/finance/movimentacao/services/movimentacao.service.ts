import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MovimentacaoGrid } from "../models/movimentacao.model";
import { Observable } from "rxjs";


@Injectable({providedIn: 'root'})
export class MovimentacaoService {
  constructor(private httpClient: HttpClient) {}
  
  Listar(query: string) : Observable<MovimentacaoGrid[]> {
    return this.httpClient.get<MovimentacaoGrid[]>('https://localhost:7081/Movimentacao/Listar' + query)
  }
}