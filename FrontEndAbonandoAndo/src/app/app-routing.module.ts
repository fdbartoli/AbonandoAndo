import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';
import { HomeComponent } from './home/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'clientes', component: ShowClienteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }