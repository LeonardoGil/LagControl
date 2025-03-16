import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MenuComponent } from "./menu/menu.component";
import { commonProviders } from '../share/providers/common.provider';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  imports: [RouterOutlet,
    MatSidenavModule,
    MatToolbarModule,

    MenuComponent,
    ...commonProviders]
})
export class AppComponent {
  

}
