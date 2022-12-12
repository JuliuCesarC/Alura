export function LogRuntime() {
    return function (target, propertyKey, descriptor) {
        const originalMethod = descriptor.value;
        descriptor.value = function (...args) {
            const time1 = performance.now();
            const Return = originalMethod.apply(this, args);
            const time2 = performance.now();
            console.log(`${propertyKey}, tempo de execução: ${(time2 - time1) / 1000} segundos`);
            Return;
        };
        return descriptor;
    };
}
