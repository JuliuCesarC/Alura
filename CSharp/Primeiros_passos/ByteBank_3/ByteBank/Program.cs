using ByteBank;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  class Program
  {
    static void Main(string[] args)
    {

      #region Aula_01

      //// -------------------- TRY CATCH --------------------
      //// O 'try' como o nome sugere, ira tentar executar um comando dentro do seu escopo, e caso aconteça algum erro o 'catch' ficara com a responsabilidade de tratar esse erro.  
      //try
      //{
      //  ContaCorrente conta = new ContaCorrente(0, 68464);
      //  // Dentro do 'try' podemos executar métodos que iram ocorrer em outra classe ou arquivo, com isso precisamos de um 'throw' no local onde o erro pode ocorrer, para que possa ser tratado dentro desse 'try'.
      //  conta.Depositar(50);
      //  System.Console.WriteLine(conta.Saldo);
      //  conta.Sacar(350);
      //  System.Console.WriteLine(conta.Saldo);
      //}
      //catch( ArgumentException err )
      //// No 'catch' primeiro vem a exceção que pode acontecer, e segundo a variável que recebera as informações desse erro, lembrando que essas informações são enviadas pelo 'throw'.
      //{
      //  Console.WriteLine("Erro no parâmetro: " + err.ParamName);
      //  // O 'ParamName' é um método de 'ArgumentException' que mostra em qual parâmetro houve o erro. Esse nome deve ser informado no 'throw'.
      //  Console.WriteLine("Ocorreu um erro de ArgumentException");
      //  Console.WriteLine(err.Message);
      //  // O 'Message' ira mostrar a mensagem informada pelo 'throw'.
      //  Console.WriteLine(err.StackTrace);
      //  // O 'StackTrace' de forma resumida, ira mostrar em quais arquivos ocorreu o erro e sua localização.
      //}
      //catch( SaldoInsuficienteException err )
      //{
      //  Console.WriteLine(err.Message);
      //  Console.WriteLine("Exceção de saldo insuficiente.");
      //}

      //Console.WriteLine("Taxa de operação: " + ContaCorrente.TaxaOperacao);
      //Console.ReadLine();
      #endregion

      #region Aula_02
      //try
      //{
      //  ContaCorrente conta = new ContaCorrente(45664, 68464);
      //  ContaCorrente conta2 = new ContaCorrente(568643, 1324138);
      //  conta.Depositar(50);
      //  Console.WriteLine(conta.Saldo);
      //  conta.Transferir(500, conta2);
      //  Console.WriteLine(conta.Saldo);
      //}
      //catch (ArgumentException err)
      //{
      //  Console.WriteLine("Erro no parâmetro: " + err.ParamName);
      //  Console.WriteLine("Ocorreu um erro do tipo ArgumentException");
      //  Console.WriteLine(err.Message);
      //  Console.WriteLine(err.StackTrace);
      //}
      //catch (OperacaoFinanceiraException err)
      //{
      //  Console.WriteLine(err.Message);
      //  Console.WriteLine(err.StackTrace);

      //  Console.WriteLine("Informações da INNER EXCEPTION: ");

      //  // -------------------- INNEREXCEPTION --------------------
      //  // Não é interessante que algumas informações de erros e exceções internos da aplicação sejam mostrados ao usuário, por isso, podemos utilizar o 'InnerException' para que as informações da exceção sejam mostradas apenas para o desenvolvedor. Em uma tradução mais direta ficaria "exceção mais interna".
      //  Console.WriteLine(err.InnerException.Message);
      //  Console.WriteLine(err.InnerException.StackTrace);
      //  // O 'InnerException.StackTrace' ira mostrar em qual instancia ocorreu a exceção. 
      //}

      //Console.ReadLine();
      #endregion

      #region Aula_03
      CarregarContas();

      Console.ReadLine();
    }
    private static void CarregarContas()
    {
      LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");
      try{
      leitor.LerProximaLinha();
      leitor.LerProximaLinha();
      leitor.LerProximaLinha();
      }catch(IOException err)
      {
        Console.WriteLine("Exceção do tipo IOException capturada.");
      }
      // -------------------- FINALLY --------------------
      // Os comandos dentro do 'finally' sempre serão executados apos o bloco do Try-Catch, e isso independe se o try capturar uma exceção ou não.
      finally
      // Por exemplo, pode ser utilizado para fechar um arquivo que sera lido, e mesmo que ocorra um erro na leitura, ele precise ser finalizado.
      {
      leitor.Fechar();
      }
    }
      #endregion
  }
}


