import { Component, OnInit } from '@angular/core';
import { RegistroManipuladorComponent } from '../../Componentes/registro-manipulador/registro-manipulador.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManipuladorDeAlimento } from '../../Modelos/manipulador-de-alimento';
import { ManipuladorService } from '../../Servicios/manipulador.service';
import { Mensajes } from '../../Servicios/mensajes';
import {MatTableDataSource} from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-gestion-manipulador',
  templateUrl: './gestion-manipulador.component.html',
  styleUrls: ['./gestion-manipulador.component.css']
})
export class GestionManipuladorComponent implements OnInit {

  displayedColumns: string[] = ['identificacion','Nombres', 'Apellidos', 'Edad', 'Sexo','Acciones'];
  manipuladores : ManipuladorDeAlimento []= [] ;
  sedeId: number;
  restauranteId: string;
  dataSource;
  constructor(
    private modalService: NgbModal, private servicioManipulador: ManipuladorService,
    private mensaje : Mensajes, private  route: ActivatedRoute
    ) {

    }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.sedeId = parseInt(params.get('sedeId'));
      this.restauranteId = params.get('restauranteId');
    });
    this.Consultar();
  }
  
  Consultar() {
    this.servicioManipulador.Consultar(this.sedeId).subscribe(result => {
      if(!result.error) {
        this.manipuladores = result.elementos;
        this.dataSource  = new MatTableDataSource<ManipuladorDeAlimento>(this.manipuladores);
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openModalManipulador()
  {
    const modalRegistro = this.modalService.open(RegistroManipuladorComponent, { size: 'xl' });
    modalRegistro.componentInstance.sedeId = this.sedeId;
    modalRegistro.result.then(m => {
      if(m != null)
      {
        this.Consultar();
      }
    });

  }
}
