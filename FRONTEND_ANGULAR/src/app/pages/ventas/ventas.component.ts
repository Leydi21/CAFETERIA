import { ChangeDetectionStrategy, Component, inject, OnInit, signal, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ComprasService } from '../../services/compras.service';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { VentasService } from '../../services/ventas.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ModalDetallesVentaComponent } from '../../components/modal-detalles-venta/modal-detalles-venta.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { ProductosService } from '../../services/productos.service';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import dayjs from 'dayjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-ventas',
  standalone: true,
  templateUrl: './ventas.component.html',
  styleUrl: './ventas.component.scss',
  imports: [
    CommonModule,
    MatIconModule,
    MatTooltipModule,
    MatDialogModule,
    MatIconModule,
    MatExpansionModule,
    FormsModule,
    MatSelectModule,
    MatButtonModule,
    MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class VentasComponent {
  readonly panelOpenState = signal(false);
  step = signal(0);
  dataSource!: MatTableDataSource<any>;
  showLoading: boolean = true;
  productos: any[] = []; 
  VentaProducto: any = {}; 
  VentaCompleta: any = {}; 
  arrayProductosVentas: any[] = []; 
  displayedColumns: string[] = [
    "venta_id",
    "usuario_id",
    "fechaVenta",
    "total",
    "acciones"
  ];
  displayedColumnsProductos: string[] = [
    "producto_id",
    "precio_unitario",
    "cantidad",
    "subtotal"
  ];
  dataVenta: any;
  selectedProductId: any;
  selectedProductSize: string | undefined = '';
  selectedProductDescription: string | undefined = '';
  selectedProductPrice: any = '';
  selectedProductSabor: string | undefined = '';
  selectedProductUnidad: string | undefined = '';
  cantidad!: number; // Inicializa con 1 para evitar la multiplicación por 0
  subtotal: number = 0;
  totalVenta!: any;
  venta_id!: any;
  dataProductosSelect!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private ventasService: VentasService,
    private productosService: ProductosService,
    public dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.ventasService.getAllVentas().subscribe({
      next: (response) => {
        this.dataSource = response.body;
        // if (response.body.length > 0) {
        //   this.columnNames = Object.keys(response.body[0]);
        // }
        console.log('dataSource:',this.dataSource)
        this.showLoading = false;
      },
      error: (error) => {
        console.log(error)
        this.showLoading = false;
      }
    })

    this.productosService.getAllProducts().subscribe({
      next: (response) => {
        this.productos = response.body;
        console.log('productos:',this.productos)
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onProductSelectionChange(event: any): void {
    const selectedProduct = this.productos.find(producto => producto.producto_id === event.value);
    // console.log('selectedProduct:',selectedProduct)
    this.cantidad = this.cantidad ? this.cantidad : 1;
    this.selectedProductSize = selectedProduct ? selectedProduct.tamanio : '';
    this.selectedProductDescription = selectedProduct ? selectedProduct.descripcion : '';
    this.selectedProductPrice = selectedProduct ? selectedProduct.precio : '';
    this.selectedProductSabor = selectedProduct ? selectedProduct.sabor : '';
    this.selectedProductUnidad = selectedProduct ? selectedProduct.unidad : '';
    this.calculateSubtotal(); // Recalcula el total si se selecciona un nuevo producto
  }

  calculateSubtotal(): void {
    if (this.selectedProductPrice) {
      this.subtotal = this.cantidad * this.selectedProductPrice;
    }
  }

  addProductoForVenta(){
    // this.VentaProducto.venta_id = 1
    this.VentaProducto.producto_id = this.selectedProductId;
    this.VentaProducto.cantidad = this.cantidad;
    this.VentaProducto.precio_unitario = this.selectedProductPrice;
    this.VentaProducto.subtotal = this.subtotal;
    console.log('agregar producto',this.VentaProducto);
    this.addAllProductsVentas(this.VentaProducto);
    this.VentaProducto = {};
    this.limpiarProducto();
  }
  
  addAllProductsVentas(producto:any){
    this.arrayProductosVentas.push(producto)
    console.log('lista de productos',this.arrayProductosVentas)
    this.totalVenta = this.arrayProductosVentas.reduce((acc, element) => acc + element.subtotal, 0);
    console.log('total',this.totalVenta)
    this.dataProductosSelect = new MatTableDataSource(this.arrayProductosVentas);
    console.log('arrayProductosVentas',this.arrayProductosVentas)
  }

  limpiarProducto(){
    this.selectedProductId = '';
    this.selectedProductSize = '';
    this.selectedProductDescription = '';
    this.selectedProductPrice = '';
    this.selectedProductSabor = '';
    this.selectedProductUnidad = '';
    this.cantidad = 0;
    this.subtotal = 0;
  }

  addVenta() {
    this.VentaCompleta.usuario_id = 1;
    this.VentaCompleta.fechaVenta = dayjs().format();
    this.VentaCompleta.total = this.totalVenta;
    this.VentaCompleta.activo = true;
    console.log('realizar venta', this.VentaCompleta);
    this.ventasService.addVenta(this.VentaCompleta).subscribe({
      next: (response) => {
        this.venta_id = response.body.venta_id;
        let itemsProcessed = 0;
        const totalItems = this.arrayProductosVentas.length;
  
        this.arrayProductosVentas.forEach(element => {
          element.venta_id = this.venta_id;
          this.ventasService.addDetailsVenta(element).subscribe({
            next: (response) => {
              console.log('Detalles de cada Venta agregados exitosamente:', response);
              itemsProcessed++;
              if (itemsProcessed === totalItems) {
                Swal.fire({
                  title: "Registro Exitoso!",
                  icon: "success",
                  confirmButtonText: "OK",
                }).then((result) => {
                  /* Read more about isConfirmed, isDenied below */
                  if (result.isConfirmed) {
                    window.location.reload();
                  } 
                });
                // window.alert('Todos los elementos han sido registrados exitosamente.');
              }
            },
            error: (error) => {
              console.log('error al agregar detalles de venta', error);
            }
          });
        });
  
        console.log('Venta agregada exitosamente:', response);
      },
      error: (error) => {
        console.error('Error al agregar la venta:', error);
      }
    });
  }

  cancelVenta() {
    this.limpiarProducto();
    this.totalVenta = 0;
    this.arrayProductosVentas = [];
    this.VentaCompleta = {};
  }
  
  

  VerDetalleVenta(row: any) {
    console.log('VerDetalleVenta', row);
    const id = row.venta_id;
    
    this.ventasService.getDetalleVenta(id).subscribe({
      next: (response) => {
        this.dataVenta = response.body;
        this.dataVenta.total = row.total;
        const dialogRef = this.dialog.open(ModalDetallesVentaComponent, {
          data: this.dataVenta
        });
  
        // Optional: handle afterClose event
        // dialogRef.afterClosed().subscribe(result => {
        //   console.log(`Dialog result: ${result}`);
        // });
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  
  EditarVenta(){
    console.log('EditarVenta')
  }

  EliminarVenta(){
    console.log('EliminarVenta')
  }
}
