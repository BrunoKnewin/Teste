import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Cidade } from '../modulos/cidade';
@Injectable({
  providedIn: 'root'
})
export class CidadeService {
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
  Inclui(cidade : Cidade): Observable<Cidade> {
    return this.http.post<Cidade>('Cidade/IncluiCidade', JSON.stringify(cidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  Altera(cidade: Cidade): Observable<Cidade> {
    return this.http.post<Cidade>('Cidade/AlteraCidade', JSON.stringify(cidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  Pesquisa(cidade: Cidade): Observable<[Cidade]> {
    return this.http.post<[Cidade]>('Cidade/PesquisaCidade', JSON.stringify(cidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  Busca(cidade: Cidade): Observable<Cidade> {
    return this.http.post<Cidade>('Cidade/BuscaCidade', JSON.stringify(cidade), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
  }
  //POST
  Remove(cidadeId: number): Observable<boolean> {
    return this.http.post<boolean>('Cidade/RemoveCidade', JSON.stringify({ cidadeId: cidadeId}), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
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
