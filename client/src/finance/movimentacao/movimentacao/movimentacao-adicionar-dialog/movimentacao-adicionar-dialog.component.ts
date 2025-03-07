import { Categoria } from './../../../categoria/models/categoria.model';
import { ContaService } from './../../../conta/services/conta.service';
import { CategoriaService } from './../../../categoria/services/categoria.service';
import { MovimentacaoService } from './../../services/movimentacao.service';
import { Movimentacao } from './../../models/movimentacao.model';
import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { commonProviders } from '../../../../share/providers/common.provider';

import {
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MAT_DATE_LOCALE, provideNativeDateAdapter } from '@angular/material/core';
import { Subject, takeUntil } from 'rxjs';
import { Conta } from '../../../conta/models/conta.model';
import { TipoMovimentacaoOptions } from '../../models/tipoMovimentacao.model';

@Component({
  selector: 'app-movimentacao-adicionar-dialog',
  standalone: true,
  imports: [
    commonProviders,

    MatDialogActions,
    MatDialogContent,
    MatDialogTitle,
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
export class MovimentacaoAdicionarDialogComponent implements OnInit {

  readonly dialogRef = inject(MatDialogRef<MovimentacaoAdicionarDialogComponent>);
  movimentacao: Movimentacao = new Movimentacao();

  protected contaService: ContaService = inject(ContaService)
  protected categoriaService: CategoriaService = inject(CategoriaService)
  protected movimentacaoService: MovimentacaoService = inject(MovimentacaoService)

  protected tipoMovimentacaoOptions = TipoMovimentacaoOptions.filter(x => x.value != null)
  protected categorias: Categoria[] = [];
  protected contas: Conta[] = [];
  private destroy$: Subject<void> = new Subject();
  

  ngOnInit(): void {
    this.carregarConta();
    this.carregarCategoria();
  }

  ClickAdicionar(): void  {
    if (this.movimentacao.Descricao == '' ||
        this.movimentacao.ContaId == '' ||
        this.movimentacao.CategoriaId == '' ||
        this.movimentacao.Valor == 0) {
      return
    }

    this.movimentacaoService.Adicionar(this.movimentacao).subscribe(() => {
      this.dialogRef.close(true);  
    })
  }

  Fechar(): void {
    this.dialogRef.close(false);
  }

  private carregarConta(): void {
    this.contaService.Listar()
                     .pipe(takeUntil(this.destroy$))
                     .subscribe((contas: Conta[]) => this.contas = contas)
  }

  private carregarCategoria(): void {
    this.categoriaService.Listar()
                         .pipe(takeUntil(this.destroy$))
                         .subscribe((categorias: Categoria[]) => this.categorias = categorias)
  }
}
