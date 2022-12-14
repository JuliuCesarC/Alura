import { Inspect } from "../decorators/Inspect.js";

// -------------------- Exe 01 --------------------
export abstract class View<T> {
  protected Element: HTMLElement;

  constructor(selector: string) {
    const element: Element | null = document.querySelector(selector);
    if (element) {
      this.Element = element as HTMLElement;
    } else {
      throw Error(`Seletor "${selector}" não existe.`);
    }
  }
  protected abstract template(model: T): string;
  public update(model: T): void {
    let template = this.template(model);
    this.Element.innerHTML = template;
  }
}
