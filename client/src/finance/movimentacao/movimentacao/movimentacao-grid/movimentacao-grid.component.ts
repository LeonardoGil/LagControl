import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild, inject } from '@angular/core';
import { Subscription } from 'rxjs';

import { MatPaginator } from '@angular/material/paginator';

import { commonProviders } from '../../../../share/providers/common.provider';
import { gridProviders } from '../../../../share/providers/grid.provider';
import { TipoMovimentacaoColumnTemplateTsComponent } from '../../../../share/templates/TipoMovimentacao/TipoMovimentacao.Column.Template.component';

import { MovimentacaoService } from '../../services/movimentacao.service';
import { MovimentacaoGrid } from '../../models/movimentacao.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-movimentacao-grid',
  standalone: true,
  imports: [
    ...commonProviders,
    ...gridProviders,

    TipoMovimentacaoColumnTemplateTsComponent
  ],
  templateUrl: './movimentacao-grid.component.html',
  styleUrl: './movimentacao-grid.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoGridComponent implements OnInit, OnDestroy {
  
  movimentacoesDataSource: MatTableDataSource<MovimentacaoGrid> = new MatTableDataSource<MovimentacaoGrid>()
  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  private subscription!: Subscription

  @ViewChild(MatPaginator)
  paginator!: MatPaginator
  colunas: string[] = ['descricao', 'observacao', 'valor', 'data', 'tipo', 'pendente', 'conta', 'categoria']

  ngOnInit(): void {
    this.subscription = this.movimentacaoService.movimentacoes$.subscribe(data => this.movimentacoesDataSource.data = data)
    this.movimentacoesDataSource.paginator = this.paginator
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  } 
}
