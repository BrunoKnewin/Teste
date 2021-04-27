import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { FronteirasCidade } from '../modulos/fronteirascidade';
import { LigacaoCidades } from '../modulos/ligacaocidades';
import { Cidade } from '../modulos/cidade';
@Injectable({
  providedIn: 'root'
})
export class FronteirasCidadeService {
  //Base url
  @Inject('BASE_URL') baseurl: string;
  constructor(private http: HttpClient) { }
  //Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  //POST
  Inclui(fronteirasCidade : FronteirasCidade): Observable<FronteirasCidade> {
    return this.http.post<FronteirasCidade>('FronteirasCidade/IncluiFronteirasCidade', JSON.stringify(fronteirasCidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  Remove(fronteirasCidade: FronteirasCidade): Observable<FronteirasCidade> {
    return this.http.post<FronteirasCidade>('FronteirasCidade/RemoveFronteirasCidade', JSON.stringify(fronteirasCidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  Pesquisa(fronteirasCidade: FronteirasCidade): Observable<FronteirasCidade> {
    return this.http.post<FronteirasCidade>('FronteirasCidade/PesquisaFronteirasCidade', JSON.stringify(fronteirasCidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  PesquisaCaminho(ligacaoCidades: LigacaoCidades): Observable<[Cidade]> {
    return this.http.post<[Cidade]>('Cidade/PesquisaCaminho', JSON.stringify(ligacaoCidades), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //Error handling
  errorHandl(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    }
    else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
