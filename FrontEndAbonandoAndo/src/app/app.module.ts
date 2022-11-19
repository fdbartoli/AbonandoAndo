import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';

import { ClienteService } from './cliente.service';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home/home.component';
import { AddEditClienteComponent } from './cliente/add-edit-cliente/add-edit-cliente.component';
import { ShowOperacionComponent } from './operaciones/show-operacion/show-operacion.component';
import { AddEditOperacionComponent } from './operaciones/add-edit-operacion/add-edit-operacion.component';
import { HeaderComponent } from './shared/header/header.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { CuentaCorrienteComponent } from './cuenta-corriente/cuenta-corriente.component';
import { ComprobanteComponent } from './comprobante/comprobante.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowClienteComponent,
    HomeComponent,
    AddEditClienteComponent,
    ShowOperacionComponent,
    AddEditOperacionComponent,
    LoginComponent,
    HeaderComponent,
    SidebarComponent,
    FooterComponent,
    CuentaCorrienteComponent,
    ComprobanteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent],
})
export class AppModule {}
