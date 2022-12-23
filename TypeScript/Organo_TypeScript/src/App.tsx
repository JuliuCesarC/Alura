import "./App.css";
import Banner from "./components/Banner";
import Form from "./components/Form";
import Team from "./components/Team";
import Footer from "./components/Footer";
import { useEffect, useState } from "react";
import { LocalStorage } from "./components/LocalStorage";
import { ITeam } from "./components/interfaces/ITeam";

function App() {
  const [team, setTeam] = useState<ITeam[]>([]);

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
