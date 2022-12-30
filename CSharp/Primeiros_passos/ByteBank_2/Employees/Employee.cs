using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  internal class Employee
  {
    public string Name { get; set; }
    public string CPF { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string cpf)
    {
      this.Name = name;
      this.CPF = cpf;
    }
    public virtual double GetBonus()
    // O modificador 'virtual' indica que esse método pode ser sobrescrito pela classe(Manager) que herdara esta Classe(Employee).
    {
      return this.Salary * 0.10;
    }
  }
}
