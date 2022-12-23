import "./InputText.css"

interface InputTextProps{
  placeholder: string,
  label: string,
  required?: boolean
}

export default function InputText({placeholder, label, required}: InputTextProps){ 

    return (
        <div className="inputText">          
            <label htmlFor={label}>
                {label}
            </label>
            <input required={required} placeholder={placeholder} id={label}/>
        </div>
    )
}
