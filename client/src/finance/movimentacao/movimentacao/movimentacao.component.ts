import { AppService } from './../../../app/app.service';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { commonProviders } from './../../../share/providers/common.provider';

import { MovimentacaoGridComponent } from "./movimentacao-grid/movimentacao-grid.component";
import { MovimentacaoFilterComponent } from "./movimentacao-filter/movimentacao-filter.component";

@Component({
  imports: [
    ...commonProviders,
    
    MovimentacaoGridComponent,
    MovimentacaoFilterComponent
],  
  standalone: true,
  templateUrl: './movimentacao.component.html',
  styleUrl: './movimentacao.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MovimentacaoComponent {
    private appService: AppService = inject(AppService)

    constructor() {
      this.appService.definirTitulo('Movimentações')
      this.appService.definirNevagacao(['Financeiro', 'Movimentações'])
    }
}

