import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InicioComponent } from './inicio/inicio.component';
import { EncabezadoComponent } from './encabezado/encabezado.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { RegistroRestauranteComponent } from './Micro al Parque/Componentes/registro-restaurante/registro-restaurante.component';
import { RegistroManipuladorComponent } from './Micro al Parque/Componentes/registro-manipulador/registro-manipulador.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InicioComponent,
    EncabezadoComponent,
    FooterComponent,
    RegistroRestauranteComponent,
    RegistroManipuladorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
