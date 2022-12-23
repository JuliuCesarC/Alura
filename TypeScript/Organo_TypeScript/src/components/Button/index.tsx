import React from "react"
import { ReactElement } from "react"
import "./Button.css"

interface ButtonProps{
children: ReactElement | string,
// Como podemos receber um elemento React ou um texto como filho do componente Button, tipamos children com esses 2 tipos.
type: "button" | "submit" | "reset" | undefined
// Assim como vimos no componente Form, para saber o tipo do setState, podemos fazer o mesmo para o parâmetro type, no vscode ao passar o mouse em cima do 'type' de uma tag button, ele ira mostrar os tipos que ele aceita, que no caso são os 4 tipos acima. 
}

export default function Button({children, type}: ButtonProps){

  return(
    <button className="Button" type={type}>
      {children}
    </button>
  )
}