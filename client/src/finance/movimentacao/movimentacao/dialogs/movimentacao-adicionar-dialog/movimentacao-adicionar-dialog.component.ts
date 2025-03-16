import { MovimentacaoService } from '../../../services/movimentacao.service';
import { ChangeDetectionStrategy, Component, inject, AfterViewInit, ViewChild } from '@angular/core';
import { commonProviders } from '../../../../../share/providers/common.provider';

import { MatDialogActions, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Subject, takeUntil } from 'rxjs';
import { MovimentacaoFieldsDialogComponent } from "../movimentacao-fields-dialog/movimentacao-fields-dialog.component";
import { Movimentacao } from '../../../models/movimentacao.model';

@Component({
  selector: 'app-movimentacao-adicionar-dialog',
  standalone: true,
  imports: [
    ...commonProviders,
    MatDialogActions,
    MatDialogContent,
    MatDialogTitle,
    MovimentacaoFieldsDialogComponent
  ],
  templateUrl: './movimentacao-adicionar-dialog.component.html',
  styleUrl: './movimentacao-adicionar-dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoAdicionarDialogComponent {
  
  @ViewChild(MovimentacaoFieldsDialogComponent) fieldsComponent!: MovimentacaoFieldsDialogComponent;

  readonly dialogRef = inject(MatDialogRef<MovimentacaoAdicionarDialogComponent>);

  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  protected movimentacao: Movimentacao = new Movimentacao();

  private snackBar: MatSnackBar = inject(MatSnackBar)
  private destroy$: Subject<void> = new Subject();

  clickAdicionar(): void {
    let actionFechar = () => {
      this.dialogRef.close(true);
    }

    this.salvar(actionFechar);
  }

  clickAdicionarENovo(): void {
    let actionLimparCampos = () => {
      this.movimentacao.Descricao = '';
      this.movimentacao.Observacao = '';
      this.movimentacao.Valor = 0;
    };

    this.salvar(actionLimparCampos)
  }
  
  clickFechar(): void {
    this.dialogRef.close(false);
  }

  private salvar(action: () => void) {
    if (!this.fieldsComponent.validarCampos()) { return; }

    this.movimentacaoService.adicionar(this.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
      this.snackBar.open('Movimentação adicionada!');
      action();
    });
    
  }
}
