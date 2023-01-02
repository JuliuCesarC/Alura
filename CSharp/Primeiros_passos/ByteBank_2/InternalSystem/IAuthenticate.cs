using ByteBank_2.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.InternalSystem
{
    // -------------------- INTERFACE --------------------
    // Dentro do C# não é possível que uma classe tenha heranças múltiplas, e como forma de contornar esse problema, podemos criar uma interface. Em uma interface só é declarado propriedades e comportamentos, os comandos que esses comportamentos terão fica de responsabilidade da subClasse.
    // Por convenção o nome de uma interface começa com a letra I maiúscula.
  public interface IAuthenticate
    // Uma interface pode herdar de outras interfaces, e as classes podem herder múltiplas interfaces. 
  {
    public string Password { get; set; }
    public bool Authenticate(string password);
    // Como citado acima, na interface não é possível implementar comandos, validações, etc. Ela é apenas um template que a subClasse terá de seguir.

  }
}
