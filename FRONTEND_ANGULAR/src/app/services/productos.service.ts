import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {
  private readonly _http = inject(HttpClient)
  constructor() { }

  getAllProducts():Observable<any>{
    return this._http.get('https://localhost:7154/api/Productos')
  }

  getAllTypeProducts():Observable<any>{
    return this._http.get('https://localhost:7154/api/TipoProducto')
  }
}
