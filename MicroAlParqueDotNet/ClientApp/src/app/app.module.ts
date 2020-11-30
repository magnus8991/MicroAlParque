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
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatFormFieldModule , MatFormFieldControl} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatStepperModule} from '@angular/material/stepper';
import {MatInputModule} from '@angular/material/input';

import { FiltroRestaurantePipe } from './Micro al Parque/pipe/filtro-restaurante.pipe';
import { GestionSedeComponent } from './Micro al Parque/Componentes/gestion-sede/gestion-sede.component';
import { FiltroSedePipe } from './Micro al Parque/pipe/filtro-sede.pipe';
import { ActualizacionSedeComponent } from './Micro al Parque/Componentes/actualizacion-sede/actualizacion-sede.component';
import { RegistroSedeComponent } from './Micro al Parque/Componentes/registro-sede/registro-sede.component';

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
    NosotrosComponent,
    RegistroSedeComponent, FiltroRestaurantePipe,
    FiltroSedePipe, ActualizacionSedeComponent,
    GestionSedeComponent


  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule ,
    MatStepperModule,
    MatInputModule
  ],
  entryComponents:[GestionRestauranteComponent,GestionSedeComponent],
  providers: [NgbNav],
  bootstrap: [AppComponent]
})
export class AppModule { }
