using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  internal class AccountAssistant: Employee
  {
    public AccountAssistant(string name, string cpf) : base(name, cpf, 2000)
    {
    }

    public override double GetBonus()
    {
      return this.Salary * 0.20;
    }

    public override void IncreaseSalary()
    {
      this.Salary *= 1.10;
    }
  }
}
