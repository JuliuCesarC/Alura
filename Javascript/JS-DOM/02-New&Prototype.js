// ----- TRABALHANDO COM OBJETOS ANTES DAS CLASSES -----

function User(name, email){
  this.name = name
  this.email = email
  this.showInfos = function(){
    return `${this.name}, ${this.email}`
  }
}
// const newUser = new User("Jão", "jj@gmail.com")
// console.log(newUser.showInfos());

function Admin(role){
  // O 'call' chama a função construtora de User, porem ele não faz com que o objeto Admin herde as propriedades e métodos de User. Nesse caso ele apenas executa a função construtora de User no contexto de Admin. Para que ele herde de User precisamos estabelecer uma herança de protótipo com o 'prototype' que veremos abaixo.
  User.call(this, "Jenfiner", "jeje@gmail.com")
  // Um dos parâmetros que o 'call' recebe é para qual instancia ele ira se referir, que no caso passamos 'this', ou seja, ele ira se referir ao objeto em que o 'call' foi chamado, nesse caso o 'User'.
  this.role = role || "Professor"
}
// Abaixo estamos criando uma herança de protótipo, o que ira garantir que Admin herde todos os métodos e propriedades de User.
Admin.prototype = Object.create(User.prototype)
const newUser = new Admin('admin')
// console.log(newUser.showInfos());
// console.log(newUser.role);

// ------------------------- \/ -------------------------

const otherUser = {
  // Como este objeto não recebe parâmetros, para criarmos um construtor precisamos utilizar o 'init' que pode ser chamado posteriormente e informado os parâmetros, criando algo semelhante a um construtor.
  init: function(name, email){
    this.name = name
    this.email = email
  },
  showOtherInfos: function() {
    return this.name
  }
}

const newOtherUser = Object.create(otherUser)
newOtherUser.init("Marsco", "marsquinho@gmail.com")
console.log(newOtherUser.showOtherInfos());