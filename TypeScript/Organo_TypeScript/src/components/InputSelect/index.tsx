import { randomID } from "../LocalStorage";
import "./InputSelect.css"

interface InputSelectProps {
  allRoles: {
    name: string;
    color?: string;
    colorOpacity?: string;
  }[];
}

export default function InputSelect({ allRoles }: InputSelectProps) {
  return (
    <div className="inputSelect">
      <label htmlFor="Team">Time</label>
      <select name="Team" id="Team">
        {allRoles.map((eRole) => (
          <option value={eRole.name} key={randomID()}>
            {eRole.name}
          </option>
        ))}
      </select>
    </div>
  );
}
