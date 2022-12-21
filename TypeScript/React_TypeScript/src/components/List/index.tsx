import Item from "./Item"
import style from "./List.module.scss"

function List(){
  let taskList = [
    {task: 'React', time:'02:00:00'},
    {task: 'Javascript', time:'01:30:00'},
    {task: 'TypeScript', time:'01:00:00'},
  ]
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