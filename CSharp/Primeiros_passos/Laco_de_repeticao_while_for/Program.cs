using System;

class Program
{
  static void Main(string[] args)
  {
    double investimento = 1000.0;
    float rendimento = 0.005f;
    short meses = 12;
    short mes = 1;

    while( mes <= meses )
    {
      investimento += investimento * rendimento;
      Console.WriteLine("Rendimento no mês " + mes + " ficou em: " + investimento.ToString("N2"));
      // O método 'ToString' pode ser utilizado para formatar números, passando o parâmetro "N2" teremos como resultado um numero com apenas 2 dígitos após a virgula. Existem diversos tipos de formatação, para saber mais pesquisar por "Standard numeric format strings".

      // Para garantir que o while não crie um loop infinito, precisamos que a condição se torne 'false' em algum momento. Para esse loop, somaremos +1 a variável 'mes' a cada vez que o programa entra no while.
      mes++;
      // A maneira mais comum é como a acima, porem podemos utilizar os métodos abaixo:
      // mes += 1 ou 2 ou 53: soma à variável o valor apos o =.
      // mes = mes + 1.
    }

    double investimento2 = 5000.0;
    float rendimentoSimplificado = 1.005f;

    for( int mes2 = 1; mes2 <= meses; mes2++ )
    {
      // Diferente do while, as condições para o laço ficam na declaração do mesmo.
      investimento2 *= rendimentoSimplificado;
      Console.WriteLine("Segundo investimento no mês " + mes2 + " rendeu: " + investimento2.ToString("N2"));
    }

    double fatorDeRendimento = 1.001;
    double investimento3 = 10000;

    for( int anos = 1; anos <= 5; anos++ )
    {
      for( int mes3 = 1; mes3 <= 12; mes3++ )
      {
        investimento3 *= fatorDeRendimento;
      }
      Console.WriteLine("Rendimento no ano " + anos + " ficou em: " + investimento3.ToString("N2"));
      fatorDeRendimento += 0.0005;
    }

    Console.WriteLine("Pressione qualquer tecla para sair...");
    Console.ReadLine();
  }
}