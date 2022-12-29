using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  public class ContaCorrente
  {
    public int numero_agencia;
    public string conta;
    public string titular;
    public double saldo;

    public void Depositar(double valor)
    {
      this.saldo += valor;
    }
    public string Sacar(double valor)
    {
      if(this.saldo < valor)
      {
        return "Saldo insuficiente";
      }
      else
      {
      this.saldo -= valor;
        return "Saque efetuado com sucesso";
      }
    }
    public string Transferir(double valor, ContaCorrente destino) 
    {
      if(this.saldo < valor )
      {
        return "Saldo insuficiente para transferência.";
      }
      else
      {
        this.saldo -= valor;
        destino.saldo += valor;
        return "Transferência realizada com sucesso.";
      }
    }
  }
}
