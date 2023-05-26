import User from "./01-User.js";

export default class Teacher extends User{
  constructor(name, email, birth, employed = true, role = "Professor"){
    super(name, email, birth, employed, role)
  }
  approveStudent(student, course){
    return `Estudante ${student} aprovado/a no curso ${course}.`
  }
}

// const newTeacher = new Teacher("Marcelo", "mar@gmail.com", '1985-01-04')
// console.log(newTeacher);
// console.log(newTeacher.showInfos());
// console.log(newTeacher.approveStudent('Carlos', "Javascript"));
