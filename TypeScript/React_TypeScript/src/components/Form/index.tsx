import React, { useState } from "react";
import { IntTask } from "../../types/Interface_taskList";
import Button from "../Button";
import style from "./Form.module.scss";

interface Props{
  setTaskList: React.Dispatch<React.SetStateAction<IntTask[]>>;
}

export default function Form({setTaskList}: Props){
  const [task, setTask] = useState<string>("")
  const [time, setTime] = useState<string>("00:00")

  function addTask(eAdd: React.FormEvent<HTMLFormElement>) {
    eAdd.preventDefault();
    setTaskList((prevTask) => [
      ...prevTask,
      { task, time, selected: false, finish: false, id: randomID() },
    ]
      );
    setTask("")
    setTime("00:00")
  };

  function randomID() {
    return Math.random().toString(36).substring(2, 12);
  }
    return (
      <form className={style.newTask} onSubmit={addTask}>
        <div className={style.inputContainer}>
          <label htmlFor={style.task}>Cursos</label>
          <input
            type="text"
            name="task"
            value={task}
            onChange={(e) =>
              setTask(e.target.value)
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
            value={time}
            onChange={(e) =>
              setTime(e.target.value)
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

