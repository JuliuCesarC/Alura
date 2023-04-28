package com.cesar.aula03.model;

import com.cesar.aula03.filters.Classifiable;

public class Movie extends Title implements Classifiable {
  private String director;

  public Movie(String name) {
    super(name);
  }

  public String getDirector() {
    return director;
  }

  public void setDirector(String director) {
    this.director = director;
  }

  @Override
  public int getClassification() {
    return (int) average() / 2;
  }
}