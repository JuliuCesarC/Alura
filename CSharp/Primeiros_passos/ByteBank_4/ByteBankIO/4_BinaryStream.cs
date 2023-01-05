using ByteBankIO;
using System;
using System.Text;

partial class Program
{
  static void WritingInBinary()
  {
    var pathNewFile = "contaCorrente.txt";
    // -------------------- ESCRITA BINÁRIA --------------------
    // Ao informar para o 'WriteLine' escrever true, ele ira literalmente escrever a palavra true, ocupando muito mais espaço de armazenamento que o apenas true e false, que são valores binários, 1 ou 0. Enquanto true e false ocupam 1 bit cada, um caractere precisa de um byte inteiro, ou seja 8 bits para cara letra.

    using( var fileStream = new FileStream(pathNewFile, FileMode.Create) )
    using( var writer = new BinaryWriter(fileStream) )
    // Podemos então utilizar o 'BinaryWriter' para escrever em binário.
    {

      // Para escrita binaria, não é possível utilizar o 'WriteLine', pois o conceito de linha só é valido para textos.
      writer.Write(456);        //Agencia
      writer.Write(6684132);   //Numero da conta
      writer.Write(4862.55);  //Saldo
      writer.Write("Fabionardo Almilva");
    }
  }
  static void ReadingInBinary()
  {
    using( var fs = new FileStream("contaCorrente.txt", FileMode.Open) )
    using( var reader = new BinaryReader(fs) )
    {
      var bankBranchNumber = reader.ReadInt32();
      var accountNumber = reader.ReadInt32();
      var balance = reader.ReadDouble();
      var cardholder = reader.ReadString();

      Console.WriteLine($"{bankBranchNumber}/{accountNumber}  {cardholder}: {balance}");
    }
  }
}