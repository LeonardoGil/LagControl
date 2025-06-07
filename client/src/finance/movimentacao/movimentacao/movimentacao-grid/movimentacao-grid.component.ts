import { AcaoMovimentacaoEnum } from './../dialogs/movimentacao-dialog/movimentacao-dialog.component';
import { ConfirmarDialogModel } from './../../../../share/dialogs/confirmar-dialog.component';
import { Movimentacao } from './../../models/movimentacao.model';
import { AfterViewInit, ChangeDetectionStrategy, Component, OnDestroy, ViewChild, inject } from '@angular/core';
import { Subscription } from 'rxjs';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

import { commonProviders } from '../../../../share/providers/common.provider';
import { gridProviders } from '../../../../share/providers/grid.provider';
import { TipoMovimentacaoColumnTemplateTsComponent } from '../../../../share/templates/TipoMovimentacao/TipoMovimentacao.Column.Template.component';

import { MovimentacaoService } from '../../services/movimentacao.service';
import { MovimentacaoGrid } from '../../models/movimentacao-grid.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { MovimentacaoDialogComponent } from '../dialogs/movimentacao-dialog/movimentacao-dialog.component';
import { ConfirmarDialogComponent } from '../../../../share/dialogs/confirmar-dialog.component';

@Component({
  selector: 'app-movimentacao-grid',
  standalone: true,
  imports: [
    ...commonProviders,
    ...gridProviders,

    TipoMovimentacaoColumnTemplateTsComponent,
  ],
  templateUrl: './movimentacao-grid.component.html',
  styleUrl: './movimentacao-grid.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoGridComponent implements AfterViewInit, OnDestroy {
  
  private readonly dialog = inject(MatDialog);
  protected movimentacoesDataSource: MatTableDataSource<MovimentacaoGrid> = new MatTableDataSource<MovimentacaoGrid>();
  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService);
  private subscription!: Subscription;

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  colunas: string[] = [
    'Descricao',
    'Observacao',
    'Valor',
    'Data',
    'TipoMovimentacao',
    'Conta',
    'Categoria',
    'Actions',
  ];

  ngAfterViewInit(): void {
    this.subscription = this.movimentacaoService.movimentacoes$.subscribe(
      (data) => {
        this.movimentacoesDataSource.data = data;
        this.movimentacoesDataSource.paginator = this.paginator;
        this.movimentacoesDataSource.sort = this.sort;
      }
    )
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  protected clickAdicionar(): void {
    this.dialog.open(MovimentacaoDialogComponent, this.dataMovimentacaoDialog(undefined, AcaoMovimentacaoEnum.Adicionar))
               .afterClosed()
               .subscribe((result: boolean) => this.resultMovimentacaoDialog(result));
  }

  protected clickEditar(movimentacao: Movimentacao): void {
    this.dialog.open(MovimentacaoDialogComponent, this.dataMovimentacaoDialog(movimentacao, AcaoMovimentacaoEnum.Editar))
               .afterClosed()
               .subscribe((result: boolean) => this.resultMovimentacaoDialog(result));
  }

  protected clickConfirmarPendente(movimentacao: Movimentacao): void {
    this.dialog.open(MovimentacaoDialogComponent, this.dataMovimentacaoDialog(movimentacao, AcaoMovimentacaoEnum.ConfirmarPendente))
               .afterClosed()
               .subscribe((result: boolean) => this.resultMovimentacaoDialog(result));
  }

  protected clickExcluir(movimentacao: Movimentacao): void {
    const data: ConfirmarDialogModel = {
      Mensagem: `Gostaria de excluir a movimentação: ${movimentacao.Descricao}`
    }

    this.dialog.open(ConfirmarDialogComponent, { data: data }).afterClosed().subscribe((result) => {
      if (result) {
        this.movimentacaoService.excluir(movimentacao.Id).subscribe(() => this.movimentacaoService.listar().subscribe())
      }
    });
  }

  protected formatarData(dataString: string): string {
    return (new Date(dataString)).toLocaleDateString('pt-BR');
  }

  private resultMovimentacaoDialog(result: boolean): void {
    if (result) {
      this.movimentacaoService.listar().subscribe();
    }
  }

  private dataMovimentacaoDialog(movimentacao: Movimentacao | undefined, acao: AcaoMovimentacaoEnum): any {
    return {
      data: {
        movimentacao: movimentacao, 
        acao: acao
      }
    }
  }
}

