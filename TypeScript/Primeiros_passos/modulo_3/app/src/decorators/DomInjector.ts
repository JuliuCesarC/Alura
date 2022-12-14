// -------------------- Exe 02 --------------------
export function DomInjector(selector: string){
  return function(target: any, propertyKey: string){
    // Uma inconveniência desse Decorator é que todas vez que for acessado as propriedades o método 'getter' sera executado e precisara ir la no dom buscar o elemento. Para corrigir isto podemos criar um pequeno cache.
    let element: HTMLElement;
    // É preciso criar a variável no escopo da função, pois ela é adicionada no momento que a classe é declarada, ja o getter só é executado no momento do acesso à propriedade.
    const getter = function(){
      if(!element){
        element = document.querySelector(selector) as HTMLElement;
        console.log(`Seletor "${selector}" para injetar em "${propertyKey}"`);      
      }
      return element
      // Caso já tenha sido buscado o elemento uma vez, então é preciso apenas retornar novamente esse elemento em um novo acesso da propriedade.
    }
    Object.defineProperty(target, propertyKey, {get: getter})
  }
}
// -------------------- Exe 01 --------------------
// Até o momento os outros Decorators foram criados para serem utilizados nos métodos das classes, esse por outro lado é para ser utilizado em uma propriedade. Este Decorator é aplicado assim que a classe é declarada.
export function DomInjector_01(selector: string){
  return function(target: any, propertyKey: string){
    // Caso o 'target' for utilizado em uma propriedade estática, ele retornara a função construtora dessa classe, caso seja utilizado em um propriedade não estática, então ele retornara o 'prototype' dessa classe. 
    // Isso significa que não temos uma referência para a instancia da propriedade da classe aonde foi aplicado o Decorator, e sem acesso à instancia, não podemos atribuir um novo valor a essa propriedade.

    // Uma maneira de sobrepor esse problema é modificando o 'prototype', transformando as propriedades dele em um 'getter', pois o getter somente sera executado em runtime, e ao ser executado ele fornece acesso à instancia da propriedade da classe.

    const getter = function(){
      // Lembrando novamente que a função que atribuímos ao getter precisa ser uma função anônima.
      console.log(`Seletor "${selector}" para injetar em "${propertyKey}"`);      
      const element = document.querySelector(selector) as HTMLElement;
      return element
    }

    // Como temos o 'prototype' da propriedade, então podemos alterar ela através do método 'Object.defineProperty'. 
    Object.defineProperty(target, propertyKey, {get: getter})
    // Passamos o prototype(target), o nome da propriedade(propertyKey) e um objeto contendo o método(get: getter) que queremos setar. Dessa forma quando as propriedades que o Decorator foi aplicado forem acessadas, executaram os comando do 'getter'. 
  }
}