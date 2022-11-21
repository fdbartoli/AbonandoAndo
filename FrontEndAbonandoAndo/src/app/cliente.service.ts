import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {


  readonly clientAPIUrl = 'https://localhost:7084/api';

  constructor(private http:HttpClient) { }

  getClienteList():Observable<any[]>{
    return this.http.get<any>(this.clientAPIUrl + '/Cliente');

  }

  addCliente(data:any){
    return this.http.post(this.clientAPIUrl + "/Cliente", data);
  }

  updateCiente(id:number, data:any){
    return this.http.put(this.clientAPIUrl + `/Cliente/${id}`, data);
  }

  deleteCliente(id:number){
    return this.http.delete(this.clientAPIUrl + `/Cliente/${id}`);
  }
}
