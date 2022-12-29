using ByteBank.Contas;
using ByteBank.Titular;

// -------------------- ERRO DE REFERENCIA NULA --------------------
// Quando temos uma classe, que um dos seus campos faz referencia a outra classe, somos obrigados a criar uma instancia para as 2 classes, e não apenas à classe "pai". Podemos criar uma instancia diretamente, atribuir valores a ela, e depois atribuir essa instancia à variável, como vemos abaixo:
Cliente dadosJão = new Cliente();
dadosJão.nome = "Jão Marques";
dadosJão.cpf = "111.222.333-44";
dadosJão.profissao = "Dev";
ContaCorrente contaJão = new ContaCorrente();
// Apos criar os valores para a instancia 'Cliente', atribuímos ela para o campo 'titular'.
contaJão.titular = dadosJão;
contaJão.Numero_agencia = 15;
contaJão.conta = "1010-X";
contaJão.setSaldo(100);
// Outra maneira é criando uma instancia diretamente na declaração da variável, e fazer o encadeamento para atribuir os valores nos campos dessa classe, como foi feito abaixo:
ContaCorrente contaMaria = new ContaCorrente();
contaMaria.titular = new Cliente();
contaMaria.titular.nome = "Maria silva";
// Para acessar a variável 'nome', fazemos o encadeamento 'contaMaria.titular.nome'.
contaMaria.titular.cpf = "121.222.313-44";
contaMaria.titular.profissao = "Design";
contaMaria.Numero_agencia = 17;
contaMaria.conta = "1310-5";
contaMaria.setSaldo(350);

Console.WriteLine("Numero da agencia Jão: "+ contaJão.Numero_agencia);
//Console.WriteLine("Saldo da conta de "+contaJão.titular.nome+": "+contaJão.getSaldo());
//contaJão.Depositar(150);
//Console.WriteLine("Saldo apos o deposito: "+contaJão.getSaldo());


//Console.WriteLine("Sacando 70 reais: "+ contaJão.Sacar(70) + ", saldo= "+contaJão.getSaldo());
//Console.WriteLine("Sacando 200 reais: "+ contaJão.Sacar(200)+", saldo= " + contaJão.getSaldo());



//Console.WriteLine("Saldo da conta de "+contaMaria.titular.nome + ": "+contaMaria.getSaldo());
//contaJão.Transferir(80, contaMaria);
//Console.WriteLine("Saldo da conta de "+contaJão.titular.nome + " apos transferência: "+contaJão.getSaldo());
//Console.WriteLine("Saldo da conta de "+contaMaria.titular.nome + " apos deposito: "+contaMaria.getSaldo());

