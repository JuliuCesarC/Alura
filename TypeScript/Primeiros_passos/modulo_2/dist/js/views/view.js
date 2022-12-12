export class View {
    constructor(selector, safeMode) {
        this.safeMode = false;
        const element = document.querySelector(selector);
        if (element) {
            this.Element = element;
        }
        else {
            throw Error(`Seletor "${selector}" não existe.`);
        }
        if (safeMode) {
            this.safeMode = safeMode;
        }
    }
    update(model) {
        let template = this.template(model);
        if (this.safeMode) {
            template = template.replace(/<script>[\s\S]*?<\/script>/, "");
        }
        this.Element.innerHTML = template;
    }
}
export class View_02 {
    constructor(selector) {
        const element = document.querySelector(selector);
        if (element) {
            this.element = element;
        }
        else {
            throw Error(`Seletor "${selector}" não existe.`);
        }
    }
    update(model) {
        const template = this.template(model);
        this.element.innerHTML = template;
    }
}
export class View_01 {
    constructor(selector) {
        const element = document.querySelector(selector);
        if (element) {
            this.element = element;
        }
        else {
            throw Error(`Seletor "${selector}" não existe.`);
        }
    }
    template(model) {
        throw Error("Classe filha não configurada!");
    }
    update(model) {
        const template = this.template(model);
        this.element.innerHTML = template;
    }
}
