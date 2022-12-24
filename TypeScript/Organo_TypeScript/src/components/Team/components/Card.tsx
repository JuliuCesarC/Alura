interface CardProps {
  color: string,
  name: string,
  url: string,
  role: string,
  date:string
}

export default function Card({ color, name, url, role, date }: CardProps) {
  return (
    <div className="card">
      <div className="card_top" style={{ backgroundColor: color }}></div>
      <div className="card_body">
        <img src={url} alt="Foto do colaborador" />
        <p className="card_name">{name}</p>
        <p className="card_role">{role}</p>
        <p className="card_date">{new Date(date).toLocaleDateString()}</p>
      </div>
    </div>
  );
}
