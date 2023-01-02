using ByteBank_2.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.InternalSystem
{
  public class InternalSystem
  {
    public bool Login(Director employee, string password)
    {
      bool authentication = employee.Authenticate(password);
      if( authentication )
      {
        Console.WriteLine("Logado no sistema.");
        return true;
      }
      else
      {
        Console.WriteLine("Dados incorretos.");
        return false;
      }
    }
    public bool Login(AccountManager employee, string password)
    {
      bool authentication = employee.Authenticate(password);
      if( authentication )
      {
        Console.WriteLine("Logado no sistema.");
        return true;
      }
      else
      {
        Console.WriteLine("Dados incorretos.");
        return false;
      }
    }
  }
}
