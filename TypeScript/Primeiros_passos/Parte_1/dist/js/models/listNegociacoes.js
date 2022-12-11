export class ListNegociacoes {
    constructor() {
        // private listNegociacoes: Array<Negociacao> = []
        // Ao "tiparmos" a variável 'listNegociacoes' como 'Array<Negociacao>', isso faz com que só seja possível atribuir valores vindo do objeto 'Negociacao'. 
        // É possível também declarar a variável acima, utilizando um método menos verboso:
        this.listNegociacoes = [];
    }
    adiciona(negociacao) {
        // Para garantir que o valor vindo ao executar o método 'adiciona' seja um valor de 'Negociacao', então precisamos 'tipar' também o parâmetro como foi feito acima.
        this.listNegociacoes.push(negociacao);
    }
    // O método abaixo retorna um objeto contendo a informação da variável privada, porem se ele retorna um objeto, ele retorna a referencia junto, dessa forma ao executar o método 'lista', nos podemos alterar a variável de fora da classe.
    // lista(): Array<Negociacao>{
    //   return this.listNegociacoes;
    // }
    // Para resolver esse problema utilizaremos o tipo 'ReadOnlyArray', que como sugere é um array que só pode ser lido.
    lista() {
        return this.listNegociacoes;
    }
}
