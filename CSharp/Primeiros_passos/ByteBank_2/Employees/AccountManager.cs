using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  public class AccountManager: Employee
  {
    private string Password { get; set; }
    public AccountManager(string name, string cpf, string password) : base(name, cpf, 4000)
    {
      Password = password;
    }
    public bool Authenticate(string password)
    {
      return this.Password == password;
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
