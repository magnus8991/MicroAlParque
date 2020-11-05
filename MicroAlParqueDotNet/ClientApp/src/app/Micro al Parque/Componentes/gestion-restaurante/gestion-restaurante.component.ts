import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistroRestauranteComponent } from '../registro-restaurante/registro-restaurante.component';
import { RestauranteService } from '../../Servicios/restaurante.service';
import { Mensajes } from '../../Servicios/mensajes';

@Component({
  selector: 'app-gestion-restaurante',
  templateUrl: './gestion-restaurante.component.html',
  styleUrls: ['./gestion-restaurante.component.css']
})
export class GestionRestauranteComponent implements OnInit {

  constructor(private modalService: NgbModal, private servicioRestaurante: RestauranteService,
  private mensajes: Mensajes) { }
  restaurantes : Restaurante[];

  ngOnInit(): void {
    this.restaurantes = [];
    this.Consultar();
  }
  openModalRestaurante()
  {
    this.modalService.open(RegistroRestauranteComponent, { size: 'l' });
  }

  Consultar() {
    this.servicioRestaurante.Consultar().subscribe(result => {
      if (!result.error) {
        this.restaurantes = result.elementos;
        this.mensajes.Mostrar("¡En hora buena!",result.mensaje);
      } 
      else this.mensajes.Mostrar("¡Lo sentimos!",result.mensaje);
    });
  }
}
