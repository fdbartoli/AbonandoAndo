import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';
import { EgresoComponent } from './egreso/show-egreso/egreso.component';

import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home/home.component';
import { IngresoComponent } from './ingreso/show-ingreso/ingreso.component';
import { LoginComponent } from './login/login.component';
import { ShowOperacionComponent } from './operaciones/show-operacion/show-operacion.component';
import { SaldoComponent } from './saldo/saldo.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  {
    path: 'clientes',
    component: ShowClienteComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'operaciones',
    component: ShowOperacionComponent,
    canActivate: [AuthGuard],
  },

  {
    path: 'registros',
    component: ShowOperacionComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'cobranzas',
    component: IngresoComponent,
    canActivate: [AuthGuard],
  },

  {
    path: 'abonos',
    component: EgresoComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'saldos',
    component: SaldoComponent,
    canActivate: [AuthGuard],
  },

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
