using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  // -------------------- EXCE��O PERSONALIZADA --------------------
  // Algumas vezes as exce��es padr�es do C# n�o conseguem descrever o erro no nosso programa, para isso podemos criar uma exce��o personalizada.
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
