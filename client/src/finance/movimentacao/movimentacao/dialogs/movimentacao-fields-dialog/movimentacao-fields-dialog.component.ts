import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { commonProviders } from '../../../../../share/providers/common.provider';
import { Movimentacao } from '../../../models/movimentacao.model';
import { ContaService } from '../../../../conta/services/conta.service';
import { Subject, takeUntil } from 'rxjs';
import { Categoria } from '../../../../categoria/models/categoria.model';
import { CategoriaService } from '../../../../categoria/services/categoria.service';
import { Conta } from '../../../../conta/models/conta.model';
import { TipoMovimentacaoOptions } from '../../../models/tipoMovimentacao.model';

@Component({
  selector: 'app-movimentacao-fields-dialog',
  standalone: true,
  imports: [
    CommonModule,
    commonProviders
  ],
  templateUrl: './movimentacao-fields-dialog.component.html',
  styleUrl: './movimentacao-fields-dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MovimentacaoFieldsDialogComponent implements OnInit {
  public movimentacao: Movimentacao = new Movimentacao();

  protected contaService: ContaService = inject(ContaService)
  protected categoriaService: CategoriaService = inject(CategoriaService)

  protected tipoMovimentacaoOptions = TipoMovimentacaoOptions.filter(x => x.value != null)
  protected categorias: Categoria[] = [];
  protected contas: Conta[] = [];

  private destroy$: Subject<void> = new Subject();

  constructor() {
  }

  ngOnInit(): void {
    this.carregarConta();
    this.carregarCategoria();
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
