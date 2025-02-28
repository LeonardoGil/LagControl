import { MovimentacaoService } from './../../services/movimentacao.service';
import { Movimentacao } from './../../models/movimentacao.model';
import { ChangeDetectionStrategy, Component, inject, model } from '@angular/core';
import { commonProviders } from '../../../../share/providers/common.provider';

import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';

@Component({
  selector: 'app-movimentacao-adicionar-dialog',
  standalone: true,
  imports: [
    commonProviders,

    MatDialogActions,
    MatDialogClose,
    MatDialogContent,
    MatDialogTitle,
  ],
  templateUrl: './movimentacao-adicionar-dialog.component.html',
  styleUrl: './movimentacao-adicionar-dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoAdicionarDialogComponent { 
  readonly dialogRef = inject(MatDialogRef<MovimentacaoAdicionarDialogComponent>);

  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  movimentacao: Movimentacao = new Movimentacao();

  ClickAdicionar(): void  {
    console.log(this.movimentacao)
  }

  Fechar(): void {
    this.dialogRef.close(false);
  }

  private Adicionar(): void {
    this.movimentacaoService.Adicionar(this.movimentacao).subscribe(() => {
      this.movimentacaoService.Listar().subscribe()
    })
  }
}
