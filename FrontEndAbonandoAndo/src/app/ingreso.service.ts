import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Iingreso } from './models/Iingreso';

@Injectable({
  providedIn: 'root'
})
export class IngresoService {

  constructor(private http:HttpClient) { }

  readonly clientAPIUrl = 'https://localhost:7106/api';

  getPagosCuil(cuil: string){
    return this.http.get<Iingreso[]>(this.clientAPIUrl + `/Ingreso/${cuil}`);
  }
}
