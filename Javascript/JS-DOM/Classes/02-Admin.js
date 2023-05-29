import User from "./01-User.js"

export default class Admin extends User{
  constructor(name, email, birth, employed = true, role = "Manager"){
    super(name, email, birth, employed, role)
  }

  createCourse(name, vacancy){
    return `Curso de ${name} criado com ${vacancy} vagas.`
  }
  showInfos() {
    return `${this.name}, ${this.role}`;
  } 
}

// const newAdmin = new Admin('Lucilene', 'lulu@gmail.com', '1956-05-27')
// console.log(newAdmin.createCourse('Design', 20));