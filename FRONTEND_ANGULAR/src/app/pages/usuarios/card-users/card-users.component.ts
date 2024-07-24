import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-card-users',
  standalone: true,
  imports: [
    RouterLink,
    MatCardModule,
    MatProgressBarModule,
    MatIconModule,
    CommonModule
  ],
  templateUrl: './card-users.component.html',
  styleUrl: './card-users.component.scss'
})
export class CardUsersComponent {
  @Input({required: true}) dataUsuarios: any;
  constructor(){
    console.log('data desde carduser:',this.dataUsuarios)
  }
}
