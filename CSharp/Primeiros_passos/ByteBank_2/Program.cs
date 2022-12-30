
using ByteBank_2.Employees;

Employee Barbosa = new Employee("Barbosa", "111.222.333-44");
Barbosa.Salary = 2990;

Console.WriteLine("Bonificação de Natal: "+ Barbosa.getBonus());
