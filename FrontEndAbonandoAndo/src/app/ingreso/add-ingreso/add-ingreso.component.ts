import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-ingreso',
  templateUrl: './add-ingreso.component.html',
  styleUrls: ['./add-ingreso.component.css']
})
export class AddIngresoComponent implements OnInit {

  constructor() { }
  @Input() ingreso:any;

  ngOnInit(): void {
  }

}
