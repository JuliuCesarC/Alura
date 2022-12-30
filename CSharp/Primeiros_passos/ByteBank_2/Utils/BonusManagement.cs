using ByteBank_2.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Utils
{
  internal class BonusManagement
  {
    public double TotalBonus { get; set; }

// -------------------- SOBRECARGA DE MÉTODO --------------------
    // Sobrecarga de método é uma ferramenta que pode ser utilizada em um método que recebe  diferentes tipos de parâmetros e precisa chegar em um mesmo resultado. Declaramos vários métodos com o mesmo nome, dessa forma sera mostrado apenas um método para a função especifica. Isso evita a criação de diversos métodos que executam um mesmo código. 
    // O método trabalha diferente de acordo com o parâmetro recebido, este conceito é chamado de: POLIMORFISMO.
    public string Concatenacao(string palavra1, string palavra2)
    {
      return palavra1 + palavra2;
    }
    public string Concatenacao(string palavra1, string palavra2, string palavra3)
    {
      return palavra1 + palavra2 + palavra3;
      // Para chegar no mesmo resultado podemos modificar alguns comandos para se encaixar com o tipo do parâmetro recebido.
    }

    public void Register(Employee employee)
    {
      this.TotalBonus += employee.GetBonus();
    }
  }
}
