import { randomID } from "../../LocalStorage";
import Card from "./Card";

export default function ContainerCards({name, color, colorOpacity, team}) {

  return (
    <div
      className="Role"
      style={{ backgroundColor: colorOpacity }}
    >
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
        {team.map(({Name, Role, Url}) => {
          return (
            <Card
              key={randomID()}
              color={color}
              Name={Name}
              Role={Role}
              Url={Url}
            />
          );
        })}
      </div>
    </div>
  );
}
