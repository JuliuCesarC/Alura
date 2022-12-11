import { Controller } from "./controllers/Controller.js";

const controller = new Controller()
const form = document.querySelector('.form')
form.addEventListener('submit', (e)=>{
    e.preventDefault()
    controller.addToList()
})

