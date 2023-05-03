package com.cesar.aula04.principal;

import com.cesar.aula04.model.Title;
import com.google.gson.Gson;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.Scanner;

public class Principal {
  public static void main(String[] args) throws IOException, InterruptedException {
    Scanner input = new Scanner(System.in);
    System.out.println("Digite o nome do filme: ");
    var search = input.nextLine();
    
    String url = "http://www.omdbapi.com/?t="+search+"&apikey=8348a285";

    HttpClient client = HttpClient.newHttpClient();
    HttpRequest request = HttpRequest.newBuilder()
      .uri(URI.create(url))
      .build();
    HttpResponse<String> response = client
      .send(request, HttpResponse.BodyHandlers.ofString());
    
    String json = response.body();
    System.out.println(json);

    Gson gson = new Gson();
    Title searchedMovie = gson.fromJson(json, Title.class);
    System.out.println(searchedMovie);
  }
}