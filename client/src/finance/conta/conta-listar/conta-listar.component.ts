import { ChangeDetectionStrategy, ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
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
export class ContaListarComponent implements OnInit { 
  protected contas: ContaSaldo[] = []
  private contaService: ContaService = inject(ContaService)
  private cdr: ChangeDetectorRef = inject(ChangeDetectorRef);
  private destroy$: Subject<void> = new Subject();

  ngOnInit(): void {
    this.contaService.listarSaldo().pipe(takeUntil(this.destroy$)).subscribe(contas => {
      this.contas = contas
      this.cdr.detectChanges()
    });
  }

  protected visualizarUltimaMovimentacao(dataUltimaMovimentacao: Date | null): string {
    if (!dataUltimaMovimentacao) {
      return '-'
    }

    return new Date(dataUltimaMovimentacao).toLocaleDateString('pt-BR')
  }

  protected ultimaMovimentacao(): string {
    const contasSort = this.contas.sort((a, b) => {
      const dataA = a.DataUltimaMovimentacao ? new Date(a.DataUltimaMovimentacao).getTime() : 0;
      const dataB = b.DataUltimaMovimentacao ? new Date(b.DataUltimaMovimentacao).getTime() : 0
      return dataB - dataA;
    });
      
    return this.visualizarUltimaMovimentacao(contasSort[0]?.DataUltimaMovimentacao ?? null);
  }

  protected saldoTotal(): number {
    return this.contas.reduce((acc, conta) => acc + conta.Saldo, 0)
  }
  
  protected saldoPrevistoTotal(): number {
    return this.contas.reduce((acc, conta) => acc + conta.SaldoPrevisto, 0)
  }
}