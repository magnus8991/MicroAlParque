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
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { GestionRestauranteComponent } from './Micro al Parque/Componentes/gestion-restaurante/gestion-restaurante.component';
import { GestionManipuladorComponent } from './Micro al Parque/Componentes/gestion-manipulador/gestion-manipulador.component';
import { EncuestaManipuladorComponent } from './Micro al Parque/Componentes/encuesta-manipulador/encuesta-manipulador.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InicioComponent,
    EncabezadoComponent,
    FooterComponent,
    RegistroRestauranteComponent,
    RegistroManipuladorComponent,
    GestionRestauranteComponent,
    GestionManipuladorComponent,
    EncuestaManipuladorComponent,
    AlertModalComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule
  ],
  entryComponents:[RegistroRestauranteComponent,GestionManipuladorComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
