package com.cesar.aula03.account;

import java.util.*;

public class CreditCard {
  private double cardLimit;
  private Map<String, Double> purchases = new HashMap<>();

  public double getCardLimit() {
    return cardLimit;
  }

  public void setCardLimit(double value) {
    this.cardLimit = value;
  }

  public Map getPurchases() {
    return purchases;
  }
  public Map getSortedPurchases() {
    List<Map.Entry<String, Double>> listSorting = new ArrayList<>(purchases.entrySet());

    Collections.sort(listSorting, Comparator.comparingDouble(Map.Entry::getValue));

    Map<String, Double> sortedMap = new LinkedHashMap<>();
    for (Map.Entry<String, Double> item : listSorting) {
      sortedMap.put(item.getKey(), item.getValue());
    }
    
    return sortedMap;
  }
  
  public boolean buy(String purchase, double value) {
    if(value > cardLimit){
      return false;
    } else {
      purchases.put(purchase, value);
      cardLimit -= value;
    return true;
    }
  }
}
