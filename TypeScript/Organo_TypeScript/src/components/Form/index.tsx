import config from "../../../config.json";
import InputText from "../InputText";
import { AddCollaborator } from "../LocalStorage";
import Button from "../Button";
import "./Body.css";
import { ITeam } from "../interfaces/ITeam";
import InputSelect from "../InputSelect";

interface FormProps {
  setTeam: React.Dispatch<React.SetStateAction<ITeam[]>>
}

export default function Form({ setTeam }: FormProps) {

  function addCollaboratorAndClearForm() {
    let newCollaborator: ITeam = {
      name: getByIdAndClearInput("Nome"),
      role: getByIdAndClearInput("Cargo"),
      url: getByIdAndClearInput("Imagem"),
      team: getByIdAndClearInput("Team"),
    };
    AddCollaborator(newCollaborator);
    setTeam(prevTeam => [...prevTeam, newCollaborator]);
  }

  function getByIdAndClearInput(id: string): string {
    let elem = document.getElementById(id) as HTMLInputElement;
      let tx = elem.value;
      elem.value = "";
    return tx;
  }

  return (
    <main className="container">
      <form
        action=""
        className="Form"
        onSubmit={(eForm) => {
          eForm.preventDefault();
          addCollaboratorAndClearForm();
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
        <InputSelect allRoles={config.role} />
        <Button type="submit">Criar card</Button>
      </form>
    </main>
  );
}
