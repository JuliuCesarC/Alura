import config from "../../../config.json";
import ContainerCards from "./components/ContainerCards";
import "./Team.css";

export default function Team({ team }) {
  const havePeopleOnTheTeam = team.length > 0;
  const allRoles = config.role;

  function havePeopleOnTheRole(roleName) {
    return team.filter((e) => e.team === roleName).length > 0;
  }

  function allPeopleWithTheSameRole(roleName) {
    return team.filter((e) => e.team === roleName);
  }

  function randomID() {
    return Math.random().toString(36).substring(2, 12);
  }
  return (
    <div className="card_exposition">
      <h1>Minha Organização:</h1>
      {havePeopleOnTheTeam &&
        allRoles.map(({color, colorOpacity, name}) => {
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