var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Inspect } from "../decorators/Inspect.js";
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
__decorate([
    Inspect()
], View.prototype, "update", null);
