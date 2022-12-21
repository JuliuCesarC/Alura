import React from "react";
import { IntTask } from "../../types/Interface_taskList";
import Button from "../Button";
import style from "./Form.module.scss";

class Form extends React.Component<{
  setTaskList: React.Dispatch<React.SetStateAction<IntTask[]>>;
}> {
  state = {
    task: "",
    time: "00:00",
  };

  addTask(eAdd: React.FormEvent<HTMLFormElement>) {
    eAdd.preventDefault();
    this.props.setTaskList((prevTask) => [
      ...prevTask,
      { ...this.state, selected: false, finish: false, id: this.randomID() },
    ]);
    this.setState({
      task: "",
      time: "00:00",
    });
  }

  randomID() {
    return Math.random().toString(36).substring(2, 12);
  }
  render() {
    return (
      <form className={style.newTask} onSubmit={this.addTask.bind(this)}>
        <div className={style.inputContainer}>
          <label htmlFor={style.task}>Cursos</label>
          <input
            type="text"
            name="task"
            value={this.state.task}
            onChange={(e) =>
              this.setState({ ...this.state, task: e.target.value })
            }
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
            value={this.state.time}
            onChange={(e) =>
              this.setState({ ...this.state, time: e.target.value })
            }
            id="Time"
            step="1"
            min="00:00:00"
            max="01:30:00"
            required
          />
        </div>
        <Button type="submit">Adicionar</Button>
      </form>
    );
  }
}

export default Form;
