using ByteBankIO;
using System;
using System.Text;

partial class Program
{
  static void CreateFile()
  {
    // -------------------- CRIANDO ARQUIVOS --------------------
    // Nas aulas anteriores vimos como ler os arquivos de 2 modos, utilizando um buffer junto com os métodos do 'FileStream', e outro menos verboso com o 'StreamReader'. O mesmo se assemelha para criar os arquivos. Começaremos com o meio mais verboso.

    var pathNewFile = "ContasExportadas.csv";
    // Primeiro precisamos informar o caminho onde o arquivo sera gerado. Podemos também adicionar o formato do aquivo no final ".csv", ".txt".
    using( var fileStream = new FileStream(pathNewFile, FileMode.Create) )
    {
      var mockClients = "315,4627,2176.59,Joao\r\n464,4160,4651.51,Joana\r\n236,4302,2318.89,Jorge\r\n173,8027,4660.74,Nair";

      // Anteriormente utilizávamos o Encoding para decodificar um arquivo para o formato UTF-8, agora iremos utiliza-lo para codificar.
      var encoding = Encoding.UTF8;

      var bytes = encoding.GetBytes(mockClients);
      // O 'GetBytes' ira transformar uma string UTF-8 em bytes.

      fileStream.Write(bytes, 0, bytes.Length);
      // O 'Write' recebe os bytes que serão gravado e a posição inicial e a final. Como não sabemos o tamanho do arquivo, utilizamos o 'bytes.Length' que sempre sera o tamanho total do arquivo.
    }
  }
  static void CreateFileWithWriter()
  // Agora utilizando o método 'StreamWriter'. 
  {
    var pathNewFile = "ContasExportadas.csv";

    // Observação: o 'FileMode' possui algumas opções, dentre elas temos o 'Create' e 'CreateNew', a diferença é que o 'CreateNew' só ira criar o arquivo caso ele não exista, já o 'Create' ira substituir o arquivo existente. 
    using( var fileStream = new FileStream(pathNewFile, FileMode.Create) )
    using( var writer = new StreamWriter(fileStream) )
    // Quando utilizamos vários 'using' um seguido do outro, não é preciso abrir o escopo dos 'using' anteriores, apenas o ultimo.
    {
      writer.Write("244,8688,1314.10,Isabel");
      // Como é notável, utilizando o método 'Write' do 'StreamWriter' o programa se torna muito menos verboso.
    }
  }
  static void TestWrite()
  {
    var pathNewFile = "teste.txt";

    using( var fileStream = new FileStream(pathNewFile, FileMode.Create) )
    using( var writer = new StreamWriter(fileStream) )
    // -------------------- FLUSH
    // O método 'flush' tem como função limpar os buffers do fluxo de dados e fazer com que esses dados sejam gravados no arquivo.
    // Até então trabalhando com array, listas, buffers, estávamos utilizando a memoria ram, que é mais rápida, porem agora para gravar no HD ou SDD o tempo que o computador leva para informar a gravação e efetuar a gravação em si é mais demorado. 
    {
      for( int i = 0; i < 1000000; i++ )
      {
        // Quando utilizamos o 'WriteLine', o que realmente estamos fazendo, é enviar uma informação para o buffer do 'StreamWriter', com isso a informação não é despejada no FileStream e a gravação se torna um processo mais demorado.
        writer.WriteLine($"Linha {i}");
        // Caso essa demora possa ser um problema, podemos utilizar o 'Flush'.
        writer.Flush();
        Console.WriteLine($"Linha {i} foi escrita no arquivo, tecle enter");
        Console.ReadLine();
      }

    }
  }
}