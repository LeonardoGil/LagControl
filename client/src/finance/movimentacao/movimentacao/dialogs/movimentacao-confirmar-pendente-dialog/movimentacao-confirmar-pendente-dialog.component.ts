import { ChangeDetectionStrategy, Component, inject, OnInit, ViewChild } from '@angular/core';
import { MovimentacaoFieldsDialogComponent } from "../movimentacao-fields-dialog/movimentacao-fields-dialog.component";
import { commonProviders } from '../../../../../share/providers/common.provider';
import { dialogProvider } from '../../../../../share/providers/dialog.provider';
import { MovimentacaoService } from '../../../services/movimentacao.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subject, takeUntil } from 'rxjs';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Movimentacao } from '../../../models/movimentacao.model';

@Component({
  selector: 'app-movimentacao-confirmar-pendente-dialog',
  standalone: true,
  imports: [
    ...commonProviders,
    ...dialogProvider,

    MovimentacaoFieldsDialogComponent
],
  templateUrl: './movimentacao-confirmar-pendente-dialog.component.html',
  styleUrl: './movimentacao-confirmar-pendente-dialog.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoConfirmarPendenteDialogComponent implements OnInit {
  readonly dialogRef = inject(MatDialogRef<MovimentacaoConfirmarPendenteDialogComponent>);
  protected movimentacaoService: MovimentacaoService = inject(MovimentacaoService)
  private snackBar: MatSnackBar = inject(MatSnackBar)
  private destroy$: Subject<void> = new Subject();

  protected movimentacao: Movimentacao = inject(MAT_DIALOG_DATA);

  @ViewChild(MovimentacaoFieldsDialogComponent) fieldsComponent!: MovimentacaoFieldsDialogComponent;

  ngOnInit(): void {
  } 

  clickSalvar(): void {
    
    if (!this.fieldsComponent.validarCampos()) { return }    

    this.movimentacao.Pendente = false

    this.movimentacaoService.confirmarPendente(this.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
      this.snackBar.open('Movimentação confirmada!', 'Ok')
    });
    

    this.dialogRef.close(true);
  }

  clickFechar(): void {
    this.dialogRef.close(false);
  }
}
