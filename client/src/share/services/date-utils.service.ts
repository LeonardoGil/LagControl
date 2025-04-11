import { Injectable } from '@angular/core';
import { format } from 'date-fns';

@Injectable({
  providedIn: 'root'
})
export class DateUtilsService {

  constructor() { }
  
  obterPeriodoMes(date: Date | null = null): { dataInicial: Date, dataFinal: Date } {
    const currentDate = date ?? new Date();

    // Primeiro dia do mês atual
    const dataInicial = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1);

    // Último dia do mês atual
    const dataFinal = new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 0);

    return { dataInicial, dataFinal };
  }

  formatarData(date: Date): string {
    return format(date, 'yyyy-MM-dd\'T\'HH:mm:ss')
  }
}

export interface Periodo
{
  Descricao: string
  Data: Date
}

export const PeriodoList: Periodo[] = [
    { 
      Descricao: 'Janeiro 2025', 
      Data: new Date(2025, 0, 1) 
    },
    { 
      Descricao: 'Fevereiro 2025', 
      Data: new Date(2025, 1, 1) 
    },
    { 
      Descricao: 'Março 2025', 
      Data: new Date(2025, 2, 1) 
    },
    { 
      Descricao: 'Abril 2025', 
      Data: new Date(2025, 3, 1) 
    },
    { 
      Descricao: 'Maio 2025', 
      Data: new Date(2025, 4, 1) 
    }
]