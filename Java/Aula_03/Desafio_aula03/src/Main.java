import com.cesar.aula03.account.CreditCard;

import java.util.Scanner;

public class Main {
  public static Scanner input = new Scanner(System.in);
  public static void main(String[] args) {
    CreditCard card = new CreditCard();

    System.out.println("Digite o limite do cartão: ");
    card.setCardLimit(input.nextDouble());
    
    int shopping = 1;
    while (shopping == 1){
      String item;
      double value;
      input.nextLine();
      System.out.println("Insira o nome do item: ");
      item = input.nextLine();
      System.out.println("Digite o valor do item: ");
      value = input.nextDouble();
    
    card.buy(item, value);

    System.out.println("Deseja comprar mais algum item? 1:sim ; 0:não.");
    shopping = input.nextInt();
    }

    System.out.println(card.getSortedPurchases());
  }
}