import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ManipuladorDeAlimento } from '../../Modelos/manipulador-de-alimento';
import { Restaurante } from '../../Modelos/restaurante';
import { ManipuladorService } from '../../Servicios/manipulador.service';
import { Mensajes } from '../../Servicios/mensajes';
import { ServicioRestaurante } from '../../Servicios/restaurante.service';

@Component({
  selector: 'app-registro-manipulador',
  templateUrl: './registro-manipulador.component.html',
  styleUrls: ['./registro-manipulador.component.css']
})

export class RegistroManipuladorComponent implements OnInit {
  restaurantes: Restaurante[];
  formularioRegistro: FormGroup;
  manipulador: ManipuladorDeAlimento;
  restauranteId: number;

  constructor(private formBuilder: FormBuilder,
    public activeModal: NgbActiveModal,
    private servicioManipulador: ManipuladorService,
    private mensajes: Mensajes,
    private servicioRestaurante: ServicioRestaurante) { }

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
    this.restaurantes = [];
    this.servicioRestaurante.Consultar().subscribe(result => {
      if (!result.error) {
        this.restaurantes = result.elementos;
      }
    });
    this.manipulador = new ManipuladorDeAlimento()
  }

  Registrar() {
    var index = this.restaurantes.findIndex(r => r.nombre == this.nombreRestaurante.value);
    this.manipulador.identificacion = this.restaurantes[index].nit;
    this.servicioManipulador.Guardar(this.manipulador).subscribe(r => {
      if (!r.error) {
        this.manipulador = r.elemento;
        this.mensajes.Mostrar("¡Operación exitosa!", r.mensaje);
      }
      else this.mensajes.Mostrar("¡Oh no!", r.mensaje);
    });
  }

  EstablecerValidacionesFormulario() {
    this.formularioRegistro = this.formBuilder.group(
      {
        identificacion: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(11)]],
        nombres: ['', [Validators.required]],
        primerApellido: ['', [Validators.required, Validators.maxLength(30)]],
        segundoApellido: ['', [Validators.required, Validators.maxLength(30)]],
        sexo: ['', [Validators.required]],
        edad: [, [Validators.required]],
        paisDeProcedencia: ['', [Validators.required]],
        estadoCivil: ['', [Validators.required]],
        nivelEducativo: ['', [Validators.required]],
        nombreRestaurante: ['', [Validators.required]]
      }
    );
  }

  get identificacion() { return this.formularioRegistro.get('identificacion'); }
  get nombres() { return this.formularioRegistro.get('nombres'); }
  get primerApellido() { return this.formularioRegistro.get('primerApellido'); }
  get segundoApellido() { return this.formularioRegistro.get('segundoApellido'); }
  get sexo() { return this.formularioRegistro.get('sexo'); }
  get edad() { return this.formularioRegistro.get('edad'); }
  get paisDeProcedencia() { return this.formularioRegistro.get('paisDeProcedencia'); }
  get estadoCivil() { return this.formularioRegistro.get('estadoCivil'); }
  get nivelEducativo() { return this.formularioRegistro.get('nivelEducativo'); }
  get nombreRestaurante() { return this.formularioRegistro.get('nombreRestaurante'); }
}
