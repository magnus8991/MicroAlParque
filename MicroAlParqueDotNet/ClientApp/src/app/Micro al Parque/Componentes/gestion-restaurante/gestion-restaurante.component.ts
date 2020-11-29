import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistroRestauranteComponent } from '../registro-restaurante/registro-restaurante.component';
import { Mensajes } from '../../Servicios/mensajes';
import { Peticion, PeticionConsulta } from '../../Modelos/peticion';
import { RegistroManipuladorComponent } from '../registro-manipulador/registro-manipulador.component';
import { ActualizacionRestauranteComponent } from '../actualizacion-restaurante/act-restaurante.component';
import { ServicioRestaurante } from '../../Servicios/restaurante.service';

@Component({
  selector: 'app-gestion-restaurante',
  templateUrl: './gestion-restaurante.component.html',
  styleUrls: ['./gestion-restaurante.component.css']
})
export class GestionRestauranteComponent implements OnInit {
  filtroRestaurante: string;
  peticion: PeticionConsulta<Restaurante>;
  restaurantes : Restaurante[];

  constructor(private modalService: NgbModal, private servicioRestaurante: ServicioRestaurante,
  private mensajes: Mensajes) { }

  ngOnInit(): void {
    this.peticion = new PeticionConsulta();
    this.restaurantes = [];
    this.Consultar();
  }

  Consultar() {
    this.servicioRestaurante.Consultar().subscribe(result => {
      if (result !=null) {
        this.peticion = result;
        this.AsignarValoresTabla(this.peticion.elementos);
      }
      else this.mensajes.Mostrar("¡Oh, no!",result.mensaje);
    });
  }

  AsignarValoresTabla(listaRestaurantes: Restaurante[]) {
    this.restaurantes = [];
    listaRestaurantes.forEach(restaurante => {
      this.restaurantes.push(restaurante);
    });
  }

  ModificarListaProvisional() {
    if (this.filtroRestaurante == undefined || this.filtroRestaurante == null)
      this.AsignarValoresTabla(this.peticion.elementos);
    else {
      var listaFiltrada = this.FiltrarLista();
      this.AsignarValoresTabla(listaFiltrada);
    }
  }

  FiltrarLista(): Restaurante[] {
    var listaRestaurantes = this.peticion.elementos.filter(r => r.nit.toLowerCase().indexOf(this.filtroRestaurante.toLowerCase()) !== -1
    || r.nombre.toLowerCase().indexOf(this.filtroRestaurante.toLowerCase()) !== -1);
      return listaRestaurantes;
  }

  RegistrarRestaurante() {
    this.modalService.open(RegistroRestauranteComponent, {size: 'xl', backdrop: 'static', keyboard: false}).result.then(r => {
      if (r != null) {
        var restaurante = new Restaurante();
        restaurante = r;
        if (restaurante.nit != undefined) {
          this.peticion.elementos.push(r);
          this.AsignarValoresTabla(this.peticion.elementos);
        }
      }
    });
  }

  Modificar(nit: string) {
    const modelo = this.modalService.open(ActualizacionRestauranteComponent, {size: 'xl'});
     var restaurante = this.peticion.elementos.find(r => r.nit == nit);
     var respuesta = new Peticion<Restaurante>(restaurante);
     modelo.componentInstance.peticion = respuesta;
  }

  /*delete(nit: string) {
    var i = this.peticion.elementos.findIndex(r => r.nit == nit);
    this.servicioRestaurante.Eliminar(this.peticion.elementos[i].nit).subscribe(result => {
      if (!result.error) {
        this.peticion.elementos.splice(i,1);
        this.AsignarValoresTabla(this.peticion.elementos);
        this.mensajes.Mostrar("¡Operación Exitosa!",result.mensaje);
      }
      else this.mensajes.Mostrar("¡Oh, no!",result.mensaje);
    });
  }*/
}
