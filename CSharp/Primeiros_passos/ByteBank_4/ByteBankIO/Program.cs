using ByteBankIO;
using System;
using System.Text;

class Program
{
  static void Main(string[] args)
  {
    #region Aula_01
    //  var fileAddress = "contas.txt";
    //  // -------------------- FILESTREAM --------------------
    //  // O 'FileStream' é utilizado para criar um "fluxo" de dados de um arquivo, e com esse fluxo podemos executar operações de leitura e gravação síncronas e/ou assíncronas.
    //  // Dentro do fluxo de dados, o ideal é trabalhar com partes do arquivo, e não carregar o arquivo inteiro. 
    //  var fileStream = new FileStream(fileAddress, FileMode.Open);
    //  // Um dos diversos métodos do 'FileStream' é o 'FileMode', que como o nome sugere, permite abrir o arquivo.

    //  // Um nome muito conhecido trabalhando com fluxo de dados é o 'buffer', que ira guardar a parte do arquivo que estamos trabalhando.
    //  var buffer = new byte[1024];
    //  // Criamos um buffer com 1kb de tamanho.
    //  fileStream.Read(buffer, 0, 1024);
    //  // O método 'Read' como o nome sugere irar ler o arquivo. É preciso informar um buffer e a posição inicial que ira começar a preencher o buffer, e a posição final, no nosso caso, da primeira posição até a ultima (0, 1024).
    //  // Retorno do 'Read': ele ira retornar o total de bytes do buffer. Mas pode retornar menos caso o restante do arquivo ou o tamanho do arquivo seja menor do que o buffer. O Read retorna zero caso o fluxo final do arquivo seja atingido.

    //  WriteBuffer(buffer);
    //  Console.ReadLine();
    //}
    //static void WriteBuffer(byte[] buffer)
    //{
    //  // Criamos um método que varre o array e mostra no console cada byte do buffer.
    //  foreach(var Bbyte in buffer)
    //  {
    //    Console.Write(Bbyte);
    //    Console.Write(" ");
    //  }

    #endregion

    #region Aula_02
    //  var fileAddress = "contas.txt";
    //  var numberOfBytes = -1;
    //  var fileStream = new FileStream(fileAddress, FileMode.Open);

    //  var buffer = new byte[1024];

    //  while (numberOfBytes != 0)
    //  // Como vimos na aula 1, Read retorna 0 caso o fluxo de dados chegue no final do arquivo, com isso podemos criar um loop que ira mostrar todos os dados do arquivo, de 1 em 1kb por vez.
    //  {
    //  numberOfBytes = fileStream.Read(buffer, 0, 1024);
    //  WriteBuffer(buffer);
    //  }

    //  // Mesmo que o programa chegue ao final da leitura, o arquivo ira ficar em standBy, não sendo possível fazer alterações nele como renomear, por isso ao final do comando utilizaremos o 'Close', como foi feito abaixo.
    //  fileStream.Close();
    //  Console.ReadLine();
    //}
    //static void WriteBuffer(byte[] buffer)
    //{
    //  // -------------------- ENCODING --------------------
    //  // Para interpretar a lista de códigos que estão sendo exibidos no console, precisamos executar uma decodificação, chamada de 'encoding'.


    //  var utf8 = new UTF8Encoding();
    //  // O 'UTF8Encoding' é uma classe abstrata do C# que podemos utilizar para fazer o encoding.
    //  var text = utf8.GetString(buffer);
    //  // Para fazer o encoding, utilizaremos o método 'GetString' passando como parâmetro o array com os códigos dos caracteres, isso resultara no texto decodificado. Após isso é só imprimir no console.

    //    Console.Write(text);
    //  // foreach( var Bbyte in buffer )
    //  // { 
    //  //   Console.Write(Bbyte);
    //  //   Console.Write(" ");
    //  // }
    //}
    #endregion

    #region Aula_03
    var fileAddress = "contas.txt";

    // -------------------- USING --------------------
    // O 'using' é uma instrução muito importante e bem extensa, muito utilizada para evitar problemas com uso de memoria como 'memory leaks'. Iremos abordar de maneira bem resumida o funcionamento do 'using'. O 'Garbage Collector' do C# já ira remover por padrão os arquivos que não estão sendo utilizados da memoria do computador, porem arquivos não gerenciais demoram muito, além de quando não serem possíveis de ser removidos, por isso precisam ser fechados manualmente.

    // A grande funcionalidade do 'using' é que ele automaticamente já faz o 'dispose' do arquivo ao final do comando, independentemente se ocorreu uma exceção durante o processo ou não. Com isso facilitando para o 'garbage collector' remover os arquivos não utilizados. 

    // O using só pode ser utilizado em objetos que derivem da interface 'IDisposable'. Para verificar se o 'FileStream' implementa o 'IDisposable' podemos selecionar ele e apertar "F12", isso ira mostrar a classe 'FileStream', indo até o topo do arquivo iremos verificar que a classe deriva de 'Stream', que por sua vez apertando "F12" em 'Stream' chegaremos a classe 'Stream' que implementa o 'IDisposable'.

    // Neste projeto temos o 'Close' no final dos comandos, porem caso ocorra uma exceção durbante a leitura do arquivo, o fluxo do programa é quebrado e o 'Close' nunca é executado.
    using( var fileStream = new FileStream(fileAddress, FileMode.Open) )
    // Então utilizaremos o 'using' para verificar se o fluxo de dados(FileStream) é nulo, e caso seja, ira executar o 'dispose' assim fechando o arquivo, evitando assim exceções que prejudiquem o projeto.
    {
      var numberOfBytes = -1;
      var buffer = new byte[1024];

      while( numberOfBytes != 0 )
      {
        numberOfBytes = fileStream.Read(buffer, 0, 1024);
        WriteBuffer(buffer);
      }

      fileStream.Close();
      Console.ReadLine();
    }
  }
  static void WriteBuffer(byte[] buffer)
  {
    var utf8 = new UTF8Encoding();
    var text = utf8.GetString(buffer);

    Console.Write(text);
  }
  #endregion
}