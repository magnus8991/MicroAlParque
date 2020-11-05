import { Component, OnInit } from '@angular/core';
import {FormGroup,Validators,FormBuilder} from '@angular/forms';
import { Restaurante } from '../../Modelos/restaurante';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-registro-restaurante',
  templateUrl: './registro-restaurante.component.html',
  styleUrls: ['./registro-restaurante.component.css']
})
export class RegistroRestauranteComponent implements OnInit {

  formularioRegistro : FormGroup;
  restaurante : Restaurante = new Restaurante();


  constructor
  (
    private formBuilder : FormBuilder,
    public activeModal: NgbActiveModal
  )
  { }

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario ();
  }

  EstablecerValidacionesFormulario  ()
  {
    this.formularioRegistro = this.formBuilder.group(
      {
        nombre : ['',[Validators.required,Validators.minLength(7),Validators.maxLength(35)]],
        direccion : ['',[Validators.required,Validators.maxLength(40)]]
      }
    );
  }

  get nombre ()
  {
    return this.formularioRegistro.get('nombre');
  }
  get direccion ()
  {
    return this.formularioRegistro.get('direccion');
  }
}
