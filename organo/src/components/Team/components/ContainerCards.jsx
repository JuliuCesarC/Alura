import Card from "./Card";

export default function ContainerCards({name, color, colorOpacity,team, setTeam}) {
  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
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
        {team.map((eCard) => {
          return (
            <Card
              color={color}
              name={eCard.name}
              role={eCard.role}
              url={eCard.url}
              key={randomID()}
            />
          );
        })}
      </div>
    </div>
  );
}
