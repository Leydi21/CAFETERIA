import { Component } from '@angular/core';
import { ProductosService } from '../../services/productos.service';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card/card.component';
import { productos } from '../../interfaces/products.interface';

@Component({
  selector: 'app-productos',
  standalone: true,
  imports: [
    CommonModule,
    CardComponent
  ],
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.scss'
})
export class ProductosComponent {
  data: any;

  constructor(
    private productService: ProductosService
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
}
