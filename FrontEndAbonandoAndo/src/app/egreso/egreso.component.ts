import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IngresoService } from 'src/app/ingreso.service';
import { Iingreso } from 'src/app/models/Iingreso';
import { Iegreso } from '../models/Iegreso';



@Component({
  selector: 'app-egreso',
  templateUrl: './egreso.component.html',
  styleUrls: ['./egreso.component.css']
})
export class EgresoComponent implements OnInit {

  constructor(private service: IngresoService) { }

  dataSource! : Iegreso [];
    ingreso   : Iegreso ={
    detalle   : "",
    fecha     : "",
    id        : 0,
    idCliente : 0,
    monto     : 0,
  }

  cuil: string = "0";
  activatedAddIngresoComponent: boolean = false;

  ngOnInit(): void {
  }


  searchIngresoCuil(){
    this.service.getPagosCuil(this.cuil).subscribe(response =>{
      this.dataSource = response;
    },
    (error) => {
        alert("No se encontraron registros con este cuil, vuelva a intentarlo!");
    });    
  }

  modalAdd(){
    this.activatedAddIngresoComponent = true;
  }

  modalClose(){
    this.activatedAddIngresoComponent=false
  }

}
