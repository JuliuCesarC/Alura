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

export default class User {
  #name
  #email
  #birth
  #employed
  #role
  constructor(name, email, birth, employed = true, role) {
    this.#name = name;
    this.#email = email;
    this.#birth = birth;
    this.#role = role || "Professor";
    this.#employed = employed;
  }
  // A declaração de um método privado é igual a da propriedade, utilizamos o '#' no inicio do nome.
  #createObject(){
    return ({
      name: this.#name,
      email: this.#email,
      birth: this.#birth
    })

  }
  showInfos() {
    const objUser = this.#createObject();
    return `${objUser.name}, ${objUser.email}`;
  }
}