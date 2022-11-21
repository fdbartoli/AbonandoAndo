import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Iingreso } from './models/Iingreso';

@Injectable({
  providedIn: 'root'
})
export class IngresoService {

  constructor(private http:HttpClient) { }

  readonly APIUrl = 'https://localhost:7084/api';

  getPagosCuil(cuil: string){
    return this.http.get<Iingreso[]>(this.APIUrl + `/Ingreso/${cuil}`);
  }

  addPago(data:any){
    return this.http.post(this.APIUrl + "/Ingreso", data);
  }

}
