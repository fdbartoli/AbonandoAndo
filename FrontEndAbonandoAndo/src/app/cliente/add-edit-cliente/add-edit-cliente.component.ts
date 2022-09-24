import { Component, Input, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import { ClienteService } from 'src/app/cliente.service';

@Component({
  selector: 'app-add-edit-cliente',
  templateUrl: './add-edit-cliente.component.html',
  styleUrls: ['./add-edit-cliente.component.css']
})
export class AddEditClienteComponent implements OnInit {
  
  clienteList$!:Observable<any[]>;

  constructor(private service:ClienteService) { }

  @Input() cliente:any;

  idCliente:number = 0;
  cuil:number = 0;
  apellidos:string = "";
  nombres:string="";
  domicilio:string="";
  telefono:string="";
  mail:string="";
 
  ngOnInit(): void {

    this.idCliente=this.cliente.idCliente;
    this.cuil=this.cliente.cuil;
    this.apellidos=this.cliente.apellidos;
    this.nombres=this.cliente.nombres;
    this.domicilio=this.domicilio="";
    this.telefono=this.cliente.telefono;
    this.mail=this.cliente.mail;
    this.clienteList$ = this.service.getClienteList();

  }

  addCliente(){
    var cliente ={
      cuil:this.cuil,
      apellidos:this.apellidos,
      nombres:this.nombres,
      domicilio:this.domicilio,
      telefono:this.telefono,
      mail:this.mail,
    }
    this.service.addCliente(cliente).subscribe(res =>{
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
      if(showAddSuccess){
        showAddSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showAddSuccess){
          showAddSuccess.style.display = "none";
        }
      }, 4000);
    });
  }

  updateCliente(){
    var cliente ={
      idCliente:this.idCliente,
      cuil:this.cuil,
      apellidos:this.apellidos,
      nombres:this.nombres,
      domicilio:this.domicilio,
      telefono:this.telefono,
      mail:this.mail,
    }
    var idCliente:number = this.idCliente;
    this.service.updateCiente(idCliente, cliente).subscribe(res =>{
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
      if(showUpdateSuccess){
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showUpdateSuccess){
          showUpdateSuccess.style.display = "none";
        }
      }, 4000);
    });
  }


}
