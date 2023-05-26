import User from "./01-User.js";
import Admin from "./02-Admin.js";
import Teacher from "./03-Teacher.js";

const createUser = new User("Mari", "mari@gmail.com", "2000-07-06");
console.log(createUser.showInfos());

// Ao tentar acessar um campo privado como abaixo, o código sequer compila, pois não é possível acessar uma propriedade privada por fora da classe.
// console.log("Campo privado 'nome': " + createUser.#name);
