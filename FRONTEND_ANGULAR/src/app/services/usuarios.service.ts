import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {
  private readonly _http = inject(HttpClient)
  constructor() { }

  getAllUsers():Observable<any>{
    return this._http.get('https://localhost:7154/api/Usuarios')
  }
}
