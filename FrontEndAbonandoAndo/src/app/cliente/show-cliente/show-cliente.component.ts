import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import { ClienteService } from 'src/app/cliente.service';

@Component({
  selector: 'app-show-cliente',
  templateUrl: './show-cliente.component.html',
  styleUrls: ['./show-cliente.component.css']
})
export class ShowClienteComponent implements OnInit {

  clienteList$!:Observable<any[]>;

  constructor(private service:ClienteService) { }

  ngOnInit(): void {
    this.clienteList$ = this.service.getClienteList();
  }

  modalTitle:string = '';
  activateAddEditClienteComponent:boolean = false;
  cliente:any;

  modalAdd(){
    this.cliente = {
      idCliente:0,
      cuil:null,
      apellidos:null,
      nombres:null,
      domicilio:null,
      telefono:null,
      mail:null
    }
    this.modalTitle = "Agregar cliente";
    this.activateAddEditClienteComponent = true;
  }
  modalClose(){
    this.activateAddEditClienteComponent =false;
    this.clienteList$ = this.service.getClienteList();
  }

  modalEdit(item:any){
    this.cliente= item;
    this.modalTitle = "Editar cliente";
    this.activateAddEditClienteComponent = true;
  }

  delete(item:any){
    if(confirm(`¿Desea eliminar este cliente? - CUIL: ${item.cuil}?`)){
      this.service.deleteCliente(item.idCliente).subscribe(res=>{
        var closeModalBtn = document.getElementById('add-edit-modal-close');
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showDeleteSuccess = document.getElementById('delete-success-alert');
      if(showDeleteSuccess){
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showDeleteSuccess){
          showDeleteSuccess.style.display = "none";
        }
      }, 4000);
      this.clienteList$ = this.service.getClienteList();
      })
    }
  }


}
