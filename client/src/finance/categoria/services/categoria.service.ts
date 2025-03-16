import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { Categoria } from "../models/categoria.model";

@Injectable({providedIn: 'root'})
export class CategoriaService {
  private categoriaSubject = new BehaviorSubject<Categoria[]>([])
  private httpClient = inject(HttpClient)

  categorias!: Categoria[]
  categorias$ = this.categoriaSubject.asObservable()

  listar(params?: HttpParams) : Observable<Categoria[]> {
    return this.httpClient.get<Categoria[]>('https://localhost:7081/Categoria/Listar', { params: params ?? undefined }).pipe(
      tap(data => { 
        this.categorias = data;
        this.categoriaSubject.next(data);
      })
    )
  }
}