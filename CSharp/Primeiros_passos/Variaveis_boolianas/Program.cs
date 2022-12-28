using System;

class Program
{
  static void Main ( string[] args )
  {
    bool trueOrFalse = true;
    // O tipo 'bool' cria variáveis boolianas, que podem receber true ou false.
    int num1 = 40;
    bool conditional = num1 < 77;
    conditional = num1 != 77;

    Console.WriteLine("Variável booliana: " + trueOrFalse);
    Console.WriteLine("Condicional: " + conditional);


    Console.WriteLine("Pressione qualquer tecla para sair...");
    Console.ReadLine();
  }
}