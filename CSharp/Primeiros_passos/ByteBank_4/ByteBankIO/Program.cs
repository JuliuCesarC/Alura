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
    var fileAddress = "contas.txt";
    var numberOfBytes = -1;
    var fileStream = new FileStream(fileAddress, FileMode.Open);

    var buffer = new byte[1024];

    while (numberOfBytes != 0)
    // Como vimos na aula 1, Read retorna 0 caso o fluxo de dados chegue no final do arquivo, com isso podemos criar um loop que ira mostrar todos os dados do arquivo, de 1 em 1kb por vez.
    {
    numberOfBytes = fileStream.Read(buffer, 0, 1024);
    WriteBuffer(buffer);
    }

    Console.ReadLine();
  }
  static void WriteBuffer(byte[] buffer)
  {
    // -------------------- ENCODING --------------------
    // Para interpretar a lista de códigos que estão sendo exibidos no console, precisamos executar uma decodificação, chamada de 'encoding'.


    var utf8 = new UTF8Encoding();
    // O 'UTF8Encoding' é uma classe abstrata do C# que podemos utilizar para fazer o encoding.
    var text = utf8.GetString(buffer);
    // Para fazer o encoding, utilizaremos o método 'GetString' passando como parâmetro o array com os códigos dos caracteres, isso resultara no texto decodificado. Após isso é só imprimir no console.

      Console.Write(text);
    // foreach( var Bbyte in buffer )
    // { 
    //   Console.Write(Bbyte);
    //   Console.Write(" ");
    // }
  }
    #endregion
}