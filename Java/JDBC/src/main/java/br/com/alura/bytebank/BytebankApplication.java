package br.com.alura.bytebank;

import br.com.alura.bytebank.domain.RegraDeNegocioException;
import br.com.alura.bytebank.domain.cliente.DadosCadastroCliente;
import br.com.alura.bytebank.domain.conta.ContaService;
import br.com.alura.bytebank.domain.conta.DadosAberturaConta;

import java.util.Scanner;

public class BytebankApplication {

  private static ContaService service = new ContaService();
  private static Scanner teclado = new Scanner(System.in).useDelimiter("\n");

  public static void main(String[] args) {
    var opcao = exibirMenu();
    while (opcao != 9) {
      try {
        switch (opcao) {
          case 1:
            listarContas();
            break;
          case 2:
            listarContasDesativadas();
            break;
          case 3:
            abrirConta();
            break;
          case 4:
            encerrarConta();
            break;
          case 5:
            consultarSaldo();
            break;
          case 6:
            realizarSaque();
            break;
          case 7:
            realizarDeposito();
            break;
          case 8:
            realizarTransferencia();
            break;
        }
      } catch (RegraDeNegocioException e) {
        System.out.println("Erro: " + e.getMessage());
        System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu");
        teclado.next();
      }
      opcao = exibirMenu();
    }
    System.out.println("Finalizando a aplicação.");
  }

  private static int exibirMenu() {
    System.out.println("""
        BYTEBANK - ESCOLHA UMA OPÇÃO:
        1 - Listar contas abertas
        2 - Listar contas desativadas
        3 - Abertura de conta
        4 - Encerramento de conta
        5 - Consultar saldo de uma conta
        6 - Realizar saque em uma conta
        7 - Realizar depósito em uma conta
        8 - Realizar transferência
        9 - Sair
        """);
    return Integer.valueOf(teclado.nextLine());
  }

  private static void listarContas() {
    System.out.println("Contas cadastradas:");
    var contas = service.listarContasAbertas();
    contas.stream().forEach(System.out::println);

    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.nextLine();
  }

  private static void listarContasDesativadas() {
    System.out.println("Contas desativadas:");
    var contas = service.listarContasDesativas();
    contas.stream().forEach(System.out::println);

    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.nextLine();
  }

  private static void abrirConta() {
    System.out.println("Digite o número da conta:");
    var numeroDaConta = teclado.nextInt();

    System.out.println("Digite o nome do cliente:");
    var nome = teclado.next();

    System.out.println("Digite o cpf do cliente:");
    var cpf = teclado.next();

    System.out.println("Digite o email do cliente:");
    var email = teclado.next();

    service.abrir(new DadosAberturaConta(numeroDaConta, new DadosCadastroCliente(nome, cpf, email)));

    System.out.println("Conta aberta com sucesso!");
    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.nextLine();
  }

  private static void encerrarConta() {
    System.out.println("Digite o número da conta:");
    var numeroDaConta = teclado.nextInt();

    service.encerrarLogico(numeroDaConta);

    System.out.println("Conta encerrada com sucesso!");
    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.next();
  }

  private static void consultarSaldo() {
    System.out.println("Digite o número da conta:");
    var numeroDaConta = teclado.nextInt();
    var saldo = service.consultarSaldo(numeroDaConta);
    System.out.println("Saldo da conta: R$" + saldo.setScale(2));

    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.next();
  }

  private static void realizarSaque() {
    System.out.println("Digite o número da conta:");
    var numeroDaConta = teclado.nextInt();

    System.out.println("Digite o valor do saque:");
    var valor = teclado.nextBigDecimal();

    service.realizarSaque(numeroDaConta, valor);
    System.out.println("Saque realizado com sucesso!");
    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.next();
  }

  private static void realizarDeposito() {
    System.out.println("Digite o número da conta:");
    var numeroDaConta = teclado.nextInt();

    System.out.println("Digite o valor do depósito:");
    var valor = teclado.nextBigDecimal();

    service.realizarDeposito(numeroDaConta, valor);

    System.out.println("Depósito realizado com sucesso!");
    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.next();
  }

  private static void realizarTransferencia() {
    System.out.println("Digite o número da conta origem:");
    var contaOrigem = teclado.nextInt();
    System.out.println("Digite o número da conta destino:");
    var contaDestino = teclado.nextInt();
    System.out.println("Digite o valor a ser transferido:");
    var valor = teclado.nextBigDecimal();

    service.realizarTransferencia(contaOrigem, contaDestino, valor);

    System.out.println("Transferência realizada com sucesso!");
    System.out.println("Pressione qualquer tecla e de ENTER para voltar ao menu principal");
    teclado.next();
  }
}
