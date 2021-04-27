import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Usuario } from '../modulos/usuario';
import { Token } from '@angular/compiler/src/ml_parser/lexer';
@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  //Base url
  @Inject('BASE_URL') baseurl: string;
  usuarioSelecionado: Usuario;
  constructor(private http: HttpClient) { }
  //Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  usuarioLogado: Usuario;
  token: Token;
  //POST
  RealizeLogin(nome: string, senha: string): Observable<string> {
    return this.http.post<string>('Login/RealizeLogin', JSON.stringify({ nome: nome, senha: senha }), this.httpOptions).pipe(retry(1), catchError(this.errorHandl));
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
