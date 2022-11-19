import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-add-edit-operacion',
  templateUrl: './add-edit-operacion.component.html',
  styleUrls: ['./add-edit-operacion.component.css'],
})
export class AddEditOperacionComponent implements OnInit {
  operacionList$!: Observable<any[]>;

  constructor() {}

  @Input() operacion: any;

  idOperacion: number = 0;
  fecha: Date = new Date();
  monto: string = '';
  detalle: string = '';

  ngOnInit(): void {}
}
