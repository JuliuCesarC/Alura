import { useEffect, useState } from "react";
import { timeToSeconds } from "../../common/utils/time";
import { IntTask } from "../../types/Interface_taskList";
import Button from "../Button";
import Clock from "./Clock";
import style from "./Timer.module.scss";

interface Props {
  Select: IntTask | undefined;
}

export default function Timer({ Select }: Props) {
  const [Time, setTime] = useState<number>();

  useEffect(() => {
    if (Select?.time) {
      setTime(timeToSeconds(Select?.time));
    }
  }, [Select]);

  function stopwatch(time: number = 0){
    setTimeout(() => {
      if(time > 0){
        setTime(time - 1)
        return stopwatch(time-1)
      }
    }, 1000);
  }
  return (
    <div className={style.Timer}>
      <p className={style.title}>Escolha um card e inicie o cronometro</p>
      <div className={style.clockWrapper}>
        <Clock Time={Time} />
      </div>
      <Button onClick={() => stopwatch(Time)}>Começar!</Button>
    </div>
  );
}
