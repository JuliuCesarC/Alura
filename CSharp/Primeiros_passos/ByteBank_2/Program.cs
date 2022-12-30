using ByteBank_2.Employees;
using ByteBank_2.Utils;

Employee Barbosa = new Employee("Barbosa", "111.222.333-44");
Barbosa.Salary = 2990;

Console.WriteLine("Bonificação de Natal: "+ Barbosa.GetBonus());

Manager Sofia = new Manager("Sofia", "313.646.979-55");
Sofia.Salary = 17000;

Console.WriteLine("Bonificação de Natal para Gerente: " + Sofia.GetBonus());

BonusManagement management = new BonusManagement();
management.Register(Barbosa);
management.Register(Sofia);

Console.WriteLine("Total de bonificação de Natal: " + management.TotalBonus);