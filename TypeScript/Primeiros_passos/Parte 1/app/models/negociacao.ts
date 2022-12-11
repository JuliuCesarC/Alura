export class Negociacao {
  // No 'Negociacao_01' as variáveis foram setadas de maneira muito parecida com outras linguagens, porem com o TypeScript podemos omitir a declaração e a atribuição. Dessa forma fazemos a declaração ja dentro do construtor.
  constructor(
    private _data: Date,
    // Anteriormente no 'Negociacao_01' declaramos as variáveis privadas e criamos um 'get' para poder ter acesso ao valor dessas variáveis. Outra maneira de obiter este resultado é utilizando o 'readonly', uma vez criada pode ser lida mas não alterada.
    public readonly _quantidade: number,
    public readonly _valor: number
  ) {}

  // PROGRAMAÇÃO DEFENSIVA
  // O objeto 'Date' no Javascript é um caso aparte do 'readonly', pois ele é um objeto mutável, dessa forma mesmo declarando uma variável como privada, e passando o valor dela através de um get, o objeto Date tera os métodos específicos dele, e alguns desses métodos possibilitam alterar seu valor, o que quebra completamente a regra de negocio.
  get data(): Date {
    // Para resolver este problema, ao invés de retornar o valor original do Date, retornaremos um cópia desse valor.
    const date = new Date(this._data.getTime())
    return date;
  }
  get volume(): number {
    return this._quantidade * this._valor;
  }
} 
// ---------- // ----------
export class Negociacao_01 {
  // No Javascript podemos declarar uma variável privada(ou seja não pode ser alterada ou acessada por fora da classe) com o '#variável', porem o TypeScrip recomenda utilizar os métodos da própria linguagem, que seria o 'private'.
  private _data: Date;
  // Porem o arquivo Javascript resultante não sera um onde as variáveis foram declaradas com o '#', e sim uma declaração normal onde é possível ler e alterar os valores.
  // O intuito do TypeScript é garantir que durante a fase de produção do programa, não seja possível adicionar um código semanticamente incorreto. Ou seja, mesmo que o arquivo Javascript seja desprovido do método privado, o compilador não autorizara adicionarmos um código que tenta acessar uma variável privada.
  private _quantidade: number;
  private _valor: number;
  constructor(data: Date, quantidade: number, valor: number) {
    // O 'Type' vem de 'tipagem', ou seja, o grande diferencial do TypeScrip é poder 'tipar' as variáveis, dessa forma garantindo melhor funcionamento das regras de negócios. Por exemplo o campo 'quantidade' precisa retornar um numero, por isso 'quantidade: number'.
    this._data = data;
    this._quantidade = quantidade;
    this._valor = valor;
  }
  get data(): Date {
    return this._data;
  }
  get quantidade(): number {
    return this._quantidade;
  }
  get valor(): number {
    return this._valor;
  }
  get volume(): number {
    return this._quantidade * this._valor;
  }
}
