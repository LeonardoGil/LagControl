import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import {
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { commonProviders } from '../providers/common.provider';

@Component({
  selector: 'app-confirmar-dialog',
  standalone: true,
  imports: [
    ...commonProviders, 
    CommonModule, 
    MatDialogActions, 
    MatDialogContent, 
    MatDialogTitle
  ],
  styles: '',
  template: `<h2 mat-dialog-title>Adicionar</h2>
    <mat-dialog-content>
      <span>{{ data.Mensagem }}</span>
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button class="!bg-red-500" (click)="dialogRef.close(false)">Não</button>
      <button mat-button class="!bg-green-500" (click)="dialogRef.close(true)" cdkFocusInitial>
        Confirmar
      </button>
    </mat-dialog-actions> `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ConfirmarDialogComponent {
  
  protected readonly dialogRef = inject(MatDialogRef<ConfirmarDialogComponent>);
  protected data: ConfirmarDialogModel = inject(MAT_DIALOG_DATA);
}

export interface ConfirmarDialogModel {
  Mensagem: string
}