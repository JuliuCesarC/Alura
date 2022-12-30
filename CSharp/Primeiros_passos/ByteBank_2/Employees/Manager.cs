using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  // -------------------- HERANÇA --------------------
  // Herança é quando uma classe herda métodos, propriedades, campos de outra classe. Muito utilizado para evitar duplicação de código, pois por vezes os campos de uma classe, são os mesmos para outra.
  // Para herdar de uma classe, o comando fica assim: "classeQueHerdara: ClasseBase".
  internal class Manager: Employee
  {
    // Lembrando que o método construtor não é herdado, então precisamos sobrescrever o construtor. Abaixo temos uma maneira para resolver esse problema.
    public Manager(string name, string cpf) : base(name, cpf)
    // Mais abaixo explicaremos mais sobre o "base", mas para este contexto ele permite acessar os 2 campos que são exigidos pelo construtor da superClasse. Com isso não sendo obrigatório rescrever os códigos dentro do construtor.
    {
    }
    // Caso seja necessario que o método herdado seja diferente da classe base, precisamos sobrescrever o método, como foi feito abaixo:
    // public double GetBonus()
    // {
    //   return Salary;
    // }

    // -------------------- SOBRESCREVENDO MÉTODOS --------------------
    // Quando um método herdado é sobrescrito, temos criado um problema de sobreposição de método, pois agora a classeFilha sera aceita como o tipo dela mesma, e como o tipo da classePai. Ao executamos o método através do tipo da classeFilha, o código sera executado normalmente, porem quando executamos esse método como o tipo da classePai, sera executado o método original, e não o novo método.
    // Para resolver esse problema, no método da classePai iremos adicionar o modificador 'virtual', e no método da classeFilha, o modificador 'override'.
    public override double GetBonus()
    // O 'override' como o nome sugere, ira sobrescrever o método da classePai.
    {
      return this.Salary + base.GetBonus();
      // --------------- BASE
      // A palavra reservada 'base' permite acessar os métodos, campos, propriedades da superClasse em uma classe derivada. Com isso podemos executar métodos da classePai dentro da classeFilha, e como vimos acima, podemos acessar os campos na declaração do método construtor.
    }
  }
}
