import config from "../../../config.json";
import InputText from "../InputText";
import { AddCollaborator } from "../LocalStorage";
import Button from "../Button";
import "./Body.css";
import { ITeam } from "../interfaces/ITeam";
import InputSelect from "../InputSelect";

interface FormProps {
  // Para definir o tipo do parâmetro que estamos recebendo na função 'Form' como um 'setState', utilizamos o tipo abaixo.
  setTeam: React.Dispatch<React.SetStateAction<ITeam[]>>;
  // Obs: Para descobrir esse tipo com o VsCode utilizando TypeScript, basta passar o mouse em cima do setState onde ele foi declarado, que ira mostrar o tipo. Para garantir o funcionamento correto, o useState precisa já estar "tipado".
}

export default function Form({ setTeam }: FormProps) {
  const InputName = "Name";
  const InputRole = "Role";
  const InputUrl = "img_url";
  const InputTeam = "Team";
  const InputDate = "Date";

  function addCollaboratorAndClearForm() {
    let newCollaborator: ITeam = {
      name: getByIdAndClearInput(InputName),
      role: getByIdAndClearInput(InputRole),
      url: getByIdAndClearInput(InputUrl),
      team: getByIdAndClearInput(InputTeam),
      date: getByIdAndClearInput(InputDate),
    };
    AddCollaborator(newCollaborator);
    setTeam((prevTeam) => [...prevTeam, newCollaborator]);
  }

  function getByIdAndClearInput(id: string): string {
    let elem = document.getElementById(id) as HTMLInputElement;
    // O 'getElementById' retorna um 'HTMLElement' ou null, porem o método '.value' só esta incluso no 'HTMLInputElement', por isso executamos o 'getElementById' como um 'InputElement'. Ao utilizar o 'as HTMLInputElement' garantimos para o TypeScript que nunca retornara null, então caso seja informado o id errado para a função, apenas em runtime quando essa função for executada que notaremos o erro.
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
        <InputText
          placeholder="Digite o nome"
          label="Nome"
          id={InputName}
          required={true}
        />
        <InputText
          placeholder="Digite o cargo"
          label="Cargo"
          id={InputRole}
          required={true}
        />
        <InputText
          placeholder="Informe o endereço da imagem."
          label="Imagem"
          id={InputUrl}
          required={true}
        />
        <InputText
          placeholder=""
          label="Data de entrada do colaborador"
          id={InputDate}
          required={true}
          type="date"
        />
        <InputSelect allRoles={config.role} id={InputTeam} />
        <Button type="submit">Criar card</Button>
      </form>
    </main>
  );
}
