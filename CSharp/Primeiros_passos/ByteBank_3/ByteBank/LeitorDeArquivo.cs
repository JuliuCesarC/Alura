using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  internal class LeitorDeArquivo
  {
    public string Arquivo { get; }
    public LeitorDeArquivo(string arquivo)
    {
      Arquivo= arquivo;
      Console.WriteLine("Abrindo arquivo: "+ arquivo);
    }

    public string LerProximaLinha()
    {
      Console.WriteLine("Lendo linha...");

    // -------------------- IOEXCEPTION --------------------
    // O 'IOException' é uma exceção gerada ao tentar acessar informações de um arquivo. Ele é disparado quando ha alguma falha de leitura ou escrita no arquivo. O 'IO' vem de 'input' e 'output'.
      throw new IOException();
      return "linha do arquivo";
    }
    public void Fechar()
    {
      Console.WriteLine("Fechando arquivo.");
    }
  }
}
