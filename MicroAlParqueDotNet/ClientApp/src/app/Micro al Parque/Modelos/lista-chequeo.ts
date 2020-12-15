import { RespuestaChequeo } from "./respuesta-chequeo";

export class ListaChequeo {
  listaChequeoId : number;
  respuestaChequeos : RespuestaChequeo []= [];
  fecha : Date;
  idRestaurante: number;
  porcentajeCumplimiento : number;
}
