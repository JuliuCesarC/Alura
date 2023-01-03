using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  class Program
  {
    static void Main(string[] args)
    {
      // -------------------- TRY CATCH --------------------
      // O 'try' como o nome sugere, ira tentar executar um comando dentro do seu escopo, e caso aconteça algum erro o 'catch' ficara com a responsabilidade de tratar esse erro.  
      try
      {
        ContaCorrente conta = new ContaCorrente(148613, 0);
        // Dentro do 'try' podemos executar métodos que iram ocorrer em outra classe ou arquivo, com isso precisamos de um 'throw' no local onde o erro pode ocorrer, para que possa ser tratado dentro desse 'try'.
      }
      catch( ArgumentException err )
      // No 'catch' primeiro vem a exceção que pode acontecer, e segundo a variável que recebera as informações desse erro, lembrando que essas informações são enviadas pelo 'throw'.
      {
        Console.WriteLine("Erro no parâmetro: "+ err.ParamName);
        // O 'ParamName' é um método de 'ArgumentException' que mostra em qual parâmetro houve o erro. Esse nome deve ser informado no 'throw'.
        Console.WriteLine("Ocorreu um erro de ArgumentException");
        Console.WriteLine(err);
      }

      Console.WriteLine("Taxa de operação: " + ContaCorrente.TaxaOperacao);
      Console.ReadLine();
    }
  }
}
