using System;

class Program
{
  static void Main ( string[] args )
  {
    char letra = 'a';
    // O 'char' pode armazenar apenas um caractere, e na declaração é preciso utilizar aspas simples.
    char numeroDaLetra = (char)65;
    // Letras e símbolos possuem um numero de identificação, então ao atribuir um numero como 'char', teremos o caractere sendo atribuído a variável. 65 é a letra A.
    string frase = "qualquer coisa aqui";
    // Com o tipo 'string' podemos guardar um conjunto de caracteres.

    string empty = "";
    // É possível guardar uma string vazia no tipo string.
    char space = ' ';
    // Já com o char, é preciso guardar algo, e o espaço também é considerado como caractere.

    string list = @"Cursos na Alura:
    -git
      -GitHub
    -Javascript
      -TypeScript
    -c#
    -React";
    // Ao utilizar um @ na frente da string, faz com que as quebras de linha e espaçamento sejam respeitadas.
    
    Console.WriteLine("Letra: " + letra);
    Console.WriteLine("numero da letra: " + numeroDaLetra);
    Console.WriteLine("frase: " + frase);
    Console.WriteLine("vazio: " + empty);
    Console.WriteLine("espaço: " + space);
    Console.WriteLine("Lista de cursos: " + list);

    Console.WriteLine("Pressione qualquer tecla para sair...");
    Console.ReadLine();
  }
}