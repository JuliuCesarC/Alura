using ByteBank.Contas;
using ByteBank.Titular;

// -------------------- ERRO DE REFERENCIA NULA --------------------
// Quando temos uma classe, que um dos seus campos faz referencia a outra classe, somos obrigados a criar uma instancia para as 2 classes, e não apenas à classe "pai". Podemos criar uma instancia diretamente, atribuir valores a ela, e depois atribuir essa instancia à variável, como vemos abaixo:
Cliente dadosJão = new Cliente();
dadosJão.Nome = "Jão Marques";
dadosJão.Cpf = "111.222.333-44";
dadosJão.Profissao = "Dev";
ContaCorrente contaJão = new ContaCorrente(15, "1010-X");
// Apos criar os valores para a instancia 'Cliente', atribuímos ela para o campo 'titular'.
contaJão.Titular = dadosJão;
contaJão.setSaldo(100);
// Outra maneira é criando uma instancia diretamente na declaração da variável, e fazer o encadeamento para atribuir os valores nos campos dessa classe, como foi feito abaixo:
ContaCorrente contaMaria = new ContaCorrente(17, "1310-5");
contaMaria.Titular = new Cliente();
contaMaria.Titular.Nome = "Maria silva";
// Para acessar a variável 'nome', fazemos o encadeamento 'contaMaria.titular.nome'.
contaMaria.Titular.Cpf = "121.222.313-44";
contaMaria.Titular.Profissao = "Design";
contaMaria.setSaldo(350);


Console.WriteLine("Numero da agencia Jão: " + contaJão.Numero_agencia);
contaJão.Depositar(150);
Console.WriteLine("Saldo apos o deposito: " + contaJão.getSaldo());

Console.WriteLine("Sacando 70 reais: " + contaJão.Sacar(70) + ", saldo= " + contaJão.getSaldo());
Console.WriteLine("Sacando 200 reais: " + contaJão.Sacar(200) + ", saldo= " + contaJão.getSaldo());

//Console.WriteLine("Saldo da conta de "+contaMaria.titular.nome + ": "+contaMaria.getSaldo());
//contaJão.Transferir(80, contaMaria);
//Console.WriteLine("Saldo da conta de "+contaJão.titular.nome + " apos transferência: "+contaJão.getSaldo());
//Console.WriteLine("Saldo da conta de "+contaMaria.titular.nome + " apos deposito: "+contaMaria.getSaldo());

