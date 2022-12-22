import config from "../../../config.json";
import InputText from "../InputText";
import { AddTeacher } from "../LocalStorage";
import Button from "../Button";
import "./Body.css";

export default function Form({ team, setTeam }) {
  function addCollaborators(eColl) {
    let Name = document.getElementById("Name");
    let Role = document.getElementById("Role");
    let Img = document.getElementById("Img");
    let Team = document.getElementById("Team");
    let newTeam = {
      name: Name.value,
      role: Role.value,
      team: Team.value,
      url: Img.value,
    };
    AddTeacher(Name.value, Role.value, Img.value, Team.value);
    setTeam([...team, newTeam]);
    Name.value = "";
    Role.value = "";
    Img.value = "";
    Team.value = "";
  }

  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
  return (
    <main className="container">
      <form
        action=""
        className="Form"
        onSubmit={(eForm) => {
          eForm.preventDefault();
          addCollaborators(eForm.target);
        }}
      >
        <h2>Preencha os dados para criar o card do colaborador.</h2>
        <InputText placeholder="Digite o nome" label="Nome" required={true} />
        <InputText placeholder="Digite o cargo" label="Cargo" required={true} />
        <InputText
          placeholder="Informe o endereço da imagem."
          label="Imagem"
          required={true}
        />
        <label htmlFor="Team">Time</label>
        <select name="Team" id="Team" placeholder="teste">
          {config.role.map((eRole) => (
            <option value={eRole.name} key={randomID()}>
              {eRole.name}
            </option>
          ))}
        </select>
        <Button type="submit">Criar card</Button>
      </form>
    </main>
  );
}
