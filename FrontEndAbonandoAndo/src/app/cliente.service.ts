import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {


  readonly clientAPIUrl = 'https://localhost:7231/api';

  constructor(private http:HttpClient) { }

  getClienteList():Observable<any[]>{
    return this.http.get<any>(this.clientAPIUrl + '/Cliente');

  }

  addCliente(data:any){
    return this.http.post(this.clientAPIUrl + "/Cliente", data);
  }

}
