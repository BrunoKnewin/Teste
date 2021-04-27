import { Component } from '@angular/core';
@Component({
  selector: 'app-palindromo',
  templateUrl: './palindromo.component.html',
})
export class PalindromoComponent {
  public palindromoEntrada: string;
  public ePalindromo: boolean;
  constructor() {
    this.palindromoEntrada = '';
    this.ePalindromo = null;
  }
  TestaPalindromo() {
    debugger;
    if (this.palindromoEntrada.length > 1) {
      let posicao = this.palindromoEntrada.length-1;
      let palavraSaida = '';
      for (var indice = 0; indice < this.palindromoEntrada.length; indice++) {
        palavraSaida += this.palindromoEntrada[posicao];
        posicao--;
      }
      this.ePalindromo = palavraSaida == this.palindromoEntrada;
    }
  }
}
