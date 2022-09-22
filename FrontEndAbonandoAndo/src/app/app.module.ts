import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';
import { ShowClienteComponent } from './cliente/show-cliente/show-cliente.component';
import { AddClienteComponent } from './cliente/add-cliente/add-cliente.component';

import {ClienteService} from './cliente.service';
import { SideBarComponent } from './shared/side-bar/side-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    ShowClienteComponent,
    AddClienteComponent,
    SideBarComponent
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
