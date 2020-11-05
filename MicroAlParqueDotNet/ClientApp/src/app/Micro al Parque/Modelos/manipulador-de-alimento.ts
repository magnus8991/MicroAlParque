import { Respuesta } from "./respuesta";

export class ManipuladorDeAlimento {
  identificacion: string;
  nombres: string;
  primerApellido: string;
  segundoApellido: string;
  sexo: string;
  edad : number;
  estadoCivil: string;
  paisDeProcedencia: string;
  nivelEducativo: string;
  restauranteId: number;
  respuestas : Respuesta [] = [];
}
