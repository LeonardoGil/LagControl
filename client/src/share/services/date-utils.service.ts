import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateUtilsService {

  constructor() { }
  
  obterPeriodoMes(): { dataInicial: Date, dataFinal: Date } {
    const currentDate = new Date();

    // Primeiro dia do mês atual
    const dataInicial = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);

    // Último dia do mês atual
    const dataFinal = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 0);

    return { dataInicial, dataFinal };
  }
}
