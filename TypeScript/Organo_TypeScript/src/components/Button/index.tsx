import React from "react"
import { ReactElement } from "react"
import "./Button.css"

interface ButtonProps{
children: ReactElement | string,
type: "button" | "submit" | "reset" | undefined
}

export default function Button({children, type}: ButtonProps){

  return(
    <button className="Button" type={type}>
      {children}
    </button>
  )
}