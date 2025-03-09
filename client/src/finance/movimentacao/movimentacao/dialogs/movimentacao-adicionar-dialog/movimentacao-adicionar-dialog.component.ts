import { MovimentacaoService } from '../../../services/movimentacao.service';
import { ChangeDetectionStrategy, Component, inject, AfterViewInit, ViewChild } from '@angular/core';
import { commonProviders } from '../../../../../share/providers/common.provider';

import { MatDialogActions, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MAT_DATE_LOCALE, provideNativeDateAdapter } from '@angular/material/core';
import { Subject, takeUntil } from 'rxjs';
import { MovimentacaoFieldsDialogComponent } from "../movimentacao-fields-dialog/movimentacao-fields-dialog.component";

@Component({
  selector: 'app-movimentacao-adicionar-dialog',
  standalone: true,
  imports: [
    commonProviders,
    MatDialogActions,
    MatDialogContent,
    MatDialogTitle,
    MovimentacaoFieldsDialogComponent
],
  providers: [
    provideNativeDateAdapter(),
    {
      provide: MAT_DATE_LOCALE, 
      useValue: 'pt-br'
    }
  ],
  templateUrl: './movimentacao-adicionar-dialog.component.html',
  styleUrl: './movimentacao-adicionar-dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoAdicionarDialogComponent implements AfterViewInit {
  
  @ViewChild(MovimentacaoFieldsDialogComponent) fieldsComponent!: MovimentacaoFieldsDialogComponent;

  readonly dialogRef = inject(MatDialogRef<MovimentacaoAdicionarDialogComponent>);

  protected movimentacaoService: MovimentacaoService = inject(MovimentacaoService)

  private destroy$: Subject<void> = new Subject();

  
  ngAfterViewInit(): void {
  }

  clickAdicionar(): void {
    if (!this.validar()) {
      return;
    }

    this.movimentacaoService.Adicionar(this.fieldsComponent.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
      this.dialogRef.close(true);  
    })
  }

  clickAdicionarENovo(): void {
    if (!this.validar()) {
      return;
    }

    this.movimentacaoService.Adicionar(this.fieldsComponent.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
      this.fieldsComponent.movimentacao.Descricao = '';
      this.fieldsComponent.movimentacao.Observacao = '';
      this.fieldsComponent.movimentacao.Valor = 0;
    })
  }
  
  clickFechar(): void {
    this.dialogRef.close(false);
  }

  private validar(): boolean {
    return !(
      this.fieldsComponent.movimentacao.Descricao == '' ||
      this.fieldsComponent.movimentacao.ContaId == '' ||
      this.fieldsComponent.movimentacao.CategoriaId == '' ||
      this.fieldsComponent.movimentacao.Valor == 0
    )
  }
}
