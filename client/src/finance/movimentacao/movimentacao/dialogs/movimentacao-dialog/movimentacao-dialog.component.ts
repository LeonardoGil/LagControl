import { Movimentacao } from './../../../models/movimentacao.model';
import { MovimentacaoService } from '../../../services/movimentacao.service';
import { Component, inject, ViewChild, OnDestroy, OnInit } from '@angular/core';
import { commonProviders } from '../../../../../share/providers/common.provider';

import { MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar'
import { Subject, takeUntil } from 'rxjs';
import { MovimentacaoFieldsDialogComponent } from "../movimentacao-fields-dialog/movimentacao-fields-dialog.component";

@Component({
  selector: 'app-movimentacao-dialog',
  standalone: true,
  imports: [
    ...commonProviders,
    MatDialogActions,
    MatDialogContent,
    MatDialogTitle,
    MovimentacaoFieldsDialogComponent
  ],
  templateUrl: './movimentacao-dialog.component.html',
  styleUrl: './movimentacao-dialog.component.css'
})
export class MovimentacaoDialogComponent implements OnInit, OnDestroy {
  
  @ViewChild(MovimentacaoFieldsDialogComponent) fieldsComponent!: MovimentacaoFieldsDialogComponent;

  readonly dialogRef: MatDialogRef<any, any> = inject(MatDialogRef<MovimentacaoDialogComponent>);
  readonly snackBar: MatSnackBar = inject(MatSnackBar);
  
  protected data: any = inject(MAT_DIALOG_DATA);
  protected movimentacao: Movimentacao = new Movimentacao();
  protected acao!: AcaoMovimentacaoEnum;

  private movimentacaoService: MovimentacaoService = inject(MovimentacaoService);
  private destroy$: Subject<void> = new Subject();

  protected titulo: string = '';
  protected desabilitar: boolean = false;
  private atualizar: boolean = false;
  
  ngOnInit(): void {

    this.acao = this.data.acao;
    this.carregar();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }

  clickSalvar(): void {
    let actionFechar = () => {
      this.dialogRef.close(this.atualizar);
    }

    this.salvar(actionFechar);
  }

  clickAdicionarENovo(): void {
    let actionLimparCampos = () => {
      this.movimentacao.Id = '';
      this.movimentacao.Observacao = '';
      this.movimentacao.Valor = 0;
    };

    this.salvar(actionLimparCampos)
  }
  
  clickFechar(): void {
    this.dialogRef.close(this.atualizar);
  }

  private carregar() : void {

    switch (this.acao) {
      case AcaoMovimentacaoEnum.Adicionar:
        this.titulo = 'Adicionar movimentação';
        break;

      case AcaoMovimentacaoEnum.Editar:
        this.titulo = 'Editar movimentação';
        this.movimentacao = this.data.movimentacao;
        break;

      case AcaoMovimentacaoEnum.ConfirmarPendente:
        this.titulo = 'Confirmar movimentação pendente';
        this.movimentacao = this.data.movimentacao;
        this.desabilitar = true;
        break;
    }
  }

  private salvar(action: () => void) {
    
    if (!this.fieldsComponent.validarCampos()) { 
      return; 
    }

    this.atualizar = true;

    switch (this.acao) {
      case AcaoMovimentacaoEnum.Adicionar:
        this.movimentacaoService.adicionar(this.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
          this.snackBar.open('Movimentação adicionada!', 'Ok');
          action();          
        });    
        break;

      case AcaoMovimentacaoEnum.Editar:
        this.movimentacaoService.editar(this.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
          this.snackBar.open('Movimentação editada!', 'Ok');
          action();          
        });    
        break;

      case AcaoMovimentacaoEnum.ConfirmarPendente:
        this.movimentacaoService.confirmarPendente(this.movimentacao).pipe(takeUntil(this.destroy$)).subscribe(() => {
          this.snackBar.open('Movimentação confirmada!', 'Ok')
          action();
        });
        break;
    }
  }
}

export enum AcaoMovimentacaoEnum {
  Adicionar = 0,
  Editar = 1,
  ConfirmarPendente = 2
}
