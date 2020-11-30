import { Injectable, Inject } from '@angular/core';
import { Pregunta } from '../Modelos/pregunta';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../../@base/handle-http-error.service';
import { Peticion, PeticionConsulta } from '../Modelos/peticion';

@Injectable({
  providedIn: 'root'
})
export class ServicioPregunta {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  Guardar(Pregunta: Pregunta): Observable<Peticion<Pregunta>> {
    return this.http.post<Peticion<Pregunta>>(this.baseUrl + 'api/Pregunta', Pregunta)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Peticion<Pregunta>>('Registrar Pregunta', null))
      );
  }

  Consultar(RestauranteId: string): Observable<PeticionConsulta<Pregunta>> {
    return this.http.get<PeticionConsulta<Pregunta>>(this.baseUrl + 'api/Pregunta/' + RestauranteId)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<PeticionConsulta<Pregunta>>('Consultar Pregunta', null))
      );
  }

  Buscar(IdPregunta: string): Observable<Peticion<Pregunta>> {
    return this.http.get<Peticion<Pregunta>>(this.baseUrl + 'api/Pregunta/' + IdPregunta)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Peticion<Pregunta>>('Buscar Pregunta', null))
      );
  }

  Modificar(PreguntaId: number, Pregunta: Pregunta): Observable<Peticion<Pregunta>> {
    return this.http.put<Peticion<Pregunta>>(this.baseUrl + 'api/Pregunta/' + PreguntaId, Pregunta)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Peticion<Pregunta>>('Actualizar Pregunta', null))
      );
  }

  Eliminar(NIT: string): Observable<Peticion<Pregunta>> {
    return this.http.delete<Peticion<Pregunta>>(this.baseUrl + 'api/Pregunta/' + NIT)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Peticion<Pregunta>>('Eliminar Pregunta', null))
      );
  }
}
