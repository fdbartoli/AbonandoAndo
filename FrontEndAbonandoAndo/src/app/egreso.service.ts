import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Iegreso } from './models/Iegreso';

@Injectable({
  providedIn: 'root'
})
export class EgresoService {

  constructor(private http:HttpClient) { }

  readonly APIUrl = 'https://localhost:7084/api';

  getCobrosCuil(cuil: string){
    return this.http.get<Iegreso[]>(this.APIUrl + `/Egreso/${cuil}`);
  }

  addCobro(data:any){
    return this.http.post(this.APIUrl + "/Egreso", data);
  }

}
