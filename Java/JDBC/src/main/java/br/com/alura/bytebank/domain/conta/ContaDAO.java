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

public class ContaDAO{
  private Connection conn;

  public ContaDAO(Connection connection) {
    this.conn = connection;
  }
  public void salvar(DadosAberturaConta dadosDaConta) {
    var cliente = new Cliente(dadosDaConta.dadosCliente());
    var conta = new Conta(dadosDaConta.numero(), cliente);
    
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
  public Set<Conta> listar(){
    Set<Conta> contas = new HashSet<>();
    
    String sql = "SELECT * FROM conta";
    try {
      PreparedStatement ps = this.conn.prepareStatement(sql);
      ResultSet resultSet = ps.executeQuery();

      while (resultSet.next()) {
        Integer numero = resultSet.getInt("numero");
        BigDecimal saldo = resultSet.getBigDecimal(2);
        String nome = resultSet.getString("cliente_nome");
        String cpf = resultSet.getString(4);
        String email = resultSet.getString(5);

        DadosCadastroCliente dadosCadastroCliente = 
          new DadosCadastroCliente(nome,cpf,email);
        Cliente cliente = new Cliente(dadosCadastroCliente);
        
        contas.add(new Conta(numero, cliente));
      }
      
      ps.close();
      resultSet.close();
      conn.close();      
    } catch (SQLException e) {
      throw new RuntimeException(e);
    }
    return contas;
  }
}
