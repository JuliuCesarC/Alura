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
}