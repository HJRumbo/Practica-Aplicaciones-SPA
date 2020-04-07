import { Injectable, Inject } from '@angular/core';
import { Datos } from '../copago/models/datos';
import { Observable } from 'rxjs';
import { catchError, tap} from 'rxjs/operators';
import { HttpClient} from '@angular/common/http';
import { HandleHttpErrorService} from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class DatosService {

  baseUrl: string;

  constructor(

  private http: HttpClient,

  @Inject('BASE_URL') baseUrl: string,

  private handleErrorService: HandleHttpErrorService)

  {

  this.baseUrl = baseUrl;

  }

    get(): Observable<Datos[]> {

      return this.http.get<Datos[]>(this.baseUrl + 'api/Datos')
    
      .pipe(
    
      tap(_ => this.handleErrorService.log('datos enviados')),
    
      catchError(this.handleErrorService.handleError<Datos[]>('Consulta Datos', null))
    
      );
    
    }

    post(datos: Datos): Observable<Datos> {

      return this.http.post<Datos>(this.baseUrl + 'api/Datos', datos)
        .pipe(

          tap(_ => this.handleErrorService.log('datos enviados')),
      
          catchError(this.handleErrorService.handleError<Datos>('Registrar Datos', null))

    );

  }
}
