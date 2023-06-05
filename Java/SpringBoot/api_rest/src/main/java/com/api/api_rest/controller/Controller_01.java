package com.api.api_rest.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/home")
public class Controller_01 {
  
  @GetMapping
  public String helloWorld(){
    return "Hello World from Spring";
  }
}