// -------------------- Exe 03 --------------------
export abstract class View<T> {
  protected Element: HTMLElement;
  private safeMode = false;

  // Dentro do construtor podemos adicionar uma '?' ao final da variável para que ela se torne opcional.
  // Por muitas vezes é preciso adicionar uma nova variável que sera utilizada por poucos arquivos, porem a classe já esta sendo "instanciada" em muitos outros, dessa forma utilizando a interrogação garantimos a utilização dessa nova variável, e que as outras instancias quebrem o código.
  constructor(selector: string, safeMode?: boolean) {
    const element: Element | null = document.querySelector(selector);
    // O 'element' pode receber um elemento ou null do 'querySelector', porem a variável 'Element' só pode receber um 'HTMLElement'. Para resolver isso precisamos de uma verificação.
    if (element) {
      this.Element = element as HTMLElement;
      // Caso retorne um elemento, forçamos ele com o 'HTMLElement'.
    } else {
      throw Error(`Seletor "${selector}" não existe.`);
      // Caso retorne null emitimos um erro exibindo o seletor.
    }
    if (safeMode) {
      this.safeMode = safeMode;
    }
  }

  protected abstract template(model: T): string;

  public update(model: T): void {
    let template = this.template(model);
    if (this.safeMode) {
      template = template.replace(/<script>[\s\S]*?<\/script>/, "");
    }
    this.Element.innerHTML = template;
  }
}
// -------------------- Exe 02 --------------------
// Com o 'abstract' garantimos que não seja possível criar uma instancia diretamente de View, somente do filho que estende de View.
export abstract class View_02<T> {
  protected element: HTMLElement;
  // A propriedade 'protected' permite que apenas a própria classe e as classes filhas possam acessar essa variável.

  constructor(selector: string) {
    const element = document.querySelector(selector);
    if (element) {
      this.element = element as HTMLElement;
    } else {
      throw Error(`Seletor "${selector}" não existe.`);
    }
  }
  // Dentro de uma classe abstrata, é possível criar um ou mais métodos abstratos.
  // Um método abstrato significa que a implementação das funcionalidades do método é de responsabilidade do filho, dessa forma o compilador mostrara um erro caso a classe filha não implemente, ou implemente de maneira errada o método.
  protected abstract template(model: T): string;

  public update(model: T): void {
    const template = this.template(model);
    this.element.innerHTML = template;
  }
}
// -------------------- Exe 01 --------------------
// Como os 2 arquivos 'Dealing' e 'Message' possuíam o constructor e o método update muito semelhantes, então criamos uma classe genérica com essas informações, e estendemos essas 2 classes do elemento pai('View').
export class View_01<T> {
  // Porém no Dealing o tipo era 'DealingList' e no Message o tipo era 'string', então precisamos definir um tipo Generic, que no caso é o "<T>". Esse tipo generic sera utilizado no template e no update.
  // Quando a classe filha estender do pai, devera ser definido o tipo, pois esse tipo que ira para o "<T>".
  protected element: HTMLElement;

  constructor(selector: string) {
    const element = document.querySelector(selector);
    if (element) {
      this.element = element as HTMLElement;
    } else {
      throw Error(`Seletor "${selector}" não existe.`);
    }
  }
  template(model: T): string {
    throw Error("Classe filha não configurada!");
  }
  update(model: T): void {
    const template = this.template(model);
    this.element.innerHTML = template;
  }
}
