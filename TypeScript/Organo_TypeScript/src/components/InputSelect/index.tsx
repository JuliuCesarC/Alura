import { randomID } from "../LocalStorage";
import "./InputSelect.css"

interface InputSelectProps {
  // O parâmero 'allRoles' esta esperando receber um conteúdo '.json', e uma das formas para tipar um arquivo json é utilizando o método abaixo. 
  allRoles: {
    name: string;
    color?: string;
    colorOpacity?: string;
  }[];
  // Informamos que o 'allRoles' é uma lista de objetos, e cada objeto possui os tres parâmetros informados, sendo 2 deles opcionais. Dessa forma fica bem explicito o que a função espera receber.
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
