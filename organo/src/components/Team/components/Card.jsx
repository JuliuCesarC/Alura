export default function Card({ color, name, url, role }) {

  return (
    <div className="card">
      <div className="card_top" style={{ backgroundColor: color }}></div>
      <div className="card_body">
        <img src={url} alt="Foto do colaborador" />
        <p className="card_name">{name}</p>
        <p className="card_role">{role}</p>
      </div>
    </div>
  );
}