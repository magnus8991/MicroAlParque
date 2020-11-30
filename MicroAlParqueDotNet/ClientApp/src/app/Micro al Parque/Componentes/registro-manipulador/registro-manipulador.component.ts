import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { MiEstadoDeError } from "../../Modelos/EstadoDeError";
import { ManipuladorDeAlimento } from "../../Modelos/manipulador-de-alimento";
import { Peticion } from "../../Modelos/peticion";
import { Pregunta } from "../../Modelos/pregunta";
import { Respuesta } from "../../Modelos/respuesta";
import { ManipuladorService } from "../../Servicios/manipulador.service";
import { Mensajes } from "../../Servicios/mensajes";
import { ServicioPregunta } from "../../Servicios/pregunta.service";
import { RespuestaService } from "../../Servicios/respuesta.service";


@Component({
  selector: "app-registro-manipulador",
  templateUrl: "./registro-manipulador.component.html",
  styleUrls: ["./registro-manipulador.component.css"],
})
export class RegistroManipuladorComponent implements OnInit {
  @Input() sedeId: number;
  primerGrupoFormulario: FormGroup;
  manipulador: ManipuladorDeAlimento;
  error =  new MiEstadoDeError();
  submitted = false;
  segundoGrupoFormulario: FormGroup;
  tercerGrupoFormulario: FormGroup;
  cuartoGrupoFormulario: FormGroup;
  isEditable = true;
  respuestas : Respuesta[] = [];
  preguntas : Pregunta[] = [];

  constructor(
    private formBuilder: FormBuilder,
    public activeModal: NgbActiveModal,
    private servicioRespuesta : RespuestaService,
    private servicioPregunta : ServicioPregunta,
    private servicioManipulador: ManipuladorService,
    private mensajes: Mensajes
  ) {}

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
    this.manipulador = new ManipuladorDeAlimento();
    this.consultarPreguntas();
    this.crearRespuestas();
  }

  crearRespuestas()
  {
    for (let index = 0; index <= 15; index++) {
      let respuesta : Respuesta = new Respuesta();
      respuesta.contenidoRespuesta = "";
      respuesta.preguntaId = this.preguntas[index].preguntaId;
      this.respuestas.push(respuesta);
    }
  }

  consultarPreguntas ()
  {
    this.servicioPregunta.Consultar("Manipuladores").subscribe(p => {
      if(!p.error)
      {
        this.preguntas = p.elementos;
      }
      else this.mensajes.Mostrar("Oh no",p.mensaje);
    });
  }
  RegistrarManipulador() {
    this.manipulador.sedeId = this.sedeId;
    this.servicioManipulador.Guardar(this.manipulador).subscribe((r) => {
      if (!r.error) {
        this.manipulador = r.elemento;
        this.registrarListaRespuesta();
        this.mensajes.Mostrar("¡Operación exitosa!", r.mensaje);
        this.cerrar();
      } else this.mensajes.Mostrar("¡Oh no!", r.mensaje);
    });
  }

  registrarListaRespuesta ()
  {
    this.respuestas.forEach(respuesta => {
      respuesta.identificacion = this.manipulador.identificacion;
      this.RegistrarRespuesta(respuesta);
    });
  }

  RegistrarRespuesta(respuesta : Respuesta) {
    this.servicioRespuesta.Guardar(respuesta).subscribe((r) => {
      if (r.error) {
        this.mensajes.Mostrar("Oh no, Ha sucedido un error!", r.mensaje);
      }
    });
  }

  cerrar() {
    if (this.manipulador != null && this.respuestas !=null) this.activeModal.close(this.manipulador);
    else this.activeModal.close(null);
  }

  EstablecerValidacionesFormulario() {
    this.primerGrupoFormulario = this.formBuilder.group({
      identificacion: [
        "",
        [
          Validators.required,
          Validators.minLength(7),
          Validators.maxLength(11),
        ],
      ],
      nombres: ["", [Validators.required]],
      primerApellido: ["", [Validators.required, Validators.maxLength(30)]],
      segundoApellido: ["", [Validators.required, Validators.maxLength(30)]],
      sexo: ["", [Validators.required]],
      edad: [, [Validators.required]],
      paisDeProcedencia: ["", [Validators.required]],
      estadoCivil: ["", [Validators.required]],
      nivelEducativo: ["", [Validators.required]],
    });
    this.segundoGrupoFormulario = this.formBuilder.group({
      pregunta1: [, Validators.required],
      pregunta2: [, Validators.required],
      pregunta3: [, Validators.required],
      pregunta4: [, Validators.required],
      pregunta5: [, Validators.required],
      pregunta6: [, Validators.required]
    });
    this.tercerGrupoFormulario = this.formBuilder.group({
      pregunta7: ["", Validators.required],
      pregunta8: ["", Validators.required],
      pregunta9: ["", Validators.required],
      pregunta10: ["", Validators.required],
      pregunta11: ["", Validators.required],
      pregunta12: ["", Validators.required]
    });
    this.cuartoGrupoFormulario = this.formBuilder.group({
      pregunta13: ["", Validators.required],
      pregunta14: ["", Validators.required],
      pregunta15: ["", Validators.required],
      pregunta16: ["", Validators.required]
    });
  }

  get identificacion() {
    return this.primerGrupoFormulario.get("identificacion");
  }
  get nombres() {
    return this.primerGrupoFormulario.get("nombres");
  }
  get primerApellido() {
    return this.primerGrupoFormulario.get("primerApellido");
  }
  get segundoApellido() {
    return this.primerGrupoFormulario.get("segundoApellido");
  }
  get sexo() {
    return this.primerGrupoFormulario.get("sexo");
  }
  get edad() {
    return this.primerGrupoFormulario.get("edad");
  }
  get paisDeProcedencia() {
    return this.primerGrupoFormulario.get("paisDeProcedencia");
  }
  get estadoCivil() {
    return this.primerGrupoFormulario.get("estadoCivil");
  }
  get nivelEducativo() {
    return this.primerGrupoFormulario.get("nivelEducativo");
  }


  get pregunta1() {
    return this.segundoGrupoFormulario.get("pregunta1");
  }
  get pregunta2() {
    return this.segundoGrupoFormulario.get("pregunta2");
  }
  get pregunta3() {
    return this.segundoGrupoFormulario.get("pregunta3");
  }
  get pregunta4() {
    return this.segundoGrupoFormulario.get("pregunta4");
  }
  get pregunta5() {
    return this.segundoGrupoFormulario.get("pregunta5");
  }
  get pregunta6() {
    return this.segundoGrupoFormulario.get("pregunta6");
  }

  get pregunta7() {
    return this.tercerGrupoFormulario.get("pregunta7");
  }
  get pregunta8() {
    return this.tercerGrupoFormulario.get("pregunta8");
  }
  get pregunta9() {
    return this.tercerGrupoFormulario.get("pregunta9");
  }
  get pregunta10() {
    return this.tercerGrupoFormulario.get("pregunta10");
  }
  get pregunta11() {
    return this.tercerGrupoFormulario.get("pregunta11");
  }
  get pregunta12() {
    return this.tercerGrupoFormulario.get("pregunta12");
  }

  get pregunta13() {
    return this.tercerGrupoFormulario.get("pregunta13");
  }
  get pregunta14() {
    return this.tercerGrupoFormulario.get("pregunta14");
  }
  get pregunta15() {
    return this.tercerGrupoFormulario.get("pregunta15");
  }
  get pregunta16() {
    return this.tercerGrupoFormulario.get("pregunta16");
  }

}
