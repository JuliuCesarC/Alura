using ByteBank_2.CommercialPartners;
using ByteBank_2.Employees;
using ByteBank_2.InternalSystem;
using ByteBank_2.Utils;

#region Aula_01
//Employee Barbosa = new Employee("Barbosa", "111.222.333-44", 2990);
//Console.WriteLine("Salario de Barbosa: "+ Barbosa.Salary);

//Manager Sofia = new Manager("Sofia", "313.646.979-55");
//Console.WriteLine("Salario de Sofia: "+ Sofia.Salary);

//Console.WriteLine("Bonificação de Natal: "+ Barbosa.GetBonus());
//Console.WriteLine("Bonificação de Natal para Gerente: " + Sofia.GetBonus());

//BonusManagement management = new BonusManagement();
//management.Register(Barbosa);
//management.Register(Sofia);

//Console.WriteLine("Total de bonificação de Natal: " + management.TotalBonus);
//System.Console.WriteLine("Total de funcionários: " + Employee.TotalNumberEmployees);

//Barbosa.IncreaseSalary();
//Sofia.IncreaseSalary();

//Console.WriteLine("Novo salario de Barbosa: "+ Barbosa.Salary);
//Console.WriteLine("Novo salario de Sofia: "+ Sofia.Salary);
#endregion

#region Aula_02

// SalaryBonusCalculator();
void SalaryBonusCalculator()
{
  BonusManagement management = new BonusManagement();

  Designer Gabriel = new Designer("Gabriel", "689.561.988-75");
  AccountManager Jennifer = new AccountManager("Jennifer", "468.532.597-15");
  AccountAssistant Nacimento = new AccountAssistant("Nacimento", "651.234.787-56");
  Director Felipe = new Director("Felipe", "216.489.863-44");

  management.Register(Gabriel);
  management.Register(Jennifer);
  management.Register(Nacimento);
  management.Register(Felipe);

  System.Console.WriteLine("Total de bonificação: "+ management.TotalBonus);
}
LogIntoSystem();
void LogIntoSystem()
{
  InternalSystem system = new InternalSystem();

  AccountManager Pedro = new AccountManager("Pedro", "354.891.654-78");
  Pedro.Password = "123456";
  AccountManager Giovana = new AccountManager("Giovana", "987.546.168-49");
  Giovana.Password = "123456";

  CommercialPartner Marcela = new CommercialPartner();
  Marcela.Password = "456789";


  system.Login(Pedro, "123456");
  system.Login(Giovana, "12345");
  system.Login(Marcela, "456789");
}

#endregion