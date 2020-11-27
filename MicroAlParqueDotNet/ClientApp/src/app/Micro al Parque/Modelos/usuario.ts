import { Persona } from "./persona";

export class Usuario extends Persona {
  nombreUsuario: string;
  contraseña: string;
  email: string;
  rol: string;
}
