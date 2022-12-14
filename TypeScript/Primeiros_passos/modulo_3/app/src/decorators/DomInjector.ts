// Até o momento os outros Decorators foram criados para serem utilizados nos métodos das classes, esse por outro lado é para ser utilizado em uma propriedade.
export function DomInjector(selector: string){
  return function(target: any, propertyKey: string){
    // Caso o 'target' for utilizado em uma propriedade estática, ele retornara a função construtora dessa classe, caso seja utilizado em um propriedade não estática, então ele retornara o 'prototype' dessa classe. 
    // Isso significa que não temos uma referência para a instancia da propriedade da classe aonde foi aplicado o Decorator, e sem acesso à instancia, não podemos atribuir um novo valor a essa propriedade.

    // Uma maneira de sobrepor esse problema é modificando o 'prototype', transformando as propriedades dele em um 'getter', pois o getter somente sera executado em runtime, e ao ser executado ele fornece acesso à instancia da propriedade da classe.

    const getter = function(){
      
    }
  }
}