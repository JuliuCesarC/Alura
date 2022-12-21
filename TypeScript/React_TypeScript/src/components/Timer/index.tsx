import { useEffect, useState } from "react";
import { timeToSeconds } from "../../common/utils/time";
import { IntTask } from "../../types/Interface_taskList";
import Button from "../Button";
import Clock from "./Clock";
import style from "./Timer.module.scss"

interface Props {
  Select: IntTask | undefined
}

export default function Timer({Select}: Props){
  const [Time, setTime] = useState<number>()
useEffect(()=>{
  if(Select?.time){
    setTime(timeToSeconds(Select?.time))
  }
},[Select])

  return(
    <div className={style.Timer}>
      <p className={style.title}>Escolha um card e inicie o cronometro</p>
      <div className={style.clockWrapper}><Clock/></div>
      <Button>
        Começar!
      </Button>
    </div>
  )
}