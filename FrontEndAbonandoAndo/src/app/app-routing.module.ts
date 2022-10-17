import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';
import { HomeComponent } from './home/home/home.component';
import { ShowOperacionComponent } from './operaciones/show-operacion/show-operacion.component';
import { LoginComponent } from './auth/login/login.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'clientes', component: ShowClienteComponent },
  { path:  'operaciones', component : ShowOperacionComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
