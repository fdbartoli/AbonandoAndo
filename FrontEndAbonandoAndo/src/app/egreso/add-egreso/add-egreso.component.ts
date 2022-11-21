import { Component, Input, OnInit } from '@angular/core';
import { EgresoService } from 'src/app/egreso.service';

import { Iingreso } from 'src/app/models/Iingreso';

@Component({
  selector: 'app-add-egreso',
  templateUrl: './add-egreso.component.html',
  styleUrls: ['./add-egreso.component.css']
})
export class AddEgresoComponent implements OnInit {

  constructor(private service:EgresoService) { }

  ngOnInit(): void {
  }

  dataSource! : Iingreso [];
  ingreso   : Iingreso ={
  detalle   : "",
  fecha     : "",
  id        : 0,
  idCliente : 0,
  monto     : 0,
}

  addIngrego(){  
    
    this.service.addCobro(this.ingreso).subscribe(response => {
        alert ("Registro ingresado con éxito!")
        console.log("response", response)      
    },
    (error) => {
        alert("Error! Vuelva a intentarlo.");
    });  
  }

}
