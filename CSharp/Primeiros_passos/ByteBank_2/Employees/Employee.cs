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
    public double getBonus()
    {
      return this.Salary * 0.10;
    }
  }
}
