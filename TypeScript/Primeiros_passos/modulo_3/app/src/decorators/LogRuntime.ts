// -------------------- Exe 02 --------------------
export function LogRuntime(){
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
      // 
      const Return = originalMethod.apply(this, args)
      const time2 = performance.now()
      console.log(`${propertyKey}, tempo de execução: ${(time2 - time1)/1000} segundos`);
      Return
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
