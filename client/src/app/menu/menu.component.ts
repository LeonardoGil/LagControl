import { ChangeDetectionStrategy, Component } from '@angular/core';
import { commonProviders } from '../../share/providers/common.provider';
import { RouterLink } from '@angular/router';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    MatExpansionModule,
    ...commonProviders,
    RouterLink,
  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MenuComponent { 

}
