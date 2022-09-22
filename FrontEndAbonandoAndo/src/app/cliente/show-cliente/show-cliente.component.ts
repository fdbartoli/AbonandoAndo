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

}
