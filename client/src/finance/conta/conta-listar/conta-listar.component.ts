import { AfterViewInit, ChangeDetectionStrategy, ChangeDetectorRef, Component, inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
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
})
export class ContaListarComponent implements OnInit, OnDestroy, AfterViewInit {
  
  @ViewChild(MatAccordion) accordion!: MatAccordion

  protected contas: ContaSaldo[] = []
  protected mostrar: boolean = false
  
  private contaService: ContaService = inject(ContaService)
  private destroy$: Subject<void> = new Subject();

  ngOnInit(): void {
    this.contaService.listarSaldo().pipe(takeUntil(this.destroy$)).subscribe(contas => {
      this.contas = contas
    });
  }

  ngAfterViewInit(): void {
    this.accordion.closeAll();
  } 

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }

  protected clickVisualizar(): void {
    this.mostrar = !this.mostrar

    if (this.mostrar) {
      this.accordion.openAll();
    }
    else {
      this.accordion.closeAll();
    }
  }

  protected visualizarUltimaMovimentacao(dataUltimaMovimentacao: Date | null): string {
    if (!this.mostrar || !dataUltimaMovimentacao) {
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
      
    if (!this.mostrar) {
      return ' - '
    }

    return this.visualizarUltimaMovimentacao(contasSort[0]?.DataUltimaMovimentacao ?? null);
  }

  protected saldoTotal(): number {
    if (!this.mostrar) {
      return 0
    }

    return this.contas.reduce((acc, conta) => acc + conta.Saldo, 0)
  }
  
  protected saldoPrevistoTotal(): number {
    if (!this.mostrar) {
      return 0
    }

    return this.contas.reduce((acc, conta) => acc + conta.SaldoPrevisto, 0)
  }
}