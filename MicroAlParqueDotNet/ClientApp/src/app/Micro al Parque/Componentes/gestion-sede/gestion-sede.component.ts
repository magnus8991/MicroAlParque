import { Component, Input, OnInit } from '@angular/core';
import { Sede } from '../../Modelos/sede';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistroSedeComponent } from '../registro-sede/registro-sede.component';
import { Mensajes } from '../../Servicios/mensajes';
import { Peticion, PeticionConsulta } from '../../Modelos/peticion';
import { ActualizacionSedeComponent } from '../actualizacion-sede/actualizacion-sede.component';
import { ServicioSede } from '../../Servicios/sede.service';

@Component({
  selector: 'app-gestion-sede',
  templateUrl: './gestion-sede.component.html',
  styleUrls: ['./gestion-sede.component.css']
})
export class GestionSedeComponent implements OnInit {
  filtroSede: string;
  peticion: PeticionConsulta<Sede>;
  Sedes: Sede[];
  @Input() IdRestaurante;

  constructor(private modalService: NgbModal, private servicioSede: ServicioSede,
    private mensajes: Mensajes) { }

  ngOnInit(): void {
    this.peticion = new PeticionConsulta();
    this.Sedes = [];
    this.Consultar();
  }

  Consultar() {
    this.servicioSede.Consultar(this.IdRestaurante).subscribe(result => {
      if (result != null) {
        this.peticion = result;
        this.AsignarValoresTabla(this.peticion.elementos);
      }
      else this.mensajes.Mostrar("¡Oh, no!", result.mensaje);
    });
  }

  AsignarValoresTabla(listaSedes: Sede[]) {
    this.Sedes = [];
    listaSedes.forEach(Sede => {
      this.Sedes.push(Sede);
    });
  }

  ModificarListaProvisional() {
    if (this.filtroSede == undefined || this.filtroSede == null)
      this.AsignarValoresTabla(this.peticion.elementos);
    else {
      var listaFiltrada = this.FiltrarLista();
      this.AsignarValoresTabla(listaFiltrada);
    }
  }

  FiltrarLista(): Sede[] {
    var listaSedes = this.peticion.elementos.filter(r => r.sedeId.toString().indexOf(this.filtroSede) !== -1
      || r.nombre.toLowerCase().indexOf(this.filtroSede.toLowerCase()) !== -1);
    return listaSedes;
  }

  Registrar() {
    const modelo = this.modalService.open(RegistroSedeComponent, { size: 'xl', backdrop: 'static', keyboard: false });
    modelo.componentInstance.NIT = this.IdRestaurante;
    modelo.result.then(s => {
      if (s != null) {
        var sede: Sede = s;
        if (sede.nombre != undefined) {
          var contador = 0;
          this.peticion.elementos.forEach(sedeLista => {
            if (sedeLista.nombre == sede.nombre) contador += 1;
          });
          if (contador > 0) this.mensajes.Mostrar("¡Cuidado!", "La Sede " + sede.nombre + " ya está agregada");
          else {
            this.GuardarSede(sede);
            this.peticion.elementos.push(s);
            this.AsignarValoresTabla(this.peticion.elementos);
          }
        }
      }
    });
  }

  GuardarSede(Sede: Sede) {
    this.servicioSede.Guardar(Sede).subscribe(result => {
      if (!result.error) {
        this.mensajes.Mostrar("¡Operacion exitosa!",result.mensaje);
      }
      else this.mensajes.Mostrar("¡Oh no!",result.mensaje);
    });
  }

  Modificar(id: number) {
    const modelo = this.modalService.open(ActualizacionSedeComponent, { size: 'xl' });
    var Sede = this.peticion.elementos.find(s => s.sedeId == id);
    modelo.componentInstance.Sede = Sede;
  }
}
