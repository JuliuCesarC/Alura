export default function Card({ color, Name, Url, Role }) {

  return (
    <div className="card">
      <div className="card_top" style={{ backgroundColor: color }}></div>
      <div className="card_body">
        <img src={Url} alt="Foto do colaborador" />
        <p className="card_name">{Name}</p>
        <p className="card_role">{Role}</p>
      </div>
    </div>
  );
}
