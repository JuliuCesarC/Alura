import "./Body.css";

export default function Body() {
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
        <label for="Name">Nome</label>
        <input type="text" name="Name" id="Name" placeholder="Digite o nome" />
        <label for="Role">Cargo</label>
        <input type="text" name="Role" id="Role" placeholder="Digite o cargo" />
        <label for="Img">Imagem</label>
        <input
          type="text"
          name="Img"
          id="Img"
          placeholder="Informe o endereço da imagem."
        />
        <label for="Team">Time</label>
        <select name="Team" id="Team" placeholder="teste">
          <option value="time1">FrontEnd</option>
          <option value="time1">BackEnd</option>
          <option value="time1">DataScience</option>
        </select>
        <button type="submit">Criar card</button>
      </form>
      <h1>Minha Organização:</h1>
    </main>
  );
}
