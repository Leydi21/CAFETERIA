import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ComprasService } from '../../services/compras.service';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';

export interface UserData {
  id: string;
  name: string;
  progress: string;
  fruit: string;
}

@Component({
  selector: 'app-compras',
  standalone: true,
  templateUrl: './compras.component.html',
  styleUrl: './compras.component.scss',
  imports: [
    CommonModule,
    MatIconModule,
    MatTooltipModule,
    MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule],
})

export class ComprasComponent implements OnInit, AfterViewInit {
  dataSource!: MatTableDataSource<any>;
  showLoading: boolean = true;
  displayedColumns: string[] = [
    "compra_id",
    "usuario_id",
    "fechaCompra",
    "total",
    "acciones"
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private comprasService: ComprasService
  ) {
  }

  ngOnInit(): void {
    this.comprasService.getAllCompras().subscribe({
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
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
    // console.log('***dataSource:',this.dataSource)
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  VerDetalleCompra(){
    console.log('VerDetalleCompra')
  }

  EditarCompra(){
    console.log('EditarCompra')
  }

  EliminarCompra(){
    console.log('EliminarCompra')
  }
}