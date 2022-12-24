import "./InputText.css"

interface InputTextProps{
  placeholder: string,
  label: string,
  id: string,
  required?: boolean,
  type?: "text" | "date" | "number" | "password" | "email" | "tel"
}

export default function InputText({placeholder, label, id, required = false, type = "text"}: InputTextProps){
  // Como o 'required' foi tipado como opcional, então passamos um valor padrão para ele. 

    return (
        <div className="inputText">          
            <label htmlFor={label}>
                {label}
            </label>
            <input type={type} required={required} placeholder={placeholder} id={id}/>
        </div>
    )
}
