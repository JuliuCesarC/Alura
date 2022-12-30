using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Titular
{
  public class Cliente
  {
    // -------------------- PROPRIEDADES AUTO IMPLEMENTADAS --------------------
    // Quando declaramos apenas a propriedade para um campo privado, porem não declaramos esse campo privado, o programa em tempo de execução ira automaticamente criar um campo privado e atribuirá o 'get' e o 'set' nesse campo. Geralmente utilizado para propriedades que não terão nenhum tipo de validação. 
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Profissao { get; set; }

  }
}
