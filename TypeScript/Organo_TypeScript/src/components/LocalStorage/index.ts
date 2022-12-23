import { ITeam } from "../interfaces/ITeam";

const TEAM = "Team";
function GetLS() {
  return localStorage.getItem(TEAM);
}
function SetLS(ls: ITeam[]): void{
 localStorage.setItem(TEAM ,JSON.stringify(ls))
}
// Como estamos setando ou buscando um objeto no formato da interface ITeam do localStorage, então basta tipar os arquivos que possuem esse formato com o tipo ITeam. No caso de quando estamos criando um novo colaborador, então é só ITeam, mas quando é a lista de colaboradores, então fica 'ITeam[]'. 

export function LocalStorage() {
  const collaborators: ITeam[] = [];
  if (GetLS()) {
    let GLS = GetLS()
    if(GLS){
      let LS: ITeam[] = JSON.parse(GLS);
      return LS;
    }
  }
  return collaborators;
}
export function AddCollaborator({name, role, url, team}: ITeam): void {
  if (!GetLS()) {
    let newLS: ITeam = {
      name,
      role,
      url,
      team
    };
    SetLS([newLS])
  }else{
    let GLS = GetLS()
    if(GLS){
      let addLS: ITeam[] = JSON.parse(GLS)
      let newLS: ITeam = {
        name,
        role,
        url,
        team
      };
      addLS.push(newLS)
      SetLS(addLS)
    }
  }
}

export function DeleteCollaborator(name: string): void{
  let GLS = GetLS()
  if(GLS){
    let newLS: ITeam[] = JSON.parse(GLS)
    SetLS(newLS.filter(e => e.name != name))
  }
}

export function randomID(): string {
  return Math.random().toString(36).substring(2, 12);
}