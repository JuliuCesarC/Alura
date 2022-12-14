export function LogRuntime(Seconds = false) {
    return function (target, propertyKey, descriptor) {
        const originalMethod = descriptor.value;
        descriptor.value = function (...args) {
            let divider = 1;
            let unit = 'milissegundos';
            if (Seconds) {
                divider = 1;
                unit = 'milissegundos';
            }
            const time1 = performance.now();
            const RetornoOriginal = originalMethod.apply(this, args);
            const time2 = performance.now();
            console.log(`${propertyKey}, tempo de execução: ${(time2 - time1) / divider} ${unit}`);
            RetornoOriginal;
        };
        return descriptor;
    };
}
export function LogRuntime_02() {
    return function (target, propertyKey, descriptor) {
        const originalMethod = descriptor.value;
        descriptor.value = function (...args) {
            const time1 = performance.now();
            const RetornoOriginal = originalMethod.apply(this, args);
            const time2 = performance.now();
            console.log(`${propertyKey}, tempo de execução: ${(time2 - time1) / 1000} segundos`);
            RetornoOriginal;
        };
        return descriptor;
    };
}
export function LogRuntime_01() {
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
//# sourceMappingURL=LogRuntime.js.map