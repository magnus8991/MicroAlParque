import { Component, OnInit } from '@angular/core';
import { RegistroManipuladorComponent } from '../../Componentes/registro-manipulador/registro-manipulador.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ManipuladorDeAlimento } from '../../Modelos/manipulador-de-alimento';
import { ManipuladorService } from '../../Servicios/manipulador.service';
import { Mensajes } from '../../Servicios/mensajes';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-gestion-manipulador',
  templateUrl: './gestion-manipulador.component.html',
  styleUrls: ['./gestion-manipulador.component.css']
})
export class GestionManipuladorComponent implements OnInit,AfterViewInit {

  displayedColumns: string[] = ['identificacion','Nombres', 'Apellidos', 'Edad', 'Sexo','Acciones'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  manipuladores : ManipuladorDeAlimento []= [] ;
  restauranteId = "qwer124";
  dataSource;
  constructor(
    private modalService: NgbModal,
    private servicioManipulador: ManipuladorService,
    private mensaje : Mensajes
    ) {

    }

  ngOnInit(): void {
    this.Consultar();
  }


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  Consultar() {
    this.servicioManipulador.Consultar(this.restauranteId).subscribe(result => {
      if(result.error)
      {
        this.mensaje.Mostrar("Oh no ha sucedido un error al consultar Los manipuladores",result.mensaje);
      }
      else{
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
    modalRegistro.componentInstance.restauranteId = this.restauranteId;

  }
}
