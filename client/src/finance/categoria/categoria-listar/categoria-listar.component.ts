import { commonProviders } from './../../../share/providers/common.provider';
import { AppService } from './../../../app/app.service';
import { Component, OnDestroy, OnInit, ViewChild, inject } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { Categoria } from '../models/categoria.model';
import { CategoriaService } from '../services/categoria.service';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-categoria-listar',
  standalone: true,
  imports: [
    ...commonProviders,
  ],
  templateUrl: './categoria-listar.component.html',
  styleUrl: './categoria-listar.component.css',
})
export class CategoriaListarComponent implements OnInit, OnDestroy {
  
  @ViewChild(MatAccordion) accordion!: MatAccordion

  protected categorias: Categoria[] = []
  protected mostrar: boolean = false
  
  private categoriaService: CategoriaService = inject(CategoriaService);
  private appService: AppService = inject(AppService);
  private destroy$: Subject<void> = new Subject();

  constructor() {
    this.appService.definirTitulo('Categoria')
    this.appService.definirNevagacao(['Financeiro', 'Categoria', 'Listar'])
  }

  ngOnInit(): void {
    this.categoriaService.listar().pipe(takeUntil(this.destroy$)).subscribe(categorias => {
      this.categorias = categorias
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
 }
