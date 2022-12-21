import style from "./Clock.module.scss";

interface Props {
  Time: number | undefined;
}

export default function Clock({ Time = 0 }: Props) {
  const minutes = Math.floor(Time / 60);
  const seconds = Time % 60;

  const [firstDigitMinutes, secondDigitMinutes] = String(minutes).padStart(
    2,
    "0"
  );
  const [firstDigitSeconds, secondDigitSeconds] = String(seconds).padStart(
    2,
    "0"
  );
  return (
    <>
      <span className={style.ClockNumber}>{firstDigitMinutes}</span>
      <span className={style.ClockNumber}>{secondDigitMinutes}</span>
      <span className={style.ClockSplit}>:</span>
      <span className={style.ClockNumber}>{firstDigitSeconds}</span>
      <span className={style.ClockNumber}>{secondDigitSeconds}</span>
    </>
  );
}
