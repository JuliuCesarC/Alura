import { IntTask } from "../../../types/Interface_taskList";
import style from "./Item.module.scss";

interface Props extends IntTask {
  selectedTask: (taskSelected: IntTask) => void;
}

export default function Item({
  task,
  time,
  selected,
  finish,
  id,
  selectedTask,
}: Props) {
  return (
    <li
      className={`${style.item} ${selected ? style.selectedItem : ""} ${
        finish ? style.finishItem : ""
      }`}
      onClick={() =>
        !finish &&
        selectedTask({
          task,
          time,
          selected,
          finish,
          id,
        })
      }
    >
      <h3>{task}</h3>
      <span>{time}</span>
      {finish && 
        <span className={style.completed} aria-label="Tarefa completada"></span>
      }
    </li>
  );
}
