import "./App.css";
import Banner from "./components/Banner";
import Form from "./components/Form";
import Team from "./components/Team";
import Footer from "./components/Footer";
import { useEffect, useState } from "react";
import { LocalStorage } from "./components/LocalStorage";

function App() {
  const [team, setTeam] = useState([]);

  useEffect(()=>{
    setTeam(LocalStorage())
  },[])
  return (
    <>
      <Banner />
      <Form team={team} setTeam={setTeam}/>
      <Team team={team} />
      <Footer />
    </>
  );
}

export default App;

