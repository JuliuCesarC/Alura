using ByteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
  public class ContaCorrente
  {
    // -------------------- PROPRIEDADES --------------------
    // snippet "prop"
    private int numero_agencia;

    // Propriedades são comumente usados para que as informações de um campo privado tenham acesso mais restrito, e/ou que precisem de alguma validação e afins. Por convenção a propriedade começa com letra maiúscula. 
    public int Numero_agencia
    {
      // Elas possuem um método 'get' e um 'set', mas podemos ter apenas um 'get', ou apenas um 'set'.
      get { return this.numero_agencia; }
      private set { if( value > 0 ) { this.numero_agencia = value; } }
      // O método 'set' possui a palavra-chave 'value', que recebe o valor que foi atribuído quando esse campo for chamado. Exemplo: " this.Numero_agencia = 17; ", no caso 'value' sera 17.
    }
    // public string conta;
    public string Conta { get; private set; }
    // public Cliente titular;
    public Cliente Titular { get; set; }
    private double saldo = 0;

    // -------------------- MEMBRO ESTÁTICO --------------------
    // O modificador 'static' serve para tornar por exemplo uma propriedade como estática, tornando assim uma propriedade da classe e não mais do objeto classe. Dessa forma não e necessario criar uma instancia para então ter acesso a propriedade, podemos chamar ela diretamente da classe. Exemplo de propriedade não estática:
    // - ContaCorrente novaConta = new ContaCorrente();
    // - novaConta.propriedadeNaoEstática = ...;
    // Com propriedade estática:
    // - ContaCorrente.propriedadeEstática = ...;
    public static int TotalDeContasCriadas { get; private set; }
    // Além do mas, para este exercício precisamos de uma propriedade que contenha a quantidade de contas criadas, e com um campo normal não seria possível, pois toda vez que a classe fosse instanciada, a propriedade seria novamente declarada, ficando sempre no numero 1. Já com o modificador estático isso não acontece, ele ira somar normalmente a cada nova conta criada. No caso adicionamos mais 1 à propriedade no método construtor abaixo.

    // -------------------- MÉTODO CONSTRUTOR --------------------
    // snippet "ctor"
    // O construtor é um método publico que tem o mesmo nome da Classe, e recebe nenhum ou quantos parâmetros for necessario. Ele é o responsável por guardar o objeto classe na memoria. Toda classe possui já  possui um método construtor, porem ele é declarado implicitamente e recebe nenhum parâmetro
    // Ao declarar um método construtor com parâmetros, tornasse obrigatório passar esses parâmetros no momento da criação a classe. Pode ser utilizado para preencher alguns campos com um valor assim que a classe é declarada. 
    // Por exemplo nesse projeto temos o campo 'numero_agencia' que deve receber um valor no momento da criação da classe, e que não possa ser alterado posteriormente. Utilizaremos o construtor para isso, e também tornaremos o 'setter' desse campo como privado.
    public ContaCorrente(int numero_agencia, string numero_conta)
    {
      this.Numero_agencia = numero_agencia;
      this.Conta = numero_conta;
      TotalDeContasCriadas++;
      // Como a propriedade 'TotalDeContasCriadas' é estática, não precisamos do escopo this.
    }

    public void Depositar(double valor)
    {
      saldo += valor;
    }
    public string Sacar(double valor)
    {
      if( saldo < valor )
      {
        return "Saldo insuficiente";
      }
      else
      {
        saldo -= valor;
        return "Saque efetuado com sucesso";
      }
    }
    public string Transferir(double valor, ContaCorrente destino)
    {
      if( saldo < valor )
      {
        return "Saldo insuficiente para transferência.";
      }
      else
      {
        saldo -= valor;
        destino.saldo += valor;
        return "Transferência realizada com sucesso.";
      }
    }
    public void setSaldo(double valor)
    {
      if( valor > 0 )
      {
        this.saldo = valor;
      }
    }
    public double getSaldo()
    {
      double valor = this.saldo;
      return valor;
    }
  }
}