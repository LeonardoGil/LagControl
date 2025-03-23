import { AppService } from './app.service';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MenuComponent } from "./menu/menu.component";
import { commonProviders } from '../share/providers/common.provider';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [RouterOutlet,
    MatSidenavModule,
    MatToolbarModule,

    MenuComponent,
    ...commonProviders]
})
export class AppComponent implements OnInit {
  
  protected AppService: AppService = inject(AppService)  
  protected titulo: string = ''
  protected navegacao: string[] = []

  ngOnInit(): void {
    this.AppService.titulo$.subscribe(titulo => this.titulo = titulo);
    this.AppService.navegacao$.subscribe(navegacao => this.navegacao = navegacao);
  }
}
