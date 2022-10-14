import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';
import { HomeComponent } from './home/home/home.component';
import { ShowOperacionComponent } from './operaciones/show-operacion/show-operacion.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'clientes', component: ShowClienteComponent },
  { path: 'operaciones', component: ShowOperacionComponent },
  { path: 'comprobantes', component: ShowOperacionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
