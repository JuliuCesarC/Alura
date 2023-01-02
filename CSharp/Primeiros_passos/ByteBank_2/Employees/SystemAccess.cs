using ByteBank_2.InternalSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  public abstract class SystemAccess: Employee, IAuthenticate
  {
    public SystemAccess(string name, string cpf, double salary) : base(name, cpf, salary)
    {
    }

    public string Password { get; set; }

    public bool Authenticate(string password)
    {
      return this.Password == password;
    }

  }
}
