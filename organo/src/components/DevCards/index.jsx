import "./DevCards.css";

export default function DevCards() {
  const provisorio = [
    {
      name: "Juliu Cesar",
      role: "Desenvolvedor front end",
      url: "https://github.com/JuliuCesarC.png",
    },
    {
      name: "Jão da Silva",
      role: "Desenvolvedor back end",
      url: "https://github.com/JuliuCesarC.png",
    },
    {
      name: "Mariliana Minatto",
      role: "Professora de Angular",
      url: "https://github.com/JuliuCesarC.png",
    },
    {
      name: "Clebler Santoro",
      role: "Programador",
      url: "https://github.com/JuliuCesarC.png",
    },
    {
      name: "Diovani Corleone",
      role: "Familia",
      url: "https://github.com/JuliuCesarC.png",
    },
    {
      name: "Diovani Corleone",
      role: "Familia",
      url: "https://github.com/JuliuCesarC.png",
    },
  ];
  const timeProvisorio = ["Front End", "DataScience"];

  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
  return (
    <div className="card_exposition">
      {timeProvisorio.map((eTime) => {
        return (
          <div className="container_cards">
              <h2>{eTime}</h2>
            <div className="card_role">
              {provisorio.map((eCard) => {
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
      })}
    </div>
  );
}
