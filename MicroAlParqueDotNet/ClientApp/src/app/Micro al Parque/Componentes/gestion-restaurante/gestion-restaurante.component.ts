import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistroRestauranteComponent } from '../registro-restaurante/registro-restaurante.component';

@Component({
  selector: 'app-gestion-restaurante',
  templateUrl: './gestion-restaurante.component.html',
  styleUrls: ['./gestion-restaurante.component.css']
})
export class GestionRestauranteComponent implements OnInit {

  constructor(private modalService: NgbModal) { }

  restaurantes : Restaurante [] = [];
  ngOnInit(): void {
    this.finjir ();
  }
  openModalRestaurante()
  {
    this.modalService.open(RegistroRestauranteComponent, { size: 'l' });
  }

  finjir ()
  {
    let restaurante : Restaurante =
    {
      idRestaurante : 1,
      nombre : "Monta carga",
      direccion : "los cocos ",
      identificacion : ""
    };
    let restaurante2 : Restaurante =
    {
      idRestaurante : 1,
      nombre : "Monta carga",
      direccion : "los cocos ",
      identificacion : ""
    };
    let restaurante3 : Restaurante =
    {
      idRestaurante : 1,
      nombre : "Monta carga",
      direccion : "los cocos ",
      identificacion : ""
    };
    this.restaurantes.push(restaurante);
    this.restaurantes.push(restaurante2);
    this.restaurantes.push(restaurante3);


  }
}
