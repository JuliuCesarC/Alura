import { Negociacao } from "./negociacao.js";

export class ListNegociacoes{
  private listNegociacoes: Array<Negociacao> = []

  adiciona(negociacao: Negociacao){
    this.listNegociacoes.push(negociacao)
  }
  // O método abaixo retorna um objeto contendo a informação da variável privada, porem se ele retorna um objeto, ele retorna a referencia junto, dessa forma ao executar o método 'lista', nos podemos alterar a variável de fora da classe.
  // lista(): Array<Negociacao>{
  //   return this.listNegociacoes;
  // }
  // Para resolver esse problema utilizaremos o tipo 'ReadOnlyArray', que como sugere é um array que só pode ser lido.
  lista(): ReadonlyArray<Negociacao>{
    return this.listNegociacoes;
  }
}