import { Routes } from '@angular/router';
import { MovimentacaoComponent } from '../finance/movimentacao/movimentacao/movimentacao.component';
import { ContaListarComponent } from '../finance/conta/conta-listar/conta-listar.component';
import { RelatorioExtratoComponent } from '../finance/relatorio/relatorio-extrato/relatorio-extrato.component';

export const routes: Routes = [
    { 
        path: 'Movimentacao', 
        component: MovimentacaoComponent 
    },
    { 
        path: 'Conta', 
        component: ContaListarComponent 
    },
    {
        path: 'Relatorio/Extrato',
        component: RelatorioExtratoComponent
    }
];
