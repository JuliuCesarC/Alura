using ByteBankIO;
using System;
using System.Text;

partial class Program
{
  static void UsingStreamFromConsole01()
  {
    // -------------------- UTILIZANDO O STREAM COM O CONSOLE --------------------
    // O console do C# possui interações com o usuário, e podemos utilizar essas interações para por exemplo escrever o que o usuário digitou no console em um arquivo.
    
    using( var fsInput = Console.OpenStandardInput() )
    // O 'OpenStandardInput' permite ler o que esta escrito no console do usuário.
    {
      var buffer = new byte[1024];
      while( true )
      // Neste caso utilizamos o 'while' para que o usuário possa teclar enter quantas vezes quiser sem que a aplicação seja finalizada.
      {
      var bytesRead = fsInput.Read(buffer, 0, 1024);
      // Os métodos são muito semelhantes ao utilizado com o 'FileStream', precisamos de um buffer, precisamos informar aonde começa e aonde termina de preencher o buffer.

      Console.WriteLine($"Bytes lidos no console: {bytesRead}");
      }
    }
  }
  static void UsingStreamFromConsole02()
  {
    // -------------------- JUNTANDO O FILESTREAM COM O CONSOLE
    using( var fsInput = Console.OpenStandardInput() )
    using (var fs = new FileStream("InputConsole.txt", FileMode.Create))
    // Para escrever um arquivo, precisamos trazer o 'FileStream' com o 'FileMode.Create'.
    {
      var buffer = new byte[1024];
      while( true )
      {
      var bytesRead = fsInput.Read(buffer, 0, 1024);

      // Agora para escrever no arquivo, utilizaremos o 'Write' passando as informações necessárias.
      fs.Write(buffer, 0, bytesRead);
      // Como estamos dentro de um laço de loop que nunca fecha, o arquivo nunca sera fechado e as informações nunca serão despejadas. Como ja vimos anteriormente, podemos contornar isso com o 'Flush'.
      fs.Flush();
      
      Console.WriteLine($"Bytes lidos no console: {bytesRead}");
      }
    }
  }
}