import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComprasService {
  private readonly _http = inject(HttpClient)
  constructor() { }

  getAllCompras():Observable<any>{
    return this._http.get('https://localhost:7154/api/Compras')
  }
}
