export function DomInjector(selector) {
    return function (target, propertyKey) {
        let element;
        const getter = function () {
            if (!element) {
                element = document.querySelector(selector);
                console.log(`Seletor "${selector}" para injetar em "${propertyKey}"`);
            }
            return element;
        };
        Object.defineProperty(target, propertyKey, { get: getter });
    };
}
export function DomInjector_01(selector) {
    return function (target, propertyKey) {
        const getter = function () {
            console.log(`Seletor "${selector}" para injetar em "${propertyKey}"`);
            const element = document.querySelector(selector);
            return element;
        };
        Object.defineProperty(target, propertyKey, { get: getter });
    };
}
