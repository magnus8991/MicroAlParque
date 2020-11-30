import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroRestauranteComponent } from './Micro al Parque/Componentes/registro-restaurante/registro-restaurante.component';
import { GestionRestauranteComponent } from './Micro al Parque/Componentes/gestion-restaurante/gestion-restaurante.component';
import { GestionManipuladorComponent } from './Micro al Parque/Componentes/gestion-manipulador/gestion-manipulador.component';
import { NosotrosComponent } from './nosotros/nosotros.component';
import { EncuestaManipuladorComponent } from './Micro al Parque/Componentes/encuesta-manipulador/encuesta-manipulador.component';
import { GestionSedeComponent } from './Micro al Parque/Componentes/gestion-sede/gestion-sede.component';

const routes: Routes = [
  {path: '', component: InicioComponent},
  {path: 'gestionRestaurante', component: GestionRestauranteComponent},
  {path: 'gestionSede/:restauranteId', component: GestionSedeComponent},
  {path: 'gestionManipulador/:restauranteId/:sedeId', component: GestionManipuladorComponent},
  {path: 'nosotros', component: NosotrosComponent}
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
],
exports: [RouterModule]
})
export class AppRoutingModule { }
