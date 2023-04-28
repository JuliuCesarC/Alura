package com.cesar.aula03.model;

public class Title {
  private String name;
  private int releaseDate;
  private boolean premiumPlan;
  private int duration;
  private double rating;
  private int totalRating;

  public Title(String name){
    setName(name);
  }
  
  public String getName() {
    return name;
  }

  public void setName(String name) {
    this.name = name;
  }
  public int getReleaseDate() {
    return releaseDate;
  }

  public boolean isPremiumPlan() {
    return premiumPlan;
  }

  public int getDuration() {
    return duration;
  }

  public int getTotalRating(){
    return totalRating;
  }


  public void setReleaseDate(int releaseDate) {
    this.releaseDate = releaseDate;
  }

  public void setPremiumPlan(boolean premiumPlan) {
    this.premiumPlan = premiumPlan;
  }

  public void setDuration(int duration) {
    this.duration = duration;
  }

  public void showInfo(){
    System.out.println("Nome do filme: "+name);
    System.out.println("Ano de lançamento: "+releaseDate);
  }
  public void rate(double grade){
    rating += grade;
    totalRating ++;
  }
  public double average(){
    return rating / totalRating;
  }
}
