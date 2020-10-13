import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroRestauranteComponent } from './Micro al Parque/Componentes/registro-restaurante/registro-restaurante.component';
import { RegistroManipuladorComponent } from './Micro al Parque/Componentes/registro-manipulador/registro-manipulador.component';

const routes: Routes = [
  {path: '', component: InicioComponent},
  {path: 'registro-restaurante', component: RegistroRestauranteComponent},
  {path: 'registro-manipulador-alimento', component: RegistroManipuladorComponent}
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes)
],
exports: [RouterModule]
})
export class AppRoutingModule { }
