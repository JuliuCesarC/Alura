// -------------------- Exe 03 --------------------
export function LogRuntime(Seconds : boolean = false){
  return function(
    target: any,
    propertyKey:string,
    descriptor: PropertyDescriptor
  ){
    const originalMethod = descriptor.value;
    // Detalhe, a função que iremos atribuir para o descriptor precisa ser uma função anonima, pois uma arrow function tornaria o this léxico.
    descriptor.value = function(...args: any[]){
      let divider = 1;
      let unit = 'milissegundos'
      if(Seconds){
        divider = 1;
        unit = 'milissegundos'
      }
      const time1 = performance.now()
      const RetornoOriginal = originalMethod.apply(this, args)
      const time2 = performance.now()
      console.log(`${propertyKey}, tempo de execução: ${(time2 - time1)/divider} ${unit}`);
      RetornoOriginal
    }
    return descriptor
  }
}
// -------------------- Exe 02 --------------------
export function LogRuntime_02(){
  return function(
    target: any,
    propertyKey:string,
    descriptor: PropertyDescriptor
  ){
    // Como este é um Decorator que tem como intuito medir a performance da aplicação, e, o método 'descriptor.value' recebe as funções do método ao qual o decorator foi aplicado(addToList). então precisamos sobrescrever o 'descriptor.value' mas também salvando as informações originais dele, que foi feito abaixo:
    const originalMethod = descriptor.value;
    
    // Agora sobrescrevemos o 'descriptor.value' e adicionamos os códigos da funcionalidade desejada.
    descriptor.value = function(...args: any[]){
      const time1 = performance.now()
      // Para medir a performance precisamos executar todos os códigos do método onde foi aplicado o Decorator entre as 2 funções 'performance.now'. Por isso salvamos as funções do método 'addToList' na constante 'originalMethod'.
      const RetornoOriginal = originalMethod.apply(this, args)
      // ----- IMPORTANTE -----
      // TODO ESSE BLOCO DE FUNÇÕES que passamos para o 'descriptor.value' substituirá o método 'addToList' lá no arquivo 'Controller', e as funções desse método serão passadas como argumento para o 'originalMethod', o problema é que os 'this' utilizados nessas funções perderam o contexto, por isso utilizamos o 'apply'.
      // O que o 'apply' faz é informar o contexto para as funções que serão executadas no 'originalMethod', pois como informado acima, esse bloco de comando sera suplantado lá na classe Controller, então o 'this' que passamos para o 'apply' é o contexto dessa classe. O segundo parâmetro do apply é um array contento os argumentos, que nesse caso são as funções do 'addToList'.
      const time2 = performance.now()
      console.log(`${propertyKey}, tempo de execução: ${(time2 - time1)/1000} segundos`);
      // Por fim caso ao executar o 'originalMethod' ele possua algum retorno, então ao final do código retornamos esse retorno, como foi feito abaixo:
      RetornoOriginal
    }
    return descriptor
  }
}
// -------------------- Exe 01 --------------------
export function LogRuntime_01(){
  return function(
    target: any,
    // O 'target' recebe um objeto contendo todos os métodos da classe alvo onde o Decorator foi aplicado, até mesmo o método 'constructor'.
    propertyKey:string,
    // O 'propertyKey' recebe o nome do método ao qual o Decorator foi aplicado, no nosso caso o método 'addToList'.
    descriptor: PropertyDescriptor
    // O 'descriptor' recebe um objeto com alguns parâmetros e a função inteira do método ao qual foi aplicado o Decorator.
  ){
    const originalMethod = descriptor.value;
    // O 'descriptor.value' recebe a função aonde o 'decorator' foi chamado, no caso deste projeto temos um no arquivo 'Controller' aplicado no método 'addToList'.
    
    descriptor.value = function(...args: any[]){
      // Como este é um Decorator genérico e pode ser utilizado em vários métodos para testar a performance, não temos como saber quantos parâmetros o método ao qual iremos aplicar o Decorator possui, por isso utilizamos o parâmetro Rest(...args).
      // O que o '...args' faz é colocar todos os parâmetros em um array.
      const time1 = performance.now()
      // O método 'performance' existe em praticamente todos os navegadores e é muito utilizado para testar a performance da pagina, aplicando ele em 2 pontos da pagina podemos saber quanto tempo levou do ponto A ao ponto B.
      const Return = originalMethod.apply(this, args)
      const time2 = performance.now()
      console.log(`${propertyKey}, tempo de execução: ${(time2 - time1)/1000} segundos`);
      // Após executar o método original imprimimos o nome da função, pois esse Decorator pode ser aplicado em múltiplos métodos, e, a diferença de tempo entre o começo e o final dessa execução
      Return
    }
    return descriptor
  }
}
