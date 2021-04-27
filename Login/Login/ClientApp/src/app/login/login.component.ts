import { Component } from '@angular/core';
import { Token } from '../../modulos/token';
import { Usuario } from '../../modulos/usuario';
import { UsuarioService } from '../../servicos/usuario.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  public mensagem: string;
  public login: Usuario;
  constructor(public usuarioService: UsuarioService) {
    this.login = new Usuario();
    this.login.token = new Token();
    this.mensagem = "";
  }
  RealizeLogin() {
    debugger;
    if (!this.login && !this.login.senha) {
      this.mensagem = "Não há dados nos campos de login ou senha.";
    }
    else if (this.login.nome.length > 10 || this.login.senha.length == 0 || this.login.senha.length > 8 || this.login.senha.length < 6) {
      this.mensagem = "Dados passados como usuário ou senha são inválidos.";
    }
    else {
      this.usuarioService.RealizeLogin(this.login.nome, this.login.senha).subscribe(retorno => {
        if (retorno && retorno.length > 36) {
          this.mensagem = 'Você está logado';
          window.location.href = 'http://localhost:54072';
        }
        else {
          this.mensagem = 'Dados Inválidos';
          if (retorno && retorno.length > 0) {
            this.mensagem = retorno;
          }
        }
      });
    }
  }
}
