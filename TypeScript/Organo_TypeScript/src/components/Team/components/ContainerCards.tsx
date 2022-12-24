import { ITeam } from "../../interfaces/ITeam";
import { randomID } from "../../LocalStorage";
import Card from "./Card";

interface ContainerCardsProps {
  name: string;
  color: string;
  colorOpacity: string;
  team: ITeam[];
}

export default function ContainerCards({
  name,
  color,
  colorOpacity,
  team,
}: ContainerCardsProps) {
  return (
    <div className="Role" style={{ backgroundColor: colorOpacity }}>
      <h2
        style={{
          borderBottomWidth: "4px",
          borderBottomStyle: "solid",
          borderBottomColor: color,
        }}
      >
        {name}
      </h2>
      <div className="container_cards">
        {team.map(({ name, role, url, date }) => {
          return (
            <Card
              key={randomID()}
              color={color}
              name={name}
              role={role}
              url={url}
              date={date}
            />
          );
        })}
      </div>
    </div>
  );
}
