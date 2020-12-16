import { Component, OnInit } from '@angular/core';
import { RegistroManipuladorComponent } from '../../Componentes/registro-manipulador/registro-manipulador.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManipuladorDeAlimento } from '../../Modelos/manipulador-de-alimento';
import { ManipuladorService } from '../../Servicios/manipulador.service';
import { Mensajes } from '../../Servicios/mensajes';
import {MatTableDataSource} from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { SignalRServiceManipulador } from '../../Servicios/signal-r.service';


@Component({
  selector: 'app-gestion-manipulador',
  templateUrl: './gestion-manipulador.component.html',
  styleUrls: ['./gestion-manipulador.component.css']
})
export class GestionManipuladorComponent implements OnInit {

  displayedColumns: string[] = ['identificacion','Nombres', 'Apellidos', 'Edad', 'Acciones'];
  manipuladores : ManipuladorDeAlimento []= [] ;
  ManipuladorId: number;
  restauranteId: string;
  IdSede;
  dataSource;
  constructor(
    private modalService: NgbModal, private servicioManipulador: ManipuladorService,
    private mensaje : Mensajes, private  route: ActivatedRoute, private signalRService: SignalRServiceManipulador
    ) {

    }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.ManipuladorId = parseInt(params.get('ManipuladorId'));
      this.restauranteId = params.get('restauranteId');
      this.IdSede = params.get('sedeId');
    });
    this.Consultar();
    this.abrirConexionSignalR();
  }
  
  Consultar() {
    this.servicioManipulador.Consultar(this.IdSede).subscribe(result => {
      if(!result.error) {
        this.manipuladores = result.elementos;
        this.dataSource  = new MatTableDataSource<ManipuladorDeAlimento>(this.manipuladores);
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openModalManipulador()
  {
    this.modalService.open(RegistroManipuladorComponent, { size: 'xl' }).
    componentInstance.ManipuladorId = this.ManipuladorId;
  }

  abrirConexionSignalR() {
    this.signalRService.ManipuladorReceived.subscribe((Manipulador: ManipuladorDeAlimento) => {
      this.manipuladores.push(Manipulador);
    });
  }
}
