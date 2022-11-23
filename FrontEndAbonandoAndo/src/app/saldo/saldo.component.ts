import { Component, OnInit } from '@angular/core';
import { EgresoService } from '../egreso.service';
import { IngresoService } from '../ingreso.service';
import { Iingreso } from '../models/Iingreso';

@Component({
  selector: 'app-saldo',
  templateUrl: './saldo.component.html',
  styleUrls: ['./saldo.component.css'],
})
export class SaldoComponent implements OnInit {
  constructor(
    private servicePago: IngresoService,
    private serviceCobro: EgresoService
  ) {}

  ngOnInit(): void {}

  dataSource!: Iingreso[];
  ingreso!: Iingreso[];
  cuil: string = '0';
  negativo: number = 0;
  positivo: number = 0;
  balance: number = 0;

  registrosPositivos() {
    let suma: number = 0;
    this.servicePago.getPagosCuil(this.cuil).subscribe(
      (response) => {
        this.dataSource = response;
        for (let i: number = 0; i < this.dataSource.length; i++) {
          suma = suma + this.dataSource[i].monto;
        }
        this.positivo = suma;
      },
      (error) => {
        alert('No se encotraron pagos con este cuil');
      }
    );
  }

  registrosNegativos() {
    let suma: number = 0;
    this.serviceCobro.getCobrosCuil(this.cuil).subscribe(
      (response) => {
        this.dataSource = response;
        for (let i: number = 0; i < this.dataSource.length; i++) {
          suma = suma + this.dataSource[i].monto;
        }
        this.negativo = suma;
      },
      (error) => {
        alert('No se encontraron abonos con este cuil');
      }
    );
  }

  BuscarRegistros() {
    this.registrosNegativos();
    this.registrosPositivos();
  }

  CalcularBalance() {
    this.balance = this.negativo - this.positivo;
  }
}
