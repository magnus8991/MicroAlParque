import { Component, OnInit } from '@angular/core';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ServicioRestaurante } from '../../Servicios/restaurante.service';

@Component({
  selector: 'app-actualizacion-restaurante',
  templateUrl: './act-restaurante.component.html',
  styleUrls: ['./act-restaurante.component.css']
})
export class ActualizacionRestauranteComponent implements OnInit {

  formularioActualizacion : FormGroup;
  restaurante : Restaurante;


  constructor
  (
    private formBuilder : FormBuilder,
    public activeModal: NgbActiveModal,
    private servicioRestaurante: ServicioRestaurante
  )
  { }

  ngOnInit(): void {
    this.restaurante = new Restaurante();
    this.EstablecerValidacionesFormulario ();
  }

  Registrar() {
    this.servicioRestaurante.Guardar(this.restaurante).subscribe (r => {
        this.restaurante = r.elemento;
    });
  }

  EstablecerValidacionesFormulario  ()
  {
    this.formularioActualizacion = this.formBuilder.group(
      {
        nombre : ['',[Validators.required,Validators.minLength(7),Validators.maxLength(35)]],
        direccion : ['',[Validators.required,Validators.maxLength(40)]]
      }
    );
  }

  get nombre ()
  {
    return this.formularioActualizacion.get('nombre');
  }
  get direccion ()
  {
    return this.formularioActualizacion.get('direccion');
  }
}
