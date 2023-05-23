package br.com.alura.bytebank;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConnectionDBFactory {
  public Connection getConnection() {
    try {
      String url = "jdbc:mysql://localhost:3306/byte_bank?user=Cesar&password="
        + Password.getPassword();
      return DriverManager
        .getConnection(url);
    } catch (SQLException err) {
      throw new RuntimeException(err);
    }
  }
}
