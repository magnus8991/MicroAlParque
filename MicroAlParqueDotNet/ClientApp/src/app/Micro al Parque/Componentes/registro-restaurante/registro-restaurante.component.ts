import { Component, OnInit } from '@angular/core';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ServicioRestaurante } from '../../Servicios/restaurante.service';
import { Peticion } from '../../Modelos/peticion';
import { Mensajes } from '../../Servicios/mensajes';

@Component({
  selector: 'app-registro-restaurante',
  templateUrl: './registro-restaurante.component.html',
  styleUrls: ['./registro-restaurante.component.css']
})
export class RegistroRestauranteComponent implements OnInit {
  peticion: Peticion<Restaurante>;
  formularioRegistro : FormGroup;


  constructor
  (
    private formBuilder : FormBuilder, public activeModal: NgbActiveModal, private mensajes: Mensajes,
    private servicioRestaurante: ServicioRestaurante
  )
  { }

  ngOnInit(): void {
    this.peticion = new Peticion(new Restaurante());
    this.EstablecerValidacionesFormulario ();
  }

  Registrar() {
    if (this.CamposVacios()) {
      this.mensajes.Mostrar("¡Advertencia!","Hay errores o campos vacíos en el formulario, por favor verifique");
    }
    else {
      this.servicioRestaurante.Guardar(this.peticion.elemento).subscribe(peticion => {
        if (peticion != null) {
          this.peticion = peticion;
          this.mensajes.Mostrar("¡Operación Exitosa!",peticion.mensaje);
          this.activeModal.close(this.peticion.elemento);
        }
      });
    }
  }

  EstablecerValidacionesFormulario  ()
  {
    this.formularioRegistro = this.formBuilder.group(
      {
        NIT : ['',[Validators.required,Validators.minLength(6),Validators.maxLength(15)]],
        nombre : ['',[Validators.required,Validators.maxLength(35)]],
        direccion : ['',[Validators.required,Validators.maxLength(40)]],
        sede : ['',[Validators.required,Validators.maxLength(20)]],
        telefono : [0,[Validators.required, Validators.max(3509999999)]],
        idPropietario : ['',[Validators.required,Validators.maxLength(11)]]
      }
    );
  }

  CamposVacios(): boolean {
    return (this.formularioRegistro.invalid) ? true : false;
  }

  onClose() {
    if (this.peticion != null) this.activeModal.close(this.peticion.elemento);
    else this.activeModal.close(null);
  }

  get NIT () {return this.formularioRegistro.get('NIT');}
  get nombre () {return this.formularioRegistro.get('nombre');}
  get direccion () {return this.formularioRegistro.get('direccion');}
  get sede () {return this.formularioRegistro.get('sede');}
  get telefono () {return this.formularioRegistro.get('telefono');}
  get idPropietario () {return this.formularioRegistro.get('idPropietario');}
}
