using ByteBank_2.InternalSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  public class AccountManager: SystemAccess
  {
    public AccountManager(string name, string cpf) : base(name, cpf, 4000)
    {
    }
    public override double GetBonus()
    {
      return this.Salary * 0.25;
    }

    public override void IncreaseSalary()
    {
      this.Salary *= 1.05;
    }
  }
}
