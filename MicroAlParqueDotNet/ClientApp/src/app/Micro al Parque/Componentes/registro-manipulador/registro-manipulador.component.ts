import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { ManipuladorDeAlimento } from "../../Modelos/manipulador-de-alimento";
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
  submitted = false;
  segundoGrupoFormulario: FormGroup;
  tercerGrupoFormulario: FormGroup;
  cuartoGrupoFormulario: FormGroup;
  isEditable = true;
  respuestas: Respuesta[] = [];
  preguntas: Pregunta[] = [];

  constructor(private formBuilder: FormBuilder, public activeModal: NgbActiveModal,
    private servicioRespuesta: RespuestaService, private servicioPregunta: ServicioPregunta,
    private servicioManipulador: ManipuladorService, private mensajes: Mensajes
  )
  {
    for (let i = 1; i <= 16; i++)
    {
      this.preguntas.push(new Pregunta()); this.respuestas.push(new Respuesta());
    }
  }

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
    this.InicializarPreguntasYRespuestas();
    this.manipulador = new ManipuladorDeAlimento();
  }

  crearRespuestas() {
    for (let index = 0; index < this.preguntas.length; index++) {
      this.respuestas[index].contenidoRespuesta = "";
      this.respuestas[index].preguntaId = this.preguntas[index].preguntaId;
    }
  }

  InicializarPreguntasYRespuestas() {
    this.servicioPregunta.Consultar("Manipuladores").subscribe(p => {
      if (!p.error) {
        this.preguntas = p.elementos;
        this.crearRespuestas();
      }
      else this.mensajes.Mostrar("Oh no", p.mensaje);
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

  registrarListaRespuesta() {
    this.respuestas.forEach(respuesta => {
      respuesta.identificacion = this.manipulador.identificacion;
      this.RegistrarRespuesta(respuesta);
    });
  }

  RegistrarRespuesta(respuesta: Respuesta) {
    this.servicioRespuesta.Guardar(respuesta).subscribe((r) => {
      if (r.error) {
        this.mensajes.Mostrar("Oh no, Ha sucedido un error!", r.mensaje);
      }
    });
  }

  cerrar() { this.activeModal.close(null); }

  EstablecerValidacionesFormulario() {
    this.primerGrupoFormulario = this.formBuilder.group({
      identificacion: ["", [Validators.required, Validators.pattern('^[0-9]+$'), Validators.minLength(7), Validators.maxLength(11)]],
      nombres: ["", [Validators.required, Validators.maxLength(30)]],
      primerApellido: ["", [Validators.required, Validators.maxLength(15)]],
      segundoApellido: ["", [Validators.required, Validators.maxLength(15)]],
      sexo: ["", Validators.required],
      edad: [0, Validators.required],
      paisDeProcedencia: ["", [Validators.required, Validators.maxLength(15)]],
      estadoCivil: ["", Validators.required],
      nivelEducativo: ["", Validators.required],
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
