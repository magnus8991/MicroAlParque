import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { RegistroRestauranteComponent } from './Micro al Parque/Componentes/registro-restaurante/registro-restaurante.component';
import { GestionRestauranteComponent } from './Micro al Parque/Componentes/gestion-restaurante/gestion-restaurante.component';
import { GestionManipuladorComponent } from './Micro al Parque/Componentes/gestion-manipulador/gestion-manipulador.component';
import { NosotrosComponent } from './nosotros/nosotros.component';
import { GestionSedeComponent } from './Micro al Parque/Componentes/gestion-sede/gestion-sede.component';
import { InicioDeSesionComponent } from './Micro al Parque/Componentes/inicio-de-sesion/inicio-de-sesion.component';
import { UsuarioRegistroComponent } from './Micro al Parque/Componentes/usuario-registro/usuario-registro.component';
import { AuthGuard } from './Micro al Parque/Servicios/auth.guard';
import { EncuestaRestauranteComponent } from './Micro al Parque/Componentes/encuesta-restaurante/encuesta-restaurante.component';

const routes: Routes = [
  { path: '', component: InicioComponent },
  { path: 'gestionRestaurante', component: GestionRestauranteComponent, canActivate: [AuthGuard] },
  { path: 'gestionSede/:restauranteId', component: GestionSedeComponent, canActivate: [AuthGuard] },
  { path: 'gestionManipulador/:restauranteId/:sedeId', component: GestionManipuladorComponent, canActivate: [AuthGuard] },
  { path: 'nosotros', component: NosotrosComponent },
  { path: 'login/:cerrarSesion', component: InicioDeSesionComponent },
  { path: 'usuarioRegistro', component: UsuarioRegistroComponent },
  { path: 'encuesta-restaurante/:restauranteId', component: EncuestaRestauranteComponent }
];

@NgModule({
declarations: [],
imports: [
  RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
],
exports: [RouterModule]
})
export class AppRoutingModule { }
