import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Conta } from '../models/conta.model';


@Injectable({
  providedIn: 'root'
})
export class ContaService {
  
  private httpClient = inject(HttpClient)

  Listar(params?: HttpParams) : Observable<Conta[]> {
    return this.httpClient.get<Conta[]>('https://localhost:7081/Conta/Listar', { params: params ?? undefined })
  }
}
