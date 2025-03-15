import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Conta } from '../models/conta.model';

@Injectable({
  providedIn: 'root'
})
export class ContaService {
  
  private contaSubject = new BehaviorSubject<Conta[]>([])
  private httpClient = inject(HttpClient)

  contas$ = this.contaSubject.asObservable();

  listar(params?: HttpParams) : Observable<Conta[]> {
    return this.httpClient.get<Conta[]>('https://localhost:7081/Conta/Listar', { params: params ?? undefined }).pipe(
      tap(contas => { this.contaSubject.next(contas) })
    )
  }
}
