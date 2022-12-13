import { Inspect } from "../decorators/Inspect.js";

// -------------------- Exe 01 --------------------
export abstract class View<T> {
  protected Element: HTMLElement;
  private safeMode = false;

  constructor(selector: string, safeMode?: boolean) {
    const element: Element | null = document.querySelector(selector);
    if (element) {
      this.Element = element as HTMLElement;
    } else {
      throw Error(`Seletor "${selector}" não existe.`);
    }
    if (safeMode) {
      this.safeMode = safeMode;
    }
  }
  protected abstract template(model: T): string;
  @Inspect()
  public update(model: T): void {
    let template = this.template(model);
    if (this.safeMode) {
      template = template.replace(/<script>[\s\S]*?<\/script>/, "");
    }
    this.Element.innerHTML = template;
  }
}
