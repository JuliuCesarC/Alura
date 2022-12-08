const TEAM = "Team";
function GetLS() {
  return localStorage.getItem(TEAM);
}
function SetLS(ls){
 localStorage.setItem(TEAM ,JSON.stringify(ls))
}
export function LocalStorage() {
  const collaborators = [];
  if (!GetLS()) {
    return collaborators;
  } else {
    let LS = JSON.parse(GetLS());
    for (let i = 0; i < LS.length; i++) {
      collaborators[i] = LS[i];
    }
    return LS;
  }
}
export function AddTeacher(name, role, url, team) {
  if (!GetLS()) {
    let newLS = {
      name,
      role,
      url,
      team
    };
    SetLS([newLS])
  }else{
    let addLS = JSON.parse(GetLS())
    let newLS = {
      name,
      role,
      url,
      team
    };
    addLS.push(newLS)
    SetLS(addLS)
  }
}
