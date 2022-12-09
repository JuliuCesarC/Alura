import config from "../../../config.json"
import { AddTeacher } from "../LocalStorage";
import "./Body.css";

export default function Form({team, setTeam}) {

  function addCollaborators(eColl){
    let Name = document.getElementById('Name').value
    let Role = document.getElementById('Role').value
    let Img = document.getElementById('Img').value
    let Team = document.getElementById('Team').value
    let newTeam = {
      name: Name,
      role: Role,
      team: Team,
      url: Img
    }
    AddTeacher(Name, Role, Img, Team)
    setTeam([...team, newTeam])
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
          addCollaborators(eForm.target)
        }}
      >
        <h2>Preencha os dados para criar o card do colaborador.</h2>
        <label htmlFor="Name">Nome</label>
        <input type="text" name="Name" id="Name" placeholder="Digite o nome" />
        <label htmlFor="Role">Cargo</label>
        <input type="text" name="Role" id="Role" placeholder="Digite o cargo" />
        <label htmlFor="Img">Imagem</label>
        <input
          type="text"
          name="Img"
          id="Img"
          placeholder="Informe o endereço da imagem."
        />
        <label htmlFor="Team">Time</label>
        <select name="Team" id="Team" placeholder="teste">
          {config.role.map((eRole)=><option value={eRole.name} key={randomID()}>{eRole.name}</option>)}
        </select>
        <button type="submit">Criar card</button>
      </form>      
    </main>
  );
}
