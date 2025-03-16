import { ChangeDetectionStrategy, Component, Input, OnInit, ViewChild, inject } from '@angular/core';
import { commonProviders } from '../../../../../share/providers/common.provider';
import { Movimentacao } from '../../../models/movimentacao.model';
import { ContaService } from '../../../../conta/services/conta.service';
import { Subject, takeUntil } from 'rxjs';
import { Categoria } from '../../../../categoria/models/categoria.model';
import { CategoriaService } from '../../../../categoria/services/categoria.service';
import { Conta } from '../../../../conta/models/conta.model';
import { TipoMovimentacaoOptions } from '../../../models/tipoMovimentacao.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-movimentacao-fields-dialog',
  standalone: true,
  imports: [
    ...commonProviders
  ],
  templateUrl: './movimentacao-fields-dialog.component.html',
  styleUrl: './movimentacao-fields-dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoFieldsDialogComponent implements OnInit {
  @ViewChild(NgForm) form!: NgForm;
  
  @Input() tipoDisable: boolean = false
  @Input() pendenteDisable: boolean = false
  @Input({ required: true }) movimentacao!: Movimentacao

  protected contaService: ContaService = inject(ContaService)
  protected categoriaService: CategoriaService = inject(CategoriaService)

  protected tipoMovimentacaoOptions = TipoMovimentacaoOptions.filter(x => x.value != null)

  protected categorias: Categoria[] = [];
  protected contas: Conta[] = [];

  private destroy$: Subject<void> = new Subject();

  ngOnInit(): void {
    this.carregarConta();
    this.filtrarCategoria();
  } 

  private carregarConta(): void {
    this.contaService.contas$
                     .pipe(takeUntil(this.destroy$))
                     .subscribe((contas: Conta[]) => this.contas = contas)
  }

  private filtrarCategoria(): void {
    const tipo = this.movimentacao.Tipo as number;
    this.categorias = this.categoriaService.categorias.filter(x => (x.Tipo as number) == tipo)
  }

  protected changeTipo(): void {
    this.movimentacao.CategoriaId = '';
    this.filtrarCategoria();
  }

  public validarCampos(): boolean {
    Object.values(this.form.controls).forEach((control) => control.markAsTouched({ onlySelf: true }))
    return !this.form.invalid
  }
}