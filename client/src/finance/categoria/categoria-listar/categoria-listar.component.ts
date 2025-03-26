import { AppService } from './../../../app/app.service';
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';

@Component({
  selector: 'app-categoria-listar',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './categoria-listar.component.html',
  styleUrl: './categoria-listar.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CategoriaListarComponent {

  private appService: AppService = inject(AppService);

  constructor() {
    this.appService.definirTitulo('Categoria')
    this.appService.definirNevagacao(['Financeiro', 'Categoria', 'Listar'])
  }
 }
