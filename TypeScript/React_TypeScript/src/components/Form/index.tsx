import React from "react";
import Button from "../Button";
import style from "./Form.module.scss"

class Form extends React.Component{
  render(){
    return(
      <form className={style.newTask}>
        <div className={style.inputContainer}>
          <label htmlFor={style.task}>Cursos</label>
          <input 
          type="text"
          name="task"
          id="task"
          placeholder="Cursos para estudar?"
          required
          />
        </div>
        <div className={style.inputContainer}>
          <label htmlFor="Time">Tempo de estudo</label>
          <input 
          type="time"
          name="Time"
          id="Time"
          step="1"
          min="00:00:00"
          max="01:30:00"
          required
          />
        </div>
        <Button>
          Adicionar
        </Button>
      </form>
    )
  }
}

export default Form