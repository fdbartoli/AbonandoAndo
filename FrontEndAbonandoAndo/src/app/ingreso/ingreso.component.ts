import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IngresoService } from '../ingreso.service';
import { Iingreso } from '../models/Iingreso';

@Component({
  selector: 'app-ingreso',
  templateUrl: './ingreso.component.html',
  styleUrls: ['./ingreso.component.css']
})
export class IngresoComponent implements OnInit {

  constructor(private service: IngresoService) { }

  displayedColumns: string []= ["detalle", "fecha", "id", "idCliente", "monto"];
  dataSource! : Iingreso [];
    ingreso : Iingreso ={
    detalle: "asdfasfd",
    fecha: new Date (),
    id: 0,
    idCliente: 0,
    monto: 0,
  }

  cuil: number = 1;

  ngOnInit(): void {
  }


  searchIngresoCuil(){
    console.log("ingreso antes de response", this.ingreso)
    this.service.getPagosCuil("11111").subscribe(response =>{
      this.dataSource = response;
    console.log("response", response)
    console.log("ingreso despues", this.dataSource);
    },
    (error) => {
        alert("error");
    });

    // this.dataSource = this.service.getPagosCuil("33333");
    // console.log("despues click",a)
    
  }

}
