import style from "./Clock.module.scss"

export default function Clock() {
  return (
    <>
      <span className={style.ClockNumber}>0</span>
      <span className={style.ClockNumber}>0</span>
      <span className={style.ClockSplit}>:</span>
      <span className={style.ClockNumber}>0</span>
      <span className={style.ClockNumber}>0</span>
    </>
  );
}
