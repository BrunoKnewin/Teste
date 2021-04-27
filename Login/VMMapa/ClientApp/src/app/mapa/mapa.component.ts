import { Component } from '@angular/core';
import { Cidade } from '../../modulos/cidade';
import { FronteirasCidade } from '../../modulos/fronteirascidade';
import { LigacaoCidades } from '../../modulos/ligacaocidades';
import { CidadeService } from '../../servicos/Cidade.service';
import { FronteirasCidadeService } from '../../servicos/fronteirascidade.service';
@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
})
export class MapaComponent {
  public mensagem: string;
  public IncluirAlterar: boolean;
  public PesquisarAberta: boolean;
  public quantidadeHabitantes: number;
  public nomeCidade: string;
  public cidades: [Cidade];
  public cidadesFronteira: [Cidade];
  public fronteirasCidades: [FronteirasCidade];
  public fronteirasCidade: FronteirasCidade;
  public fronteirasCidadeCorrente: FronteirasCidade;
  public cidade: Cidade;
  public cidadeCaminho: [Cidade];
  public fronteira: Cidade;
  public fronteiraA: Cidade;
  public fronteiraB: Cidade;
  public ligacaoCidades: LigacaoCidades;
  constructor(public cidadeService: CidadeService, public fronteirasCidadeService: FronteirasCidadeService) {
    this.mensagem = '';
    this.nomeCidade = '';
    this.IncluirAlterar = false;
    this.PesquisarAberta = true;
    this.quantidadeHabitantes = 0;
    this.cidade = new Cidade();
    this.fronteira = new Cidade();
    this.fronteiraA = new Cidade();
    this.fronteiraB = new Cidade();
    this.fronteirasCidadeCorrente = new FronteirasCidade();
    this.fronteirasCidade = new FronteirasCidade();
    this.Pesquisa();
    this.ligacaoCidades = new LigacaoCidades();
  }
  //POST
  Pesquisa() {
    this.cidadeService.Pesquisa(this.cidade).subscribe(res => {
      this.cidades = res;
      this.quantidadeHabitantes = 0;
      this.mensagem = '';
      for (var indice = 0; indice < this.cidades.length; indice++) {
        this.quantidadeHabitantes += this.cidades[indice].habitantes;
      }
    });
  }
  PesquisaPorNome() {
    this.cidade = new Cidade();
    this.cidade.nome = this.nomeCidade;
    this.Pesquisa();
  }
  //POST
  Inclui() {
    this.cidadeService.Inclui(this.cidade).subscribe(res => {
      this.cidade = res;
      this.mensagem = "Cidade inclusa com sucesso!!";
      this.Pesquisa();
    });
  }
  //POST
  Altera() {
    this.cidadeService.Altera(this.cidade).subscribe(res => {
      this.cidade = res;
      this.mensagem = "Cidade alterada com sucesso!!";
      this.Pesquisa();
    });
  }
  //POST
  Busca() {
    this.cidadeService.Busca(this.cidade).subscribe(res => {
      this.cidade = res;
    });
  }
  //POST
  Remove(cidadeCorrente: Cidade) {
    if (cidadeCorrente && cidadeCorrente.codigo > 0) {
      this.cidadeService.Remove(cidadeCorrente.codigo).subscribe(res => {
        if (res)
          this.mensagem = "Removido com sucesso!!";
        else
          this.mensagem = "Falha ao remover o registro!!";
        this.Pesquisa();
      });
    }
  }
  RemoveFronteiraCidade(fronteirasCidadeCorrente: FronteirasCidade) {
    this.fronteirasCidade = fronteirasCidadeCorrente;
    this.fronteirasCidadeService.Remove(this.fronteirasCidade).subscribe(res => {
      this.fronteirasCidade = new FronteirasCidade();
      this.Pesquisa();
    });
  }
  SelecionaFronteira() {
    debugger;
    let seleciona = true;
    this.fronteirasCidadeCorrente.fronteiraId = this.fronteira.codigo;
    this.fronteirasCidadeCorrente.cidadeId = this.cidade.codigo;
    if (this.cidade.fronteirasCidade)
      for (var indice = 0; indice < this.cidade.fronteirasCidade.length; indice++) {
        if (this.cidade.fronteirasCidade[indice].fronteiraId == this.fronteira.codigo) {
          seleciona = false;
          break;
        }
      }
    if (seleciona) {
      if (!this.cidade.fronteirasCidade) {
        this.cidade.fronteirasCidade = [{
          fronteira: this.fronteira,
          cidadeId: !this.cidade.codigo ? 0 : this.cidade.codigo,
          codigo: 0,
          fronteiraId: this.fronteira.codigo
        }];
      }
      else {
          this.cidade.fronteirasCidade.push({
          fronteira: this.fronteira,
          cidadeId: !this.cidade.codigo ? 0 : this.cidade.codigo,
          codigo: 0,
          fronteiraId: this.fronteira.codigo});
      }
    }
    else {
      this.mensagem = "Fronteira seleciona já inclusa.";
    }
    this.fronteira = new Cidade();
  }
  RecarregaCidade(cidadeCorrente: Cidade) {
    this.cidadesFronteira = null;
    if (cidadeCorrente && cidadeCorrente.codigo > 0) {
      this.cidade = cidadeCorrente;
      for (var indice = 0; indice < this.cidades.length; indice++) {
        if (this.cidade.codigo != this.cidades[indice].codigo) {
          if (!this.cidadesFronteira) {
            this.cidadesFronteira = [{ codigo: this.cidades[indice].codigo, nome: this.cidades[indice].nome, habitantes: this.cidades[indice].habitantes, sequencia:null, fronteirasCidade: this.cidades[indice].fronteirasCidade }];
          }
          else {
            this.cidadesFronteira.push(this.cidades[indice]);
          }
        }
      }
    }
    else {
      this.cidade = new Cidade();
      this.cidadesFronteira = this.cidades;
    }
    this.IncluirAlterar = true;
  }
  RemoveFronteira(fronteirasCidadeCorrente: FronteirasCidade) {
    let existe = false;
    for (var indice = 0; indice < this.cidade.fronteirasCidade.length; indice++) {
      if (this.cidade.fronteirasCidade[indice].fronteiraId == this.fronteirasCidade.fronteiraId) {
        existe = true;
        this.mensagem = "Fronteira seleciona já inclusa.";
        break;
      }
    }
    if (existe) {
      this.RemoveFronteiraCidade(fronteirasCidadeCorrente);
    }
  }
  RetornaCaminho() {
    if (this.fronteiraA != this.fronteiraB) {
      this.ligacaoCidades.cidadeA = this.fronteiraA.codigo;
      this.ligacaoCidades.cidadeB = this.fronteiraB.codigo;
      this.fronteirasCidadeService.PesquisaCaminho(this.ligacaoCidades).subscribe(res => {
        this.cidadeCaminho = res;
        for (var indice = 0; indice < this.cidadeCaminho.length; indice++) {
          this.cidadeCaminho[indice].sequencia = indice + 1;
        }
      });
    }
  }
}
