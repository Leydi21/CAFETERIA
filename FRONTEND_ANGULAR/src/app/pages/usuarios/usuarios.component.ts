import { Component } from '@angular/core';
import { UsuariosService } from '../../services/usuarios.service';
import { CardUsersComponent } from './card-users/card-users.component';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { usuarios } from '../../interfaces/users.interface';

@Component({
  selector: 'app-usuarios',
  standalone: true,
  imports: [
    CommonModule,
    CardUsersComponent,
    MatProgressSpinnerModule
  ],
  templateUrl: './usuarios.component.html',
  styleUrl: './usuarios.component.scss'
})
export class UsuariosComponent {
  dataUsuarios: any;
  showLoading: boolean = true;

  constructor(
    private usuarioService: UsuariosService
  ) {  }

  ngOnInit(): void {
    this.usuarioService.getAllUsers().subscribe({
      next: (response) => {
        this.dataUsuarios = response.body;
        console.log(this.dataUsuarios)
        this.showLoading = false;
      },
      error: (error) => {
        console.log(error)
        this.showLoading = false;
      }
    })
  }
}
