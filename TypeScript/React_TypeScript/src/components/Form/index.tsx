import React from "react";
import Button from "../Button";
import "./style.scss"

class Form extends React.Component{
  render(){
    return(
      <form className="newTask">
        <div className="inputContainer">
          <label htmlFor="task">Cursos</label>
          <input 
          type="text"
          name="task"
          id="task"
          placeholder="Cursos para estudar?"
          required
          />
        </div>
        <div className="inputContainer">
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
        <Button />
      </form>
    )
  }
}

export default Form