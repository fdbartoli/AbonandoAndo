import { Component, Input, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import { OperacionService } from 'src/app/operacionService/operacion.service';


@Component({
  selector: 'app-add-edit-operacion',
  templateUrl: './add-edit-operacion.component.html',
  styleUrls: ['./add-edit-operacion.component.css']
})
export class AddEditOperacionComponent implements OnInit {
  
  operacionList$!:Observable<any[]>;

  constructor(private service:OperacionService) { }

  @Input() operacion:any;

  idOperacion:number = 0;
  tipo:boolean = false;
 
  ngOnInit(): void {

    this.idOperacion=this.operacion.idOperacion;
    this.tipo=this.operacion.tipo;
    this.operacionList$ = this.service.GetOperacionList();

  }

  addOperacion(){
    var cliente ={
      tipo:this.tipo,
    }
    this.service.addOperacion(this.operacion).subscribe(res =>{
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

  updateOperacion(){
    var cliente ={
      idOperacion:this.idOperacion,
      tipo:this.tipo,
    }
    var idOperacion:number = this.idOperacion;
    this.service.updateOperacion(idOperacion, cliente).subscribe(res =>{
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
