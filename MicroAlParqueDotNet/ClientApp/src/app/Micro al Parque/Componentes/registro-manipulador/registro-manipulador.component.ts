import { Component, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { MiEstadoDeError } from "../../Modelos/EstadoDeError";
import { ManipuladorDeAlimento } from "../../Modelos/manipulador-de-alimento";
import { ManipuladorService } from "../../Servicios/manipulador.service";
import { Mensajes } from "../../Servicios/mensajes";


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

  segundoGrupoFormulario: FormGroup;
  tercerGrupoFormulario: FormGroup;
  isEditable = true;

  constructor(
    private formBuilder: FormBuilder,
    public activeModal: NgbActiveModal,
    private servicioManipulador: ManipuladorService,
    private mensajes: Mensajes
  ) {}

  ngOnInit(): void {
    this.EstablecerValidacionesFormulario();
    this.manipulador = new ManipuladorDeAlimento();
  }

  Registrar() {
    this.manipulador.sedeId = this.sedeId;
    this.servicioManipulador.Guardar(this.manipulador).subscribe((r) => {
      if (!r.error) {
        this.manipulador = r.elemento;
        this.mensajes.Mostrar("¡Operación exitosa!", r.mensaje);
      } else this.mensajes.Mostrar("¡Oh no!", r.mensaje);
    });
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
      firstCtrl: ["", Validators.required],
    });
    this.tercerGrupoFormulario = this.formBuilder.group({
      secondCtrl: ["", Validators.required],
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
}
