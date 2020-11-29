import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InicioComponent } from './inicio/inicio.component';
import { EncabezadoComponent } from './encabezado/encabezado.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterComponent } from './footer/footer.component';
import { RegistroRestauranteComponent } from './Micro al Parque/Componentes/registro-restaurante/registro-restaurante.component';
import { RegistroManipuladorComponent } from './Micro al Parque/Componentes/registro-manipulador/registro-manipulador.component';
import { NgbModule, NgbNav } from '@ng-bootstrap/ng-bootstrap';
import { ActualizacionRestauranteComponent } from './Micro al Parque/Componentes/actualizacion-restaurante/act-restaurante.component';
import { GestionRestauranteComponent } from './Micro al Parque/Componentes/gestion-restaurante/gestion-restaurante.component';
import { GestionManipuladorComponent } from './Micro al Parque/Componentes/gestion-manipulador/gestion-manipulador.component';
import { EncuestaManipuladorComponent } from './Micro al Parque/Componentes/encuesta-manipulador/encuesta-manipulador.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { NosotrosComponent } from './nosotros/nosotros.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
    ActualizacionRestauranteComponent,
    AlertModalComponent,
    NosotrosComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    BrowserAnimationsModule,
    MatIconModule
  ],
  entryComponents:[RegistroRestauranteComponent,GestionManipuladorComponent],
  providers: [NgbNav],
  bootstrap: [AppComponent]
})
export class AppModule { }
