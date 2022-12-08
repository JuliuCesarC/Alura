import "./App.css";
import Banner from "./components/Banner";
import Form from "./components/Form";
import Team from "./components/Team";
import Footer from "./components/Footer";
import { useEffect, useState } from "react";
import { LocalStorage } from "./components/Localstorage";

function App() {
  const [team, setTeam] = useState([]);

  useEffect(()=>{
    setTeam(LocalStorage())
  },[])
  return (
    <>
      <Banner />
      <Form />
      <Team team={team} setTeam={setTeam}/>
      <Footer />
    </>
  );
}

export default App;

