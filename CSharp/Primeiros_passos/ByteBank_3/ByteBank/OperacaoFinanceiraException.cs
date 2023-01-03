using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  // -------------------- EXCEÇÃO PERSONALIZADA --------------------
  // Algumas vezes as exceções padrões do C# não conseguem descrever o erro no nosso programa, para isso podemos criar uma exceção personalizada.
  internal class OperacaoFinanceiraException: Exception
  // Primeiro precisamos informar que a classe herda de uma 'Exception'.
  {
    public OperacaoFinanceiraException()
    {
    }
    public OperacaoFinanceiraException(string mensagem) : base(mensagem)
    {
    }
    public OperacaoFinanceiraException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
    {
    }
  }
}
