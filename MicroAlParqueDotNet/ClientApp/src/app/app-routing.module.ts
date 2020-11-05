import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroRestauranteComponent } from './Micro al Parque/Componentes/registro-restaurante/registro-restaurante.component';
import { GestionRestauranteComponent } from './Micro al Parque/Componentes/gestion-restaurante/gestion-restaurante.component';
import { GestionManipuladorComponent } from './Micro al Parque/Componentes/gestion-manipulador/gestion-manipulador.component';

const routes: Routes = [
  {path: '', component: InicioComponent},
  {path: 'registro-restaurante', component: RegistroRestauranteComponent},
  {path: 'app-gestion-restaurante', component: GestionRestauranteComponent},
  {path: 'app-gestion-manipulador', component: GestionManipuladorComponent}
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes)
],
exports: [RouterModule]
})
export class AppRoutingModule { }
