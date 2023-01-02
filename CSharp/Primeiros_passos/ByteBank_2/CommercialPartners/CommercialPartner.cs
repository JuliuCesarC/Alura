using ByteBank_2.InternalSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.CommercialPartners
{
  public class CommercialPartner: IAuthenticate
  {
    public string Password { get; set; }
    public bool Authenticate(string password)
    {
      return this.Password == password;
    }
  }
}
