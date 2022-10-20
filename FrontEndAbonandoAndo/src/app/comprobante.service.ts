import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComprobanteService {

  readonly clientAPIUrl = 'https://localhost:7231/api';

  constructor(private http:HttpClient) { }

  getComprobanteList():Observable<any[]>{
    return this.http.get<any>(this.clientAPIUrl + '/Comprobante');

  }

  addComprobante(data:any){
    return this.http.post(this.clientAPIUrl + "/Comprobante", data);
  }

  updateComprobante(id:number, data:any){
    return this.http.put(this.clientAPIUrl + `/Comprobante/${id}`, data);
  }

  deleteComprobante(id:number){
    return this.http.delete(this.clientAPIUrl + `/Comprobante/${id}`);
  }
}
