import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reg-lista-chequeo',
  templateUrl: './reg-lista-chequeo.component.html',
  styleUrls: ['./reg-lista-chequeo.component.css']
})
export class RegistroEncuestaChequeoComponent implements OnInit {

  primerGrupoFormulario: FormGroup;
  segundoGrupoFormulario: FormGroup;
  isEditable = true;
  respuestas: RespuestaChequeo[] = [];
  preguntas: Pregunta[] = [];
  listaChequeo : ListaChequeo = new ListaChequeo();

  constructor
  (
    private formBuilder: FormBuilder,
    public activeModal: NgbActiveModal,
    private servicioRespuesta: ListaChequeoService,
    private servicioPregunta: ServicioPregunta,
    private mensajes: Mensajes
  )
  {
    for (let i = 1; i <= 9; i++)
    {
      this.preguntas.push(new Pregunta()); this.respuestas.push(new RespuestaChequeo());
    }
  }

  ngOnInit(): void {
    this.InicializarPreguntasYRespuestas();
  }

  crearRespuestas() {
    for (let index = 0; index < this.preguntas.length; index++) {
      this.respuestas[index].contenidoRespuesta = "";
      this.respuestas[index].preguntaId = this.preguntas[index].preguntaId;
    }
  }

  InicializarPreguntasYRespuestas() {
    this.servicioPregunta.Consultar("Lista de chequeo").subscribe(p => {
      if (!p.error) {
        this.preguntas = p.elementos;
        this.crearRespuestas();
      }
      else this.mensajes.Mostrar("Oh no", p.mensaje);
    });
  }

  RegistrarRespuesta() {
    this.listaChequeo.respuestaChequeos = this.respuestas;
    this.servicioRespuesta.Guardar(this.listaChequeo).subscribe((r) => {
      if (r.error) {
        this.mensajes.Mostrar("Oh no, Ha sucedido un error!", r.mensaje);
      }
    });
  }

  EstablecerValidacionesFormulario() {
    this.primerGrupoFormulario = this.formBuilder.group({
      pregunta1: [Validators.required],
      pregunta2: [,Validators.required],
      pregunta3: [,Validators.required],
      pregunta4: [,Validators.required],
      pregunta5: [,Validators.required],
    });
    this.segundoGrupoFormulario = this.formBuilder.group({
      pregunta6: [, Validators.required],
      pregunta7: [, Validators.required],
      pregunta8: [, Validators.required],
      pregunta9: [, Validators.required]
    });
  }

  get pregunta1() {
    return this.primerGrupoFormulario.get("pregunta1");
  }
  get pregunta2() {
    return this.primerGrupoFormulario.get("pregunta2");
  }
  get pregunta3() {
    return this.primerGrupoFormulario.get("pregunta3");
  }
  get pregunta4() {
    return this.primerGrupoFormulario.get("pregunta4");
  }
  get pregunta5() {
    return this.primerGrupoFormulario.get("pregunta5");
  }
  get pregunta6() {
    return this.segundoGrupoFormulario.get("pregunta6");
  }

  get pregunta7() {
    return this.segundoGrupoFormulario.get("pregunta7");
  }
  get pregunta8() {
    return this.segundoGrupoFormulario.get("pregunta8");
  }
  get pregunta9() {
    return this.segundoGrupoFormulario.get("pregunta9");
  }

}
