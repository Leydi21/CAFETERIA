import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ProductosService } from '../../services/productos.service';

@Component({
  selector: 'app-modal-alta-producto',
  standalone: true,
  imports: [
    MatFormFieldModule, 
    MatInputModule, 
    MatSelectModule,
  ],
  templateUrl: './modal-alta-producto.component.html',
  styleUrl: './modal-alta-producto.component.scss'
})
export class ModalAltaProductoComponent {
  dataTypeProduct: any;
  newProduct = {};

  constructor(
    private productService: ProductosService,
  ) {  }

  ngOnInit(): void {
    // this.data = productos
    this.productService.getAllTypeProducts().subscribe({
      next: (response) => {
        this.dataTypeProduct = response.body;
        console.log(this.dataTypeProduct)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }


  add(){
    console.log('llllllll',this.newProduct)
  }
}
