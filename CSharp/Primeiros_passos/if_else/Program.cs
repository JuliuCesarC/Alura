using System;

class Program
{
  static void Main(string[] args)
  {

    int idade = 17;
    bool acompanhado = true;

    if (idade >= 18 || acompanhado)
    {
      Console.WriteLine("Pode entrar.");
    }
    else
    {
      Console.WriteLine("Não pode entrar.");
    }


    Console.WriteLine("Pressione qualquer tecla para sair...");
    Console.ReadLine();
  }
}
