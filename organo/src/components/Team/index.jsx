import config from "../../../config.json"
import { DeleteColl } from "../LocalStorage";
import ContainerCards from "./components/ContainerCards";
import "./Team.css";

export default function Team({team}) {

  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
  return (
    <div className="card_exposition">
      <h1>Minha Organização:</h1>
      {team.length > 0 && config.role.map((eRole) => {
        let roleTeam = team.filter(e=>e.team === eRole.name);
        if(team.filter(e=>e.team === eRole.name).length > 0){
          return (
            <ContainerCards 
              name={eRole.name}
              color={eRole.color}
              colorOpacity={eRole.colorOpacity}
              team={roleTeam}
              key={randomID()}
            />
          );          
        }
        return "";
      })}
    </div>
  );
}
