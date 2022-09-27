import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OperacionService {


  readonly OperacionAPIUrl = 'https://localhost:7231/api';

  constructor(private http:HttpClient) { }

  GetOperacionList():Observable<any[]>{
    return this.http.get<any>(this.OperacionAPIUrl + '/Operacion');

  }

  addOperacion(data:any){
    return this.http.post(this.OperacionAPIUrl + "/Operacion", data);
  }

  updateOperacion(id:number, data:any){
    return this.http.put(this.OperacionAPIUrl + `/Operacion/${id}`, data);
  }

  deleteOperacion(id:number){
    return this.http.delete(this.OperacionAPIUrl + `/Operacion/${id}`);
  }
}
