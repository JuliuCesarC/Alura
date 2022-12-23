import "./InputText.css"

interface InputTextProps{
  placeholder: string,
  label: string,
  required?: boolean
}

export default function InputText({placeholder, label, required = false}: InputTextProps){
  // Como o 'required' foi tipado como opcional, então passamos um valor padrão para ele. 

    return (
        <div className="inputText">          
            <label htmlFor={label}>
                {label}
            </label>
            <input required={required} placeholder={placeholder} id={label}/>
        </div>
    )
}
