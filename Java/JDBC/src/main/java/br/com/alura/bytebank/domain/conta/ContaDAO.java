package br.com.alura.bytebank.domain.conta;

import br.com.alura.bytebank.domain.cliente.Cliente;
import br.com.alura.bytebank.domain.cliente.DadosCadastroCliente;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashSet;
import java.util.Set;

public class ContaDAO {
  private Connection conn;

  public ContaDAO(Connection connection) {
    this.conn = connection;
  }

  public void salvar(DadosAberturaConta dadosDaConta) {
    var cliente = new Cliente(dadosDaConta.dadosCliente());
    var conta = new Conta(dadosDaConta.numero(), BigDecimal.ZERO, cliente);

    String sql = "INSERT INTO conta(numero,saldo,cliente_nome,cliente_cpf,cliente_email)" +
      "VALUES(?,?,?,?,?)";

    try {
      PreparedStatement preparedStatement = conn.prepareStatement(sql);

      preparedStatement.setInt(1, conta.getNumero());
      preparedStatement.setBigDecimal(2, BigDecimal.ZERO);
      preparedStatement.setString(3, dadosDaConta.dadosCliente().nome());
      preparedStatement.setString(4, dadosDaConta.dadosCliente().cpf());
      preparedStatement.setString(5, dadosDaConta.dadosCliente().email());

      preparedStatement.execute();
      preparedStatement.close();
      conn.close();
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
  }

  public Set<Conta> listar() {
    Set<Conta> contas = new HashSet<>();
    PreparedStatement ps;
    ResultSet rs;

    String sql = "SELECT * FROM conta";
    try {
      ps = conn.prepareStatement(sql);
      rs = ps.executeQuery();

      while (rs.next()) {
        Integer numero = rs.getInt("numero");
        BigDecimal saldo = rs.getBigDecimal(2);
        String nome = rs.getString("cliente_nome");
        String cpf = rs.getString(4);
        String email = rs.getString(5);

        DadosCadastroCliente dadosCadastroCliente =
          new DadosCadastroCliente(nome, cpf, email);
        Cliente cliente = new Cliente(dadosCadastroCliente);

        contas.add(new Conta(numero, saldo, cliente));
      }
      ps.close();
      rs.close();
      conn.close();
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
    return contas;
  }

  public Conta listarPorNumero(Integer numeroBusca) {
    Conta conta;
    PreparedStatement ps;
    ResultSet rs;
    String sql = "SELECT * FROM conta WHERE numero = ?";

    try {
      ps = conn.prepareStatement(sql);
      ps.setInt(1, numeroBusca);
      rs = ps.executeQuery();
      rs.next();

      Integer numero = rs.getInt(1);
      BigDecimal saldo = rs.getBigDecimal(2);
      String nome = rs.getString(3);
      String cpf = rs.getString(4);
      String email = rs.getString(5);

      DadosCadastroCliente dadosCadastroCliente =
        new DadosCadastroCliente(nome, cpf, email);
      Cliente cliente = new Cliente(dadosCadastroCliente);
      conta = new Conta(numero, saldo, cliente);
      ps.execute();
      ps.close();
      conn.close();
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
    return conta;
  }

  public void depositar(Conta conta, BigDecimal valor) {
    PreparedStatement ps;
    String sql = "UPDATE conta SET saldo = ? WHERE numero = ?";

    try {
      BigDecimal newSaldo = conta.getSaldo().add(valor);
      ps = conn.prepareStatement(sql);

      ps.setBigDecimal(1, newSaldo);
      ps.setInt(2, conta.getNumero());
      ps.execute();
      ps.close();
      conn.close();
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
  }

  public void sacar(Conta conta, Integer numero, BigDecimal valor) {
    PreparedStatement ps;
    ResultSet rs;
    String sqlUp = "UPDATE conta SET saldo = ? WHERE numero = ?";

    try {
      BigDecimal prevSaldo = conta.getSaldo();
      BigDecimal newSaldo = prevSaldo.subtract(valor);

      ps = conn.prepareStatement(sqlUp);
      ps.setBigDecimal(1, newSaldo);
      ps.setInt(2, numero);
      ps.execute();

      ps.close();
      conn.close();
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
  }
}
