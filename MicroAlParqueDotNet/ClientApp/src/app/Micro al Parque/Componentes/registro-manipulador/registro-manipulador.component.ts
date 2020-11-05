import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ManipuladorDeAlimento } from '../../Modelos/manipulador-de-alimento';

@Component({
  selector: 'app-registro-manipulador',
  templateUrl: './registro-manipulador.component.html',
  styleUrls: ['./registro-manipulador.component.css']
})
export class RegistroManipuladorComponent implements OnInit {


  formularioRegistro : FormGroup;

  manipulador :ManipuladorDeAlimento = new ManipuladorDeAlimento();
  constructor(private formBuilder : FormBuilder,
    public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
  }

  EstablecerValidacionesFormulario  ()
  {
    this.formularioRegistro = this.formBuilder.group(
      {
        identificacion : ['',[Validators.required,Validators.minLength(7),Validators.maxLength(11)]],
        nombres : ['',[Validators.required]],
        primerApellido : ['',[Validators.required,Validators.maxLength(40)]],
        segundoApellido : ['',[Validators.required,Validators.maxLength(40)]],
        sexo : ['',[Validators.required]],
        edad : [,[Validators.required]],
        paisDeProcedencia : ['',[Validators.required]],
        estadoCivil : ['',[Validators.required]],
        nivelEducativo : ['',[Validators.required]]
      }
    );
  }

  get identificacion ()
  {
    return this.formularioRegistro.get('identificacion');
  }
  get nombres ()
  {
    return this.formularioRegistro.get('nombres');
  }
  get primerApellido ()
  {
    return this.formularioRegistro.get('primerApellido');
  }
  get segundoApellido ()
  {
    return this.formularioRegistro.get('segundoApellido');
  }
  get sexo ()
  {
    return this.formularioRegistro.get('sexo');
  }
  get edad ()
  {
    return this.formularioRegistro.get('edad');
  }
  get paisDeProcedencia ()
  {
    return this.formularioRegistro.get('paisDeProcedencia');
  }
  get estadoCivil ()
  {
    return this.formularioRegistro.get('estadoCivil');
  }
  get nivelEducativo ()
  {
    return this.formularioRegistro.get('nivelEducativo');
  }

  
}
