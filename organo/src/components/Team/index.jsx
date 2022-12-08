import config from "../../../config.json"
import ContainerCards from "./components/ContainerCards";
import "./DevCards.css";

export default function Team() {
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

  function randomID() {
    return Math.random().toString(36).substring(2, 9);
  }
  return (
    <div className="card_exposition">
      {config.role.map((eRole) => {
        return (
          <ContainerCards 
            name={eRole.name}
            color={eRole.color}
            colorOpacity={eRole.colorOpacity}
            team={provisorio}
            key={randomID()}
          />
        );
      })}
    </div>
  );
}
