export class Peticion <G>
{
  elemento : G;
  error : boolean
  mensaje : string;
}

export class PeticionConsulta <G>
{
  elementos : G[] = [];
  error : boolean
  mensaje : string;
}
