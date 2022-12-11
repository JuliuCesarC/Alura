export class Negociacao {
    // No 'Negociacao_01' as variáveis foram setadas de maneira muito parecida com outras linguagens, porem com o TypeScript podemos omitir a declaração e a atribuição. Dessa forma fazemos a declaração ja dentro do construtor.
    constructor(_data, 
    // Anteriormente no 'Negociacao_01' declaramos as variáveis privadas e criamos um 'get' para poder ter acesso ao valor dessas variáveis. Outra maneira de obiter este resultado é utilizando o 'readonly', uma vez criada pode ser lida mas não alterada.
    _quantidade, _valor) {
        this._data = _data;
        this._quantidade = _quantidade;
        this._valor = _valor;
    }
    // PROGRAMAÇÃO DEFENSIVA
    // O objeto 'Date' no Javascript é um caso aparte do 'readonly', pois ele é um objeto mutável, dessa forma mesmo declarando uma variável como privada, e passando o valor dela através de um get, o objeto Date tera os métodos específicos dele, e alguns desses métodos possibilitam alterar seu valor, o que quebra completamente a regra de negocio.
    get data() {
        // Para resolver este problema, ao invés de retornar o valor original do Date, retornaremos um cópia desse valor.
        const date = new Date(this._data.getTime());
        return date;
    }
    get volume() {
        return this._quantidade * this._valor;
    }
}
// ---------- // ----------
export class Negociacao_01 {
    constructor(data, quantidade, valor) {
        // O 'Type' vem de 'tipagem', ou seja, o grande diferencial do TypeScrip é poder 'tipar' as variáveis, dessa forma garantindo melhor funcionamento das regras de negócios. Por exemplo o campo 'quantidade' precisa retornar um numero, por isso 'quantidade: number'.
        this._data = data;
        this._quantidade = quantidade;
        this._valor = valor;
    }
    get data() {
        return this._data;
    }
    get quantidade() {
        return this._quantidade;
    }
    get valor() {
        return this._valor;
    }
    get volume() {
        return this._quantidade * this._valor;
    }
}
