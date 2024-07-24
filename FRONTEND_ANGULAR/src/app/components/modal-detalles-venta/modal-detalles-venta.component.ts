import { DataSource } from '@angular/cdk/collections';
import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogContent, MatDialogModule, MatDialogTitle } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-modal-detalles-venta',
  standalone: true,
  imports: [
    MatDialogModule, MatButtonModule,
    MatDialogTitle, MatDialogContent,
    MatIconModule, MatTableModule,
    MatFormFieldModule, MatInputModule,
  ],
  templateUrl: './modal-detalles-venta.component.html',
  styleUrl: './modal-detalles-venta.component.scss'
})
export class ModalDetallesVentaComponent {
  dataSource!: MatTableDataSource<any>;
  totalVenta!: any;
  displayedColumns: string[] = [
    "producto_id",
    "precio_unitario",
    "cantidad",
    "subtotal",
  ];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  
  ngOnInit(): void {
    if (!Array.isArray(this.data)) {
      this.data = [this.data];
    }
    this.totalVenta = this.data.reduce((acc: any, element: { subtotal: any; }) => acc + element.subtotal, 0);

    console.log('data detalles:',this.data)
    console.log('data totalVenta:',this.totalVenta)
    this.dataSource = new MatTableDataSource(this.data);
  }
}