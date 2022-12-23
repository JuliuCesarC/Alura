import Banner from "./components/Banner";
import Form from "./components/Form";
import Team from "./components/Team";
import Footer from "./components/Footer";
import { useEffect, useState } from "react";
import { LocalStorage } from "./components/LocalStorage";
import { ITeam } from "./components/interfaces/ITeam";

function App() {
  // Precisamos informar qual tipo que o useState ira trabalhar, mas como ele é genérico e pode receber diversos tipos de conteúdo, precisamos utilizar um tipo 'generic', e aplicamos isso utilizando o sinal de maior que e menor que "<tipo>". 
  const [team, setTeam] = useState<ITeam[]>([]);
  // No nosso caso indicamos que esse State ira trabalhar com uma lista de 'ITeam'.

  useEffect(() => {
    setTeam(LocalStorage());
  }, []);
  return (
    <>
      <Banner imageUrl="img/banner.png" altText="Banner pagina principal" />
      <Form setTeam={setTeam} />
      <Team team={team} />
      <Footer />
    </>
  );
}

export default App;
