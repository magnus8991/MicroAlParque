import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistroRestauranteComponent } from '../registro-restaurante/registro-restaurante.component';
import { Mensajes } from '../../Servicios/mensajes';
import { Peticion, PeticionConsulta } from '../../Modelos/peticion';
import { ActualizacionRestauranteComponent } from '../actualizacion-restaurante/act-restaurante.component';
import { ServicioRestaurante } from '../../Servicios/restaurante.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { GestionSedeComponent } from '../gestion-sede/gestion-sede.component';
import { Sede } from '../../Modelos/sede';
import { ServicioSede } from '../../Servicios/sede.service';

@Component({
  selector: 'app-gestion-restaurante',
  templateUrl: './gestion-restaurante.component.html',
  styleUrls: ['./gestion-restaurante.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class GestionRestauranteComponent implements OnInit {

  filtroRestaurante: string;
  peticion: PeticionConsulta<Restaurante>;
  restaurantes : Restaurante[] = [];
  dataSource;
  sedes: Sede[] = [];
  IdRestaurante;


  columnsToDisplay = ['Nit', 'NombreRestaurante', 'acciones'];
  expandedElement: Restaurante | null;

  constructor(private modalService: NgbModal, private servicioRestaurante: ServicioRestaurante,
  private mensajes: Mensajes,private servicioSede: ServicioSede) { }

  ngOnInit(): void {
    this.peticion = new PeticionConsulta();
    this.Consultar();
  }
  ObtenerNombreCompleto(restaurante : Restaurante)
  {
    return restaurante.propietario.nombres + " " + restaurante.propietario.primerApellido + " " + restaurante.propietario.segundoApellido;
  }
  Consultar() {
    this.servicioRestaurante.Consultar().subscribe(result => {
      if (result !=null) {
        this.peticion = result;
        this.AsignarValoresTabla(this.peticion.elementos);
        this.dataSource = this.restaurantes;
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
        var restaurante: Restaurante = r;
        if (restaurante.nit != undefined) {
          this.peticion.elementos.push(r);
          this.AsignarValoresTabla(this.peticion.elementos);
        }
      }
    });
  }

  Modificar(nit: string) {
    const modelo = this.modalService.open(ActualizacionRestauranteComponent, {backdrop: 'static', keyboard: false});
     var restaurante = this.peticion.elementos.find(r => r.nit == nit);
     modelo.componentInstance.restaurante = restaurante;
  }

  consultarSede(idRestaurante : string) {
    this.servicioSede.Consultar(idRestaurante).subscribe(result => {
      if (result != null) {
        this.sedes = [];
        this.sedes = result.elementos;
      }
      else this.mensajes.Mostrar("¡Oh, no!", result.mensaje);
    });
  }
}
