// ---------- Exe 02 ----------
// Com o 'abstract' garantimos que não seja possível criar uma instancia diretamente de View, somente do filho que estende de View. 
export class View {
    constructor(selector) {
        this.element = document.querySelector(selector);
    }
    update(model) {
        const template = this.template(model);
        this.element.innerHTML = template;
    }
}
// ---------- Exe 01 ----------
// Como os 2 arquivos 'Dealing' e 'Message' possuíam o constructor e o método update muito semelhantes, então criamos uma classe genérica com essas informações, e estendemos essas 2 classes do elemento pai('View').
export class View_01 {
    constructor(selector) {
        this.element = document.querySelector(selector);
    }
    template(model) {
        throw Error('Classe filha não configurada!');
    }
    update(model) {
        const template = this.template(model);
        this.element.innerHTML = template;
    }
}
