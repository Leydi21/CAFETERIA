import { Component } from '@angular/core';
import { ProductosService } from '../../services/productos.service';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card/card.component';
import { productos } from '../../interfaces/products.interface';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { ModalAltaProductoComponent } from '../../components/modal-alta-producto/modal-alta-producto.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-productos',
  standalone: true,
  imports: [
    CommonModule,
    CardComponent,
    MatIcon,
    MatButton
  ],
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.scss'
})
export class ProductosComponent {
  data: any;

  constructor(
    private productService: ProductosService,
    public dialog: MatDialog,
  ) {  }

  ngOnInit(): void {
    // this.data = productos
    this.productService.getAllProducts().subscribe({
      next: (response) => {
        this.data = response.body;
        console.log(this.data)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  altaProducto() {
    console.log('alta producto');
    const dialogRef = this.dialog.open(ModalAltaProductoComponent, {
      data: '',
    });
  }
}
