import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  readonly clientAPIUrl = 'https://localhost:7084/api';

  constructor(private http:HttpClient) { }

  getEmpresaList():Observable<any[]>{
    return this.http.get<any>(this.clientAPIUrl + '/Empresa');

  }

  addEmpresa(data:any){
    return this.http.post(this.clientAPIUrl + "/Empresa", data);
  }

  updateEmpresa(id:number, data:any){
    return this.http.put(this.clientAPIUrl + `/Empresa/${id}`, data);
  }

  deleteEmpresa(id:number){
    return this.http.delete(this.clientAPIUrl + `/Empresa/${id}`);
  }
}
