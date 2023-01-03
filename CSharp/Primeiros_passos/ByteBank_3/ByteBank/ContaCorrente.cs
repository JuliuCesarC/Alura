// using _05_ByteBank;

using System;

namespace ByteBank
{
  public class ContaCorrente
  {
    public Cliente Titular { get; set; }
    public static double TaxaOperacao { get; private set; }
    public static int TotalDeContasCriadas { get; private set; }
    public int ContadorSaquesNaoPermitidos { get; private set; }
    public int ContadorTransferenciaNaoPermitidas { get; private set; }
    private int _agencia;
    public ContaCorrente(int agencia, int numero)
    {
      Agencia = agencia;
      Numero = numero;

      // -------------------- THROW --------------------
      // O 'throw' é responsável por indicar uma ocorrência de uma exceção, podemos informar uma mensagem para o erro, o nome da propriedade que ocorreu essa exceção, entre outros.
      if( agencia <= 0)
      {
        throw new ArgumentException("Agencia precisa ser maior que 0.", nameof(agencia));
        // Primeiro informamos o tipo da exceção, e depois as informação dela.
      }
      if (numero <= 0)
      {
        throw new ArgumentException("Numero precisa ser maior que 0.", nameof(numero));
      }

      TotalDeContasCriadas++;

      try
      {
        TaxaOperacao = 30 / TotalDeContasCriadas;
      }
      catch (DivideByZeroException)
      {
        Console.WriteLine("Não é possível dividir por 0.");
      }
    }
    public int Agencia
    {
      get
      {
        return _agencia;
      }
      private set
      {
        if (value <= 0)
        {
          return;
        }

        _agencia = value;
      }
    }
    public int Numero { get; }

    private double _saldo = 100;

    public double Saldo
    {
      get
      {
        return _saldo;
      }
      set
      {
        if (value < 0)
        {
          return;
        }

        _saldo = value;
      }
    }
    public void Sacar(double valor)
    {
      if (_saldo < valor)
      {
        ContadorSaquesNaoPermitidos++;
        throw new SaldoInsuficienteException("Saldo insuficiente para saque de: "+ valor);
      }

      _saldo -= valor;

    }

    public void Depositar(double valor)
    {
      _saldo += valor;
    }


    public bool Transferir(double valor, ContaCorrente contaDestino)
    {
      try{
        Sacar(valor);
      }catch (SaldoInsuficienteException err) {
        ContadorTransferenciaNaoPermitidas++;
        throw new OperacaoFinanceiraException("Operação não realizada.", err);
      }
      _saldo -= valor;
      contaDestino.Depositar(valor);
      return true;
    }
  }
}
