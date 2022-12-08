import config from "../../../config.json"
import "./Body.css";

export default function Form() {

  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
  return (
    <main className="container">
      <form
        action=""
        className="Form"
        onSubmit={(e) => {
          e.preventDefault();
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
      <h1>Minha Organização:</h1>
    </main>
  );
}
