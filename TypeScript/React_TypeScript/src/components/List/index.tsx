import { IntTask } from "../../types/Interface_taskList"
import Item from "./Item"
import style from "./List.module.scss"

function List({taskList}: {taskList: IntTask[]}){
  return(
    <aside className={style.taskList}>
      <h2>Estudos do dia</h2>
      <ul>
        {taskList.map(task=>(
          <Item
          key={Math.random()}
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