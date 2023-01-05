using ByteBankIO;
using System;
using System.Text;

#region Aula_01

// class Program
// {
//   static void Main(string[] args)
//   {
//  var fileAddress = "contas.txt";
//  // -------------------- FILESTREAM --------------------
//  // O 'FileStream' é utilizado para criar um "fluxo" de dados de um arquivo, e com esse fluxo podemos executar operações de leitura e gravação síncronas e/ou assíncronas.
//  // Dentro do fluxo de dados, o ideal é trabalhar com partes do arquivo, e não carregar o arquivo inteiro. 
//  var fileStream = new FileStream(fileAddress, FileMode.Open);
//  // Um dos diversos métodos do 'FileStream' é o 'FileMode', que como o nome sugere, permite abrir o arquivo.

//  // Um nome muito conhecido trabalhando com fluxo de dados é o 'buffer', que ira guardar a parte do arquivo que estamos trabalhando.
//  var buffer = new byte[1024];
//  // Criamos um buffer com 1kb de tamanho.
//  fileStream.Read(buffer, 0, 1024);
//  // O método 'Read' como o nome sugere irar ler o arquivo. É preciso informar um buffer e a posição inicial que ira começar a preencher o buffer, e a posição final, no nosso caso, da primeira posição até a ultima (0, 1024).
//  // Retorno do 'Read': ele ira retornar o total de bytes do buffer. Mas pode retornar menos caso o restante do arquivo ou o tamanho do arquivo seja menor do que o buffer. O Read retorna zero caso o fluxo final do arquivo seja atingido.

//  WriteBuffer(buffer);
//  Console.ReadLine();
//}
//static void WriteBuffer(byte[] buffer)
//{
//  // Criamos um método que varre o array e mostra no console cada byte do buffer.
//  foreach(var Bbyte in buffer)
//  {
//    Console.Write(Bbyte);
//    Console.Write(" ");
//  }
// }
#endregion

#region Aula_02

// class Program
// {
//   static void Main(string[] args)
//   {
//  var fileAddress = "contas.txt";
//  var numberOfBytes = -1;
//  var fileStream = new FileStream(fileAddress, FileMode.Open);

//  var buffer = new byte[1024];

//  while (numberOfBytes != 0)
//  // Como vimos na aula 1, Read retorna 0 caso o fluxo de dados chegue no final do arquivo, com isso podemos criar um loop que ira mostrar todos os dados do arquivo, de 1 em 1kb por vez.
//  {
//  numberOfBytes = fileStream.Read(buffer, 0, 1024);
//  WriteBuffer(buffer);
//  }

//  // Mesmo que o programa chegue ao final da leitura, o arquivo ira ficar em standBy, não sendo possível fazer alterações nele como renomear, por isso ao final do comando utilizaremos o 'Close', como foi feito abaixo.
//  fileStream.Close();
//  Console.ReadLine();
//}
//static void WriteBuffer(byte[] buffer)
//{
//  // -------------------- ENCODING --------------------
//  // Para interpretar a lista de códigos que estão sendo exibidos no console, precisamos executar uma decodificação, chamada de 'encoding'.


//  var utf8 = new UTF8Encoding();
//  // O 'UTF8Encoding' é uma classe abstrata do C# que podemos utilizar para fazer o encoding.
//  var text = utf8.GetString(buffer);
//  // Para fazer o encoding, utilizaremos o método 'GetString' passando como parâmetro o array com os códigos dos caracteres, isso resultara no texto decodificado. Após isso é só imprimir no console.

//    Console.Write(text);
//  // foreach( var Bbyte in buffer )
//  // { 
//  //   Console.Write(Bbyte);
//  //   Console.Write(" ");
//  // }
//}
// }
#endregion

#region Using

// class Program
// {
//   static void Main(string[] args)
//   {     
//  var fileAddress = "contas.txt";

//  // -------------------- USING --------------------
//  // O 'using' é uma instrução muito importante e bem extensa, muito utilizada para evitar problemas com uso de memoria como 'memory leaks'. Iremos abordar de maneira bem resumida o funcionamento do 'using'. O 'Garbage Collector' do C# já ira remover por padrão os arquivos que não estão sendo utilizados da memoria do computador, porem arquivos não gerenciais demoram muito, além de quando não serem possíveis de ser removidos, por isso precisam ser fechados manualmente.

//  // A grande funcionalidade do 'using' é que ele automaticamente já faz o 'dispose' do arquivo ao final do comando, independentemente se ocorreu uma exceção durante o processo ou não. Com isso facilitando para o 'garbage collector' remover os arquivos não utilizados. 

//  // O using só pode ser utilizado em objetos que derivem da interface 'IDisposable'. Para verificar se o 'FileStream' implementa o 'IDisposable' podemos selecionar ele e apertar "F12", isso ira mostrar a classe 'FileStream', indo até o topo do arquivo iremos verificar que a classe deriva de 'Stream', que por sua vez apertando "F12" em 'Stream' chegaremos a classe 'Stream' que implementa o 'IDisposable'.

//  // Neste projeto temos o 'Close' no final dos comandos, porem caso ocorra uma exceção durbante a leitura do arquivo, o fluxo do programa é quebrado e o 'Close' nunca é executado.
//  using( var fileStream = new FileStream(fileAddress, FileMode.Open) )
//  // Então utilizaremos o 'using' para verificar se o fluxo de dados(FileStream) é nulo, e caso seja, ira executar o 'dispose' assim fechando o arquivo, evitando assim exceções que prejudiquem o projeto.
//  {
//    var numberOfBytes = -1;
//    var buffer = new byte[1024];

//    while( numberOfBytes != 0 )
//    {
//      numberOfBytes = fileStream.Read(buffer, 0, 1024);
//      WriteBuffer(buffer);
//    }

//    fileStream.Close();
//    Console.ReadLine();
//  }
//}
//static void WriteBuffer(byte[] buffer)
//{
//  var utf8 = new UTF8Encoding();
//  var text = utf8.GetString(buffer);

//  Console.Write(text);
//}
// }
#endregion

#region Aula_03

//class Program
//{
//  static void Main(string[] args)
//  {

//    var fileAddress = "contas.txt";

//    using( var fileStream = new FileStream(fileAddress, FileMode.Open) )
//    {
//      var numberOfBytes = -1;

//      // -------------------- TRABALHANDO COM BUFFER --------------------
//      // O resultado que esta sendo impresso no console possui um problema, no final do arquivo algumas informações estão sendo repetidas. O arquivo sera lido em 1024 bytes por vez, onde os novos bytes substituem os anteriores. Porem chegando no final do arquivo teremos menos de 1024 bytes, onde o buffer sera sobrescrito até o tamanho dessa nova parte, e o restante das informações antigas continuaram la, e posteriormente serão mostradas no console.
//      var buffer = new byte[1024];
//      // Podemos colocar a declaração do 'buffer' dentro do loop 'while', dessa forma sempre sera criado um novo buffer a cada nova parte a ser lida do arquivo. Mas isto não é pratico para o computador e temos uma outra solução, utilizando o próprio 'GetString'.

//      while( numberOfBytes != 0 )
//      {
//        numberOfBytes = fileStream.Read(buffer, 0, 1024);
//        WriteBuffer(buffer, numberOfBytes);
//      }

//      fileStream.Close();
//      Console.ReadLine();
//    }
//  }
//  static void WriteBuffer(byte[] buffer, int numberOfBytesRead)
//  {
//    var utf8 = new UTF8Encoding();
//    // Ao invés de passar apenas o buffer para o 'GetString', fazendo com que ele utilizasse todo o array, agora informaremos também um numero inicial e um final para o 'GetString' começar e terminar de transformar em texto.
//    var text = utf8.GetString(buffer, 0, numberOfBytesRead);
//    // Como no loop 'while' temo a variável 'numberOfBytes' que mostra a quantidade de bytes que foram lidos pelo 'Read', podemos utilizar ele no 'GetString' como o numero final.

//    Console.Write(text);
//  }
//}
#endregion

#region Aula_04
//// -------------------- ORGANIZANDO O CÓDIGO --------------------
//// Para melhorar a legibilidade, a manutenção, e/ou apenas organizar uma classe, podemos dividi-la em vários arquivos, apenas é necessario adicionar o modificador 'partial' antes de 'class', como foi feito abaixo.
//partial class Program
//// Com isso o compilador do C# entendera todas as classes com 'partial' e de mesmo nome, como sendo uma única classe.
//{
//  static void Main(string[] args)
//  {
//    var fileAddress = "contas.txt";

