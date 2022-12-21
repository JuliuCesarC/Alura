import { IntTask } from "../../types/Interface_taskList"
import Item from "./Item"
import style from "./List.module.scss"

interface Props{
  taskList: IntTask[],
  selectedTask: (taskSelected: IntTask) => void
}

function List({taskList, selectedTask}: Props){
  return(
    <aside className={style.taskList}>
      <h2>Estudos do dia</h2>
      <ul>
        {taskList.map(task=>(
          <Item
          selectedTask={selectedTask}
          key={task.id}
          // task={task.task} 
          // time={task.time} 
          // OU
          {...task}

          />
        ))}
      </ul>
    </aside>
  )
}
export default List