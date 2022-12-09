import config from "../../../config.json"
import { AddTeacher } from "../LocalStorage";
import "./Body.css";

export default function Form({team, setTeam}) {

  function addCollaborators(eColl){
    let Name = document.getElementById('Name')
    let Role = document.getElementById('Role')
    let Img = document.getElementById('Img')
    let Team = document.getElementById('Team')
    let newTeam = {
      name: Name.value,
      role: Role.value,
      team: Team.value,
      url: Img.value
    }
    AddTeacher(Name.value, Role.value, Img.value, Team.value)
    setTeam([...team, newTeam])
    Name.value = ''
    Role.value = ''
    Img.value = ''
    Team.value = ''
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
