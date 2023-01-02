using ByteBank_2.Employees;
using ByteBank_2.Utils;

Employee Barbosa = new Employee("Barbosa", "111.222.333-44", 2990);
Console.WriteLine("Salario de Barbosa: "+ Barbosa.Salary);

Manager Sofia = new Manager("Sofia", "313.646.979-55", 8450);
Console.WriteLine("Salario de Sofia: "+ Sofia.Salary);

Console.WriteLine("Bonificação de Natal: "+ Barbosa.GetBonus());
Console.WriteLine("Bonificação de Natal para Gerente: " + Sofia.GetBonus());

BonusManagement management = new BonusManagement();
management.Register(Barbosa);
management.Register(Sofia);

Console.WriteLine("Total de bonificação de Natal: " + management.TotalBonus);
System.Console.WriteLine("Total de funcionários: " + Employee.TotalNumberEmployees);

Barbosa.IncreaseSalary();
Sofia.IncreaseSalary();

Console.WriteLine("Novo salario de Barbosa: "+ Barbosa.Salary);
Console.WriteLine("Novo salario de Sofia: "+ Sofia.Salary);