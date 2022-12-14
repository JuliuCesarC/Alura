export function Print(...args) {
    for (let objeto of args) {
        console.log(objeto.convertToText());
    }
}
