import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';

import {ClienteService} from './cliente.service';
import { SideBarComponent } from './shared/side-bar/side-bar.component';
import { HomeComponent } from './home/home/home.component';
import { AddEditClienteComponent } from './cliente/add-edit-cliente/add-edit-cliente.component';
import { ShowOperacionComponent } from './operaciones/show-operacion/show-operacion.component';
import { AddEditOperacionComponent } from './operaciones/add-edit-operacion/add-edit-operacion.component';


@NgModule({
  declarations: [
    AppComponent,
    ShowClienteComponent,
    SideBarComponent,
    HomeComponent,
    AddEditClienteComponent,
    ShowOperacionComponent,
    AddEditOperacionComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
