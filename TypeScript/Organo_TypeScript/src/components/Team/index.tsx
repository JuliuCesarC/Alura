import config from "../../../config.json";
import ContainerCards from "./components/ContainerCards";
import { randomID } from "../LocalStorage";
import { ITeam } from "../interfaces/ITeam";
import "./Team.css";

interface TeamProps {
  team: ITeam[];
}

export default function Team({ team }: TeamProps) {
  const havePeopleOnTheTeam = team.length > 0;
  const allRoles = config.role;

  function havePeopleOnTheRole(roleName: string): boolean {
    return team.filter((e) => e.team === roleName).length > 0;
  }

  function allPeopleWithTheSameRole(roleName: string): ITeam[] {
    return team.filter((e) => e.team === roleName);
  }

  return (
    <div className="card_exposition">
      <h1>Minha Organização:</h1>
      {havePeopleOnTheTeam &&
        allRoles.map(({ color, colorOpacity, name,  }) => {
          if (havePeopleOnTheRole(name)) {
            return (
              <ContainerCards
                key={randomID()}
                name={name}
                color={color}
                colorOpacity={colorOpacity}
                team={allPeopleWithTheSameRole(name)}
              />
            );
          }
          return "";
        })}
    </div>
  );
}
