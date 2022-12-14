export class View {
    constructor(selector) {
        const element = document.querySelector(selector);
        if (element) {
            this.Element = element;
        }
        else {
            throw Error(`Seletor "${selector}" não existe.`);
        }
    }
    update(model) {
        let template = this.template(model);
        this.Element.innerHTML = template;
    }
}
