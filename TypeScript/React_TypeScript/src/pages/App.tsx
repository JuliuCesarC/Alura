import { useState } from 'react'
import Form from '../components/Form'
import List from '../components/List'
import Timer from '../components/Timer'
import style from "./App.module.scss"

function App() {
  const [taskList, setTaskList] = useState([
    {task: 'React', time:'02:00:00'},
    {task: 'Javascript', time:'01:30:00'},
    {task: 'TypeScript', time:'01:00:00'},
  ])
  return (
    <div className={style.AppStyle}>
      <Form setTaskList={setTaskList}/>
      <List taskList={taskList}/>
      <Timer />
    </div>
  )
}

export default App
