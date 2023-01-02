using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_2.Employees
{
  #region Aula_01
  //internal class Employee
  //{
  //  public string Name { get; set; }
  //  public string CPF { get; private set; }
  //  public double Salary { get; protected set; }
  //  // A palavra chave 'protected' serve para dar visibilidade à propriedades ou métodos da superClasse apenas para as classes filhas. Isso garante que o campo não seja publico e que somente possa ser acessado pela superClasse e classes derivadas.
  //  public Employee(string name, string cpf, double salary)
  //  {
  //    this.Name = name;
  //    this.CPF = cpf;
  //    this.Salary = salary;
  //    TotalNumberEmployees++;
  //  }

  //  public static int TotalNumberEmployees { get; private set; }
  //  public virtual double GetBonus()
  //  // O modificador 'virtual' indica que esse método pode ser sobrescrito pela classe(Manager) que herdara esta Classe(Employee).
  //  {
  //    return this.Salary * 0.10;
  //  }

  //  public virtual void IncreaseSalary()
  //  {
  //    this.Salary = this.Salary + (this.Salary * 0.1);
  //  }
  //}

  #endregion

  #region Aula_02
  // -------------------- CLASSE ABSTRATA --------------------
    // O modificador 'abstract' torna a classe em uma base para outras classes. Serve apenas para ser herdada por outras classes concretas. Além disso, não é possível criar uma instancia diretamente dessa classe.
  public abstract class Employee
  {
    public string Name { get; set; }
    public string CPF { get; private set; }
    public double Salary { get; protected set; }
    // Uma classe abstrata ainda pode ter um método construtor.
    public Employee(string name, string cpf, double salary)
    {
      this.Name = name;
      this.CPF = cpf;
      this.Salary = salary;
      TotalNumberEmployees++;
    }

    public static int TotalNumberEmployees { get; private set; }

  // -------------------- MÉTODOS ABSTRATOS --------------------
  // Um método abstrato é apenas uma declaração de que este método precisa ser implementado na classe que ira derivar dessa classe.
    public abstract double GetBonus();
    // Ou seja o código abaixo não pode ser implementado no método abstrato.
    // {
    //   return this.Salary * 0.10;
    // }

    public abstract void IncreaseSalary();
  }

  #endregion
}
