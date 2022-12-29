using ByteBank;

ContaCorrente contaJão = new ContaCorrente();

contaJão.titular = "Jão Marques";
contaJão.numero_agencia = 15;
contaJão.conta = "1010-X";
contaJão.saldo = 100;

ContaCorrente conta3 = contaJão;
conta3.saldo = 1000;
Console.WriteLine("saldo jão: "+ contaJão.saldo);
Console.WriteLine("saldo 3: "+ conta3.saldo);

Console.WriteLine("Saldo da conta de "+contaJão.titular+": "+contaJão.saldo);
contaJão.Depositar(150);

Console.WriteLine("Saldo apos o deposito: "+contaJão.saldo);


Console.WriteLine("Sacando 70 reais: "+ contaJão.Sacar(70) + ", saldo= "+contaJão.saldo);

Console.WriteLine("Sacando 200 reais: "+ contaJão.Sacar(200)+", saldo= " + contaJão.saldo);

ContaCorrente contaMaria = new ContaCorrente();
contaMaria.titular = "Maria Silva";
contaMaria.numero_agencia = 17;
contaMaria.conta = "1310-5";
contaMaria.saldo = 350;

Console.WriteLine("Saldo da conta de "+contaMaria.titular +": "+contaMaria.saldo);

contaJão.Transferir(80, contaMaria);
Console.WriteLine("Saldo da conta de "+contaJão.titular +" apos transferência: "+contaJão.saldo);
Console.WriteLine("Saldo da conta de "+contaMaria.titular +" apos deposito: "+contaMaria.saldo);

