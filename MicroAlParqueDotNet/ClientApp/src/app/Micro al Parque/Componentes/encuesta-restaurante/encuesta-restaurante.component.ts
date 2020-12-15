import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { ListaChequeo } from '../../Modelos/lista-chequeo';
import { PeticionConsulta } from '../../Modelos/peticion';
import { ListaChequeoService } from '../../Servicios/lista-chequeo.service';
import { Mensajes } from '../../Servicios/mensajes';

@Component({
  selector: 'app-encuesta-restaurante',
  templateUrl: './encuesta-restaurante.component.html',
  styleUrls: ['./encuesta-restaurante.component.css']
})
export class EncuestaRestauranteComponent implements OnInit {

  IdRestaurante : string;
  columnsToDisplay = ['id', 'fecha', 'porcentaje','acciones'];
  dataSource;
  peticion: PeticionConsulta<ListaChequeo> =  new PeticionConsulta();
  constructor( private route: ActivatedRoute, private servicioChequeo : ListaChequeoService,private mensajes: Mensajes) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.IdRestaurante = params.get('restauranteId');
    });
  }
  AbrirRegistroEncuesta()
  {

  }

  Consultar() {
    this.servicioChequeo.Consultar(this.IdRestaurante).subscribe(result => {
      if (result != null) {
        this.peticion = result;
        this.dataSource = new MatTableDataSource<ListaChequeo>(this.peticion.elementos);
      }
      else this.mensajes.Mostrar("¡Oh, no!", result.mensaje);
    });
  }

}
