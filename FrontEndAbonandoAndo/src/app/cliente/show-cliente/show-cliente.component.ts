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
  activateAddEditInspectionComponent:boolean = false;
  cliente:any;

  modalAdd(){
    this.cliente = {
      //TODO properties cliente
    }
    this.modalTitle = "Agregar Cliente";
    this.activateAddEditInspectionComponent = true;
  }
  modalClose(){
    this.activateAddEditInspectionComponent =false;
    this.clienteList$ = this.service.getClienteList();
  }

}
