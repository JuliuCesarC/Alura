import { View } from "./view.js";

export class MessageAdd extends View<string>{
  // Ao estendermos da classe View, passamos para ela o tipo <string>, que sera utilizado no tipo Generic do View.
  
  protected template(model: string){
    // Declaramos o método 'template' como protected pois não queremos que ele seja acessado externamente, a única função que deve ser executada é a função 'update'.
    return`
      <p class="alert alert-info">${model}</p>
    `
  }

}