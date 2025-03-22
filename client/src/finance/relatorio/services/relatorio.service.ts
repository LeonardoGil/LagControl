import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ExtratoModel } from "../models/extrato.model";


@Injectable({providedIn: 'root'})
export class RelatorioService {
  constructor(private httpClient: HttpClient) {}
  
  private params = new HttpParams()
  
  extrato(params?: HttpParams) : Observable<ExtratoModel> {
    
    if (params) {
      this.params = params
    }
    
    return this.httpClient.get<ExtratoModel>('https://localhost:7081/Relatorio/Extrato', { params: this.params }).pipe()
  }
}