export function LogRuntime(){
  return function(
    target: any,
    propertyKey:string,
    descriptor: PropertyDescriptor
  ){
    const originalMethod = descriptor.value;
    descriptor.value = function(...args: any[]){
      const time1 = performance.now()
      // O método 'performance' existe em todos os navegadores e é muito utilizado para testar a performance da pagina, como tempo para mostrar um item na tela.
      const Return = originalMethod.apply(this, args)
      const time2 = performance.now()
      console.log(`${propertyKey}, tempo de execução: ${(time2 - time1)/1000} segundos`);
      Return
    }
    return descriptor
  }
}