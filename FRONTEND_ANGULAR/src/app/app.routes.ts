import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';
import { ProductosComponent } from './pages/productos/productos.component';
import { ComprasComponent } from './pages/compras/compras.component';
import { VentasComponent } from './pages/ventas/ventas.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent},
    { path: '', component: HomeComponent }, // Ruta para el Home
    { path: 'usuarios', component: UsuariosComponent }, // Ruta para los Usuarios
    { path: 'productos', component: ProductosComponent }, // Ruta para los Usuarios
    { path: 'compras', component: ComprasComponent }, // Ruta para los Usuarios
    { path: 'ventas', component: VentasComponent }, // Ruta para los Usuarios
    // { path: '*', redirectTo: '/', pathMatch: 'full'},
];
