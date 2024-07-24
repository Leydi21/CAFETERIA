import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VentasService {
  private readonly _http = inject(HttpClient)
  constructor() { }

  getAllVentas():Observable<any>{
    return this._http.get('https://localhost:7154/api/Ventas')
  }

  getDetalleVenta(id: any):Observable<any>{
    return this._http.get('https://localhost:7154/api/Detalle_Ventas/GetById/'+id)
  }

  addVenta(data: any):Observable<any>{
    return this._http.post('https://localhost:7154/api/Ventas',data)
  }

  addDetailsVenta(data: any):Observable<any>{
    return this._http.post('https://localhost:7154/api/Detalle_Ventas',data)
  }

  updateVenta(data: any):Observable<any>{
    return this._http.put('https://localhost:7154/api/Detalle_Ventas',data)
  }

  deleteVenta(data: any):Observable<any>{
    return this._http.get('https://localhost:7154/api/Ventas',data)
  }

  getVentasByMonth(year: number, month: number):Observable<any>{
    return this._http.get('https://localhost:7154/api/Ventas/GetByMonth/'+year+'/'+month)
  }

  getVentasByWeek(year: number, week: number):Observable<any>{
    return this._http.get('https://localhost:7154/api/Ventas/GetByWeek/'+year+'/'+week)
  }

}
