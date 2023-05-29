// -------------------- Default class --------------------
// export default class User {
//   constructor(name, email, birth, employed = true, role) {
//     this.name = name;
//     this.email = email;
//     this.birth = birth;
//     this.role = role || "Professor";
//     this.employed = employed;
//   }
//   showInfos() {
//     return `${this.name}, ${this.email}`;
//   }
// }
// console.log("O objeto é um prototype? ", User.prototype.isPrototypeOf(newUser));

// -------------------- Class with private fields --------------------
// export default class User {
// Para declarar uma propriedade como privada, utilizamos o '#' antes do nome do campo, e efetuamos a declaração no inicio da classe. Na sua utilização é necessario chamar pelo seu nome com o '#' também.
//   #name
//   #email
//   #birth
//   #employed
//   #role
//   constructor(name, email, birth, employed = true, role) {
//     this.#name = name;
//     this.#email = email;
//     this.#birth = birth;
//     this.#role = role || "Professor";
//     this.#employed = employed;
//   }
//   showInfos() {
//     return `${this.#name}, ${this.#email}`;
//   }
// }

// --------------- Class with private fields and methods ---------------

// export default class User {
//   #name;
//   #email;
//   #birth;
//   #employed;
//   #role;
//   constructor(name, email, birth, employed = true, role) {
//     this.#name = name;
//     this.#email = email;
//     this.#birth = birth;
//     this.#role = role || "Professor";
//     this.#employed = employed;
//   }
//   // A declaração de um método privado é igual a da propriedade, utilizamos o '#' no inicio do nome.
//   #createObject() {
//     return {
//       name: this.#name,
//       email: this.#email,
//       birth: this.#birth,
//     };
//   }
//   showInfos() {
//     const objUser = this.#createObject();
//     return `${objUser.name}, ${objUser.email}`;
//   }
// }

// --------------- Getter e Setters ---------------

export default class User {
  #name;
  #email;
  #birth;
  #employed;
  #role;
  constructor(name, email, birth, employed = true, role) {
    this.#name = name;
    this.#email = email;
    this.#birth = birth;
    this.#role = role || "Professor";
    this.#employed = employed;
  }
  // Um getter serve para termos acesso as propriedades da classe, de maneira direta ou com alguma logica implementada. Além disso, o get pode ser acessado como uma propriedade, sem a necessidade de utilizar os "()", por exemplo: | novoAdmin.nome; |.
  get name() {
    return this.#name;
  }
  get email(){
    return this.#email
  }
  get birth(){
    return this.#birth
  }
  get role(){
    return this.#role
  }
  get employed(){
    return this.#employed
  }
  // O setter serve para modificar diretamente ou com alguma logica aplicada, as propriedades da classe. Assim como o getter, o setter pode ser acessado da mesma fora, a diferença é que precisa ser atribuído um parâmetro com o igual, por exemplo: | usuarioA.nome = 'novoNome'; |.
  set name(newName) {
    if(newName.trim() === ''){
      throw new Error('Nome não pode ser vazio.')
    }
    this.#name = newName;
  }
  set email(newEmail){
    this.#email = newEmail;
  }
  set birth(newBirth){
    this.#birth = newBirth;
  }
  set role(newRole){
    this.#role = newRole;
  }
  set employed(newEmployed){
    this.#employed = newEmployed;
  }
  
  
  showInfos() {
    return `${this.name}, ${this.email}`;
  }
}
