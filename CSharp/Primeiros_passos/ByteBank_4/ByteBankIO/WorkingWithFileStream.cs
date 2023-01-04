using ByteBankIO;
using System;
using System.Text;

partial class Program
{
  static void WorkingWithFileStream(string[] args)
  { 
    var fileAddress = "contas.txt";

    using( var fileStream = new FileStream(fileAddress, FileMode.Open) )
    {
      var numberOfBytes = -1;
      var buffer = new byte[1024];

      while( numberOfBytes != 0 )
      {
        numberOfBytes = fileStream.Read(buffer, 0, 1024);
        WriteBuffer(buffer, numberOfBytes);
      }
      fileStream.Close();
      Console.ReadLine();
    }
  }
  static void WriteBuffer(byte[] buffer, int numberOfBytesRead)
  {
    var utf8 = new UTF8Encoding();
    var text = utf8.GetString(buffer, 0, numberOfBytesRead);

    Console.Write(text);
  }
}