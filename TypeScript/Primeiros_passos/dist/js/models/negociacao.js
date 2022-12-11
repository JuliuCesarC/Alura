export class Negociacao {
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
