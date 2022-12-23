import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import './index.css'

// O getElementById pode retornar nulo caso não encontre o elemento, e para evitar esse erro, podemos utilizar o ponto de exclamação no final do comando "!", isso indica para o TypeScript que o programador garante que ira retornar um elemento. Isso não corrige o problema, apenas impede ele de mostrar esse erro.
ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
)
