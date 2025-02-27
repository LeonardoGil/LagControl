import { ChangeDetectionStrategy, Component } from '@angular/core';
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
  
}

