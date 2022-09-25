import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import { OperacionService } from 'src/app/operacionService/operacion.service';


@Component({
  selector: 'app-show-operacion',
  templateUrl: './show-operacion.component.html',
  styleUrls: ['./show-operacion.component.css']
})
export class ShowOperacionComponent implements OnInit {

  operacionList$!:Observable<any[]>;

  constructor(private service:OperacionService) { }

  ngOnInit(): void {
    this.operacionList$ = this.service.GetOperacionList();
  }

  modalTitle:string = '';
  activateAddEditOperacionComponent:boolean = false;
  operacion:any;

  modalAdd(){
    this.operacion = {
      idOperacion:0,
      tipo:null,
    }
    this.modalTitle = "Agregar operación";
    this.activateAddEditOperacionComponent = true;
  }
  modalClose(){
    this.activateAddEditOperacionComponent =false;
    this.operacionList$ = this.service.GetOperacionList();
  }

  modalEdit(item:any){
    this.operacion= item;
    this.modalTitle = "Editar cliente";
    this.activateAddEditOperacionComponent = true;
  }

  delete(item:any){
    if(confirm(`¿Desea eliminar esta operación? - ID: ${item.idOperacion}?`)){
      this.service.deleteOperacion(item.idCliente).subscribe(res=>{
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
      this.operacionList$ = this.service.GetOperacionList();
      })
    }
  }


}
