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
    private int numero_agencia;

    // Propriedades são comumente usados quando temos campos privados, que suas informações tenham acesso mais restrito, que precisem de alguma validação e afins. Por convenção a propriedade começa com letra maiúscula. 
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
    private double saldo;

    // -------------------- MÉTODO CONSTRUTOR --------------------
    // O construtor é um método publico que tem o mesmo nome da Classe, e recebe quantos parâmetros for necessario. 
    // Ao declarar um método construtor, tornasse obrigatório passar os parâmetros exigidos por ele no momento da criação a classe. Pode ser utilizado quando se faz necessario que alguns campos ja tenham um valor desde a declaração da classe. 
    // Por exemplo nesse projeto temos o 'numero_agencia' que deve ter seu valor criado no começo, e não possa ser alterado posteriormente. Utilizaremos o construtor para isso, e também tornaremos o 'setter' dele como privado.
    public ContaCorrente(int numero_agencia, string numero_conta)
    {
      this.Numero_agencia = numero_agencia;
      this.Conta = numero_conta;
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
