export default function ContainerCards({role, team}) {

  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
  return (
    <div className="container_cards" key={randomID()}>
      <h2>{role}</h2>
      <div className="card_role">
        {team.map((eCard) => {
          return (
            <div className="card" key={randomID()}>
              <div className="card_top"></div>
              <div className="card_body">
                <img src={eCard.url} alt="Foto do colaborador" />
                <p className="card_name">{eCard.name}</p>
                <p className="Role">{eCard.role}</p>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
}
