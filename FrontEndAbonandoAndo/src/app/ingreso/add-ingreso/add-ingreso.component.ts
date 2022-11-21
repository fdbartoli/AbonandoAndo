import { Component, Input, OnInit } from '@angular/core';
import { IngresoService } from 'src/app/ingreso.service';
import { Iingreso } from 'src/app/models/Iingreso';

@Component({
  selector: 'app-add-ingreso',
  templateUrl: './add-ingreso.component.html',
  styleUrls: ['./add-ingreso.component.css']
})
export class AddIngresoComponent implements OnInit {

  constructor(private service:IngresoService) { }

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
    
    this.service.addPago(this.ingreso).subscribe(response => {
        alert ("Registro ingresado con éxito!")
        console.log("response", response)      
    },
    (error) => {
        alert("Error! Vuelva a intentarlo.");
    });  
  }

}
