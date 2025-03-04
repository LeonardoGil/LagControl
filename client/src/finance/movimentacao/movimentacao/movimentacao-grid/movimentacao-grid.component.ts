import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild, inject } from '@angular/core';
import { Subscription } from 'rxjs';

import { MatPaginator } from '@angular/material/paginator';

import { commonProviders } from '../../../../share/providers/common.provider';
import { gridProviders } from '../../../../share/providers/grid.provider';
import { TipoMovimentacaoColumnTemplateTsComponent } from '../../../../share/templates/TipoMovimentacao/TipoMovimentacao.Column.Template.component';

import { MovimentacaoService } from '../../services/movimentacao.service';
import { MovimentacaoGrid } from '../../models/movimentacao-grid.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MovimentacaoAdicionarDialogComponent } from '../movimentacao-adicionar-dialog/movimentacao-adicionar-dialog.component';

@Component({
  selector: 'app-movimentacao-grid',
  standalone: true,
  imports: [
    ...commonProviders,
    ...gridProviders,

    TipoMovimentacaoColumnTemplateTsComponent
  ],
  templateUrl: './movimentacao-grid.component.html',
  styleUrl: './movimentacao-grid.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoGridComponent implements OnInit, OnDestroy {

  readonly dialog = inject(MatDialog);

  movimentacoesDataSource: MatTableDataSource<MovimentacaoGrid> = new MatTableDataSource<MovimentacaoGrid>()
  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  private subscription!: Subscription

  @ViewChild(MatPaginator)
  paginator!: MatPaginator
  colunas: string[] = ['descricao', 'observacao', 'valor', 'data', 'tipo', 'pendente', 'conta', 'categoria']

  ngOnInit(): void {
    this.subscription = this.movimentacaoService.movimentacoes$.subscribe(data => {
      this.movimentacoesDataSource.data = data
      this.movimentacoesDataSource.paginator = this.paginator
    })
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  } 

  adicionarClick(): void {
    const dialogRef = this.dialog.open(MovimentacaoAdicionarDialogComponent, {
      height: '40rem',
      width: '60rem',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      
    });
  }

  protected formatarData(dataString: string): string {
    const data = new Date(dataString);
    
    return data.toLocaleDateString('pt-BR');
  }
}
