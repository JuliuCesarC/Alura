// ---------- Exe 02 ----------
// Com o 'abstract' garantimos que não seja possível criar uma instancia diretamente de View, somente do filho que estende de View. 
export abstract class View<T>{

  protected element: HTMLElement;

  constructor(selector: string){
    this.element = document.querySelector(selector)
  }
  // Dentro de uma classe abstrata, é possível criar um ou mais métodos abstratos. 
  // O que significa que a classe pai não sabe como sera implementado o método, isso é responsabilidade do filho, dessa forma o compilador mostrara um erro caso a classe filha não implemente, ou implemente de maneira errada o método.
  abstract template(model: T): string;

  update(model: T): void{
    const template = this.template(model)
    this.element.innerHTML = template
  }
}
// ---------- Exe 01 ----------
// Como os 2 arquivos 'Dealing' e 'Message' possuíam o constructor e o método update muito semelhantes, então criamos uma classe genérica com essas informações, e estendemos essas 2 classes do elemento pai('View').
export class View_01<T>{
  // Porém no Dealing o tipo era 'DealingList' e no Message o tipo era 'string', então precisamos definir um tipo Generic, que no caso é o "<T>". Esse tipo generic sera utilizado no template e no update.
  // Quando a classe filha estender do pai, devera ser definido o tipo, pois esse tipo que ira para o "<T>".
  protected element: HTMLElement;

  constructor(selector: string){
    this.element = document.querySelector(selector)
  }
  template(model: T): string{
    throw Error('Classe filha não configurada!')
  }
  update(model: T): void{
    const template = this.template(model)
    this.element.innerHTML = template
  }
}