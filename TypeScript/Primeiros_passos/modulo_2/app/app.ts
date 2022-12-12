import { Controller } from "./controllers/Controller.js";

const controller = new Controller()
const form = document.querySelector('.form')
if(form){
  form.addEventListener('submit', (e)=>{
      e.preventDefault()
      controller.addToList()
  })
}else{
  throw Error('Elemento "form" não criado.')
}

