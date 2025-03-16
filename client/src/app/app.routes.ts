import { Routes } from '@angular/router';
import { MovimentacaoComponent } from '../finance/movimentacao/movimentacao/movimentacao.component';
import { ContaListarComponent } from '../finance/conta/conta-listar/conta-listar.component';

export const routes: Routes = [
    { 
        path: 'Movimentacao', 
        component: MovimentacaoComponent 
    },
    { 
        path: 'Conta', 
        component: ContaListarComponent 
    },
];
