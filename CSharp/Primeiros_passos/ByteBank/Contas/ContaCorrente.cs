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
    private int numero_agencia;

    // Propriedades são comumente usados quando temos campos privados, que suas informações tenham acesso mais restrito, que precisem de alguma verificação e afins. Por convenção o campo privado começa com letra minuscula, e a propriedade desse campo com maiúscula.
    public int Numero_agencia
    {
      // Elas possuem um método 'get' e um 'set', mas podemos ter apenas um deles caso necessario.
      get { return this.numero_agencia; }
      set { if(value > 0){this.numero_agencia = value;} }
      // O método 'set' possui a palavra-chave 'value', que recebe o valor que foi atribuído quando esse campo for chamado. Exemplo: " contaMaria.Numero_agencia = 17; ", no caso 'value' sera 17.
    }
    public string conta;
    private double saldo;
    public Cliente titular;

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
