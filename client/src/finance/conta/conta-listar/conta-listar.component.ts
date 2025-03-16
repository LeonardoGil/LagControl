import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { commonProviders } from '../../../share/providers/common.provider';
import { MatExpansionModule, MatAccordion } from '@angular/material/expansion';
import { ContaService } from '../services/conta.service';
import { ContaSaldo } from '../models/conta-saldo.model';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-conta-listar',
  standalone: true,
  imports: [
    ...commonProviders,
    MatExpansionModule
  ],
  templateUrl: './conta-listar.component.html',
  styleUrl: './conta-listar.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ContaListarComponent { 
  protected contas: ContaSaldo[] = []
  private contaService: ContaService = inject(ContaService)
  
  private destroy$: Subject<void> = new Subject();

  constructor() {
    this.contaService.listarSaldo().pipe(takeUntil(this.destroy$)).subscribe(contas => this.contas = contas);
  }

  protected visualizarUltimaMovimentacao(conta: ContaSaldo): string {
    if (!conta.DataUltimaMovimentacao) {
      return '-'
    }

    return new Date(conta.DataUltimaMovimentacao).toLocaleDateString('pt-BR')
  }
}