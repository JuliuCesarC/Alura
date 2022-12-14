import { Printable } from "./Printable.js";

export function Print(...args: Printable[]){
  for(let objeto of  args){
    console.log(objeto.convertToText());
  }
}