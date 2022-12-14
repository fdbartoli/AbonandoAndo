import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IngresoService } from 'src/app/ingreso.service';
import { Iingreso } from 'src/app/models/Iingreso';



@Component({
  selector: 'app-ingreso',
  templateUrl: './ingreso.component.html',
  styleUrls: ['./ingreso.component.css']
})
export class IngresoComponent implements OnInit {

  constructor(private service: IngresoService) { }

  dataSource! : Iingreso [];
    ingreso   : Iingreso ={
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
