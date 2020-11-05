import { Component, OnInit } from '@angular/core';
import { RegistroManipuladorComponent } from '../../Componentes/registro-manipulador/registro-manipulador.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManipuladorDeAlimento } from '../../Modelos/manipulador-de-alimento';

@Component({
  selector: 'app-gestion-manipulador',
  templateUrl: './gestion-manipulador.component.html',
  styleUrls: ['./gestion-manipulador.component.css']
})
export class GestionManipuladorComponent implements OnInit {

  manipuladores : ManipuladorDeAlimento []= [] ;

  constructor(private modalService: NgbModal ) { }

  ngOnInit(): void {
  }
  openModalManipulador()
  {
    this.modalService.open(RegistroManipuladorComponent, { size: 'xl' });
  }
}
