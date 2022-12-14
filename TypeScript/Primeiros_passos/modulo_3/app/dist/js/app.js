import { Controller } from "./controllers/Controller.js";
const controller = new Controller();
const form = document.querySelector('.form');
if (form) {
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        controller.addToList();
    });
}
else {
    throw Error('Elemento "form" não criado.');
}
const btnImport = document.querySelector('#btn_Import');
if (btnImport) {
    btnImport.addEventListener('click', () => {
        controller.importData();
    });
}
else {
    throw Error('Botão importar não encontrado.');
}
//# sourceMappingURL=app.js.map