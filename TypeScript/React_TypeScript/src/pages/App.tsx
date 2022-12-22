import { useState } from 'react'
import Form from '../components/Form'
import List from '../components/List'
import Timer from '../components/Timer'
import { IntTask } from '../types/Interface_taskList'
import style from "./App.module.scss"

function App() {
  const [taskList, setTaskList] = useState<IntTask[] | []>([])
  const [Select, setSelect] = useState<IntTask>()

  function selectedTask(taskSelected: IntTask){
    setSelect(taskSelected)
    setTaskList(prevTask => prevTask.map(task=>({
      ...task,
      selected: task.id === taskSelected.id ? true : false
    })))
  }

  function finishTask(){
    if(Select){
      setSelect(undefined)
      setTaskList(prevTasks => prevTasks.map(task =>{
        if(task.id === Select.id){
          return{
            ...task,
            selected:false,
            finish: true
          }
        }
        return task;
      }))
    }
  }
  
  return (
    <div className={style.AppStyle}>
      <Form setTaskList={setTaskList}/>
      <List taskList={taskList} selectedTask={selectedTask} />
      <Timer Select={Select} finishTask={finishTask} />
    </div>
  )
}

export default App
