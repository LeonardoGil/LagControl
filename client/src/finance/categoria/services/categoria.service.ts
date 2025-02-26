import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { Categoria } from "../models/categoria.model";

@Injectable({providedIn: 'root'})
export class CategoriaService {

  private httpClient = inject(HttpClient)

  Listar(params: HttpParams) : Observable<Categoria[]> {
    return this.httpClient.get<Categoria[]>('https://localhost:7081/Categoria/Listar', { params: params })
  }
}