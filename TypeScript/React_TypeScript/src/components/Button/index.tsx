import React from "react";
import style from "./Button.module.scss";

interface Props {
  children: React.ReactNode;
  type?: "button" | "submit" | "reset" | undefined;
  onClick?: () => void;
}
export default function Button({ children, type, onClick }: Props) {
  return (
    <button type={type} className={style.Button} onClick={onClick}>
      {children}
    </button>
  );
}