//    using( var fileStream = new FileStream(fileAddress, FileMode.Open) )
//    {
//      var reader = new StreamReader(fileStream);
//      // O 'StreamReader' é uma classe intermediaria que faz a leitura dos bytes do fluxo de dados(fileStream), é possível ler só uma linha, um fragmento, ou até mesmo um arquivo inteiro com os métodos do 'StreamReader'.

//      var first = reader.Read();
//      // O 'Read' ira ler o primeiro byte do arquivo.

//      var line = reader.ReadLine();
//      // O 'ReadLine' como sugere, ira ler uma linha do arquivo.

//      var allText = reader.ReadToEnd();
//      // O 'ReadToEnd' ira ler o arquivo inteiro. Porem como vimos nas aulas anteriores, ler um arquivo por inteiro pode ser um problema se esse arquivo for muito grande. Se esse for o caso o 'StreamReader' possui outros métodos que serão melhores.

//      while( !reader.EndOfStream )
//      // O 'EndOfStream' significa o fim do fluxo de dados, então podemos utilizar ele como condição para um laço de loop, aliado com o 'ReadLine' abaixo.
//      {
//        var line2 = reader.ReadLine();
//        // Dessa forma ele ira carregar e imprimir uma linha por vez no console, repetindo isso até o final do arquivo. Evitando assim ter que carregar um arquivo inteiro.
//        Console.WriteLine(line2);
//      }

//    }

//    Console.ReadLine();
//  }
//}
#endregion

#region Aula_05

//partial class Program
//{
//  static void Main(string[] args)
//  {
//    var fileAddress = "contas.txt";

//    using( var fileStream = new FileStream(fileAddress, FileMode.Open) )
//    {
//      var reader = new StreamReader(fileStream);

//      while( !reader.EndOfStream )
//      {
//        var line = reader.ReadLine();
//        var contaCorrente = StringToCheckingAccount(line);
//        Console.WriteLine($"{contaCorrente.Titular.Nome}: num da conta {contaCorrente.Numero}, agencia {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}");
//      }
//    }
//    Console.ReadLine();
//  }

//  static ContaCorrente StringToCheckingAccount(string line)
//  {
//    // -------------------- ARQUIVO CSV
//    // Arquivos csv(comma-separated values) ou na tradução "valores separados por virgula", é um tipo de arquivos muito utilizados, um exemplo muito conhecido é o editor de planilhas Excel que utiliza esse formato. Neste projeto temos as contas dos clientes do ByteBank também nesse formato, exemplo abaixo:
//    // 353,3477,2345.84,Danilo

//    var field = line.Split(',');
//    // O método 'Split' ira separar a linha em partes onde ocorre o caractere virgula "," como mostra um exemplo de conta no comentário acima.

//    // O arquivo sera separado em 4 partes, cada um sendo uma informação da conta.
//    var bankBranchNumber = field[0];
//    var accountNumber = field[1];
//    var balance = field[2].Replace('.', ',');
//    // Como o saldo da conta esta utilizando o ponto "." para separar os centavos, precisamos substituir ele por virgula ",", pois abaixo iremos converter o saldo para 'double'.
//    var cardholderName = field[3];

//    var bankBranchNumberToInt = int.Parse(bankBranchNumber);
//    var accountNumberToInt = int.Parse(accountNumber);
//    var balanceToDouble = double.Parse(balance);

//    var cardholder = new Cliente();
//    cardholder.Nome = cardholderName;

//    var account = new ContaCorrente(bankBranchNumberToInt, accountNumberToInt);
//    account.Depositar(balanceToDouble);
//    account.Titular = cardholder;

//    return account;
//  }
//}
#endregion

#region Aula_06

//partial class Program
//{
//  static void Main(string[] args)
//  {
//  // -------------------- ESCREVENDO E LENDO EM BINÁRIO
//    WritingInBinary();
//    ReadingInBinary();

//    Console.WriteLine("Aplicação finalizada.");
//    Console.ReadLine();
//  }
//}
#endregion

#region Aula_07

partial class Program
{
  static void Main(string[] args)
  {
    // UsingStreamFromConsole01();
    UsingStreamFromConsole02();

    Console.WriteLine("Aplicação finalizada.");
    Console.ReadLine();
  }
}
#endregion