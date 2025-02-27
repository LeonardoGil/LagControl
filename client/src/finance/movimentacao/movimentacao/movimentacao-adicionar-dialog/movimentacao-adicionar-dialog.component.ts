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

  movimentacao: Movimentacao = new Movimentacao();

  fechar(): void {
    this.dialogRef.close(false);
  }
}
