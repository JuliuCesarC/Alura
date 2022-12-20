import "./style.scss"

function List(){
  let taskList = [
    {task: 'React', time:'02:00:00'},
    {task: 'Javascript', time:'01:30:00'}
  ]
  return(
    <aside className="taskList">
      <h2>Estudos do dia</h2>
      <ul>
        {taskList.map(task=>{
          return(
        <li className="item" key={Math.random()}>
          <h3>{task.task}</h3>
          <span>{task.time}</span>
        </li>
          )
        })}
      </ul>
    </aside>
  )
}
export default List