using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  internal class Designer: Employee
  {
    public Designer(string name, string cpf) : base(name, cpf, 3000)
    {
    }

    public override double GetBonus()
    {
      return this.Salary * 0.17;
    }

    public override void IncreaseSalary()
    {
      this.Salary *= 1.11;
    }
  }
}
