import { Component, OnInit } from '@angular/core';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbActiveModal, NgbNav } from '@ng-bootstrap/ng-bootstrap';
import { ServicioRestaurante } from '../../Servicios/restaurante.service';
import { Peticion } from '../../Modelos/peticion';
import { Mensajes } from '../../Servicios/mensajes';
import { Propietario } from '../../Modelos/persona';

@Component({
  selector: 'app-registro-restaurante',
  templateUrl: './registro-restaurante.component.html',
  styleUrls: ['./registro-restaurante.component.css']
})
export class RegistroRestauranteComponent implements OnInit {
  peticion: Peticion<Restaurante>;
  propietario : Propietario
  formularioRegistro : FormGroup;
  formularioRegistroPropietario : FormGroup;

  constructor
  (
    private formBuilder : FormBuilder, public activeModal: NgbActiveModal, private mensajes: Mensajes,
    private servicioRestaurante: ServicioRestaurante,
    public ngbNav : NgbNav
  )
  { }

  ngOnInit(): void {
    this.peticion = new Peticion(new Restaurante());
    this.propietario = new Propietario();
    this.EstablecerValidacionesFormulario ();
    this.EstablecerValidacionesFormularioPropietario();
  }

  Registrar() {
    if (this.CamposVacios()) {
      this.mensajes.Mostrar("¡Advertencia!","Hay errores o campos vacíos en el formulario, por favor verifique");
    }
    else {
      this.peticion.elemento.propietario = this.propietario;
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
        telefono : [0,[Validators.required, Validators.max(3509999999)]]
      }
    );
  }
  EstablecerValidacionesFormularioPropietario() {
    this.formularioRegistroPropietario = this.formBuilder.group(
      {
        identificacion: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(11)]],
        nombres: ['', [Validators.required]],
        primerApellido: ['', [Validators.required, Validators.maxLength(30)]],
        segundoApellido: ['', [Validators.required, Validators.maxLength(30)]],
        sexo: ['', [Validators.required]],
        edad: [, [Validators.required]]
      }
    );
  }

  CamposVacios(): boolean {
    return (this.formularioRegistro.invalid || this.formularioRegistroPropietario.invalid) ? true : false;
  }

  onClose() {
    if (this.peticion != null) this.activeModal.close(this.peticion.elemento);
    else this.activeModal.close(null);
  }

  get identificacion() { return this.formularioRegistroPropietario.get('identificacion'); }
  get nombres() { return this.formularioRegistroPropietario.get('nombres'); }
  get primerApellido() { return this.formularioRegistroPropietario.get('primerApellido'); }
  get segundoApellido() { return this.formularioRegistroPropietario.get('segundoApellido'); }
  get sexo() { return this.formularioRegistroPropietario.get('sexo'); }
  get edad() { return this.formularioRegistroPropietario.get('edad'); }

  get NIT () {return this.formularioRegistro.get('NIT');}
  get nombre () {return this.formularioRegistro.get('nombre');}
  get direccion () {return this.formularioRegistro.get('direccion');}
  get sede () {return this.formularioRegistro.get('sede');}
  get telefono () {return this.formularioRegistro.get('telefono');}
  get idPropietario () {return this.formularioRegistro.get('idPropietario');}
}
