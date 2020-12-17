import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ListaChequeo } from '../../Modelos/lista-chequeo';
import { PeticionConsulta } from '../../Modelos/peticion';
import { ListaChequeoService } from '../../Servicios/lista-chequeo.service';
import { Mensajes } from '../../Servicios/mensajes';
import { RegistroEncuestaChequeoComponent } from '../reg-lista-chequeo/reg-lista-chequeo.component';
import { VerChequeoComponent } from '../ver-chequeo/ver-chequeo.component';

@Component({
  selector: 'app-encuesta-restaurante',
  templateUrl: './encuesta-restaurante.component.html',
  styleUrls: ['./encuesta-restaurante.component.css']
})
export class EncuestaRestauranteComponent implements OnInit {

  dataSource;
  restauranteId: string;
  sedeId: number;
  columnsToDisplay = ['id', 'fecha', 'porcentaje','acciones'];
  peticion: PeticionConsulta<ListaChequeo> ;

  constructor(private modalService: NgbModal,
  private mensajes: Mensajes,private servicioEncuesta: ListaChequeoService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.peticion = new PeticionConsulta();
    this.route.paramMap.subscribe(params => {
      this.restauranteId = params.get('restauranteId');
      var id = params.get('sedeId');
      this.sedeId = Number.parseInt(id);
    });
    this.Consultar();

  }

  Consultar() {
    this.servicioEncuesta.Consultar(this.sedeId).subscribe(result => {
      if (result != null) {
        this.peticion = result;
        this.mensajes.Mostrar("¡Oh, no!", result.mensaje);
        this.dataSource = new MatTableDataSource<ListaChequeo>(this.peticion.elementos);
      }
      else this.mensajes.Mostrar("¡Oh, no!", result.mensaje);
    });
  }

  openModaRegistrolLista()
  {
    this.modalService.open(RegistroEncuestaChequeoComponent, { size: 'xl' }).
    componentInstance.sedeId = this.sedeId;
  }
  openModalLista(listaChequeoId : number)
  {
    this.modalService.open(VerChequeoComponent, { size: 'xl' }).
    componentInstance.listaChequeoId = listaChequeoId;
  }


}
