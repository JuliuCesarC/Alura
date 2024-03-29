﻿using System;

class Program
{
  static void Main ( string[] args )
  {
    Console.WriteLine("Criando variareis");
    int idade = 24;
    //O 'int' cria variáveis apenas com números inteiros, e consegue guardar números até 32bits de tamanho.
    double peso = 70.4;
    // Já o 'double' cria uma variável que pode receber números quebrados, suporta até 12 números apos o ponto.
    float numeroQuebrado = 54.268465f;
    // O tipo 'float' possui menor precisão do que o 'double', porem ocupa menos espaço na memoria, suporta até 6 números apos o ponto. É preciso utilizar o sufixo 'f' ao final da atribuição no numero.
    long bigNumber= 1000000000000000000;
    // Para resolver o problema de tamanho do 'int', podemos utilizar o 'long', que suporta até 64bits de tamanho.
    short smallNumber = 10000;
    // Ao contrario do 'long' o 'small' serve para variáveis menores, com apenas 16bits.
    
    idade = 24 + 10;
    idade = idade - 2 * 5;

    double splitNumber = 15 / 8;
    // Um problema acontece quando atribuímos uma divisão de 2 valores inteiros para uma variável do tipo 'double', ela identifica o resultado como um valor inteiro também. Para resolver isso podemos adicionar um ponto após algum numero, como vemos abaixo:
    splitNumber = 15 / 8.0;

    int numeroInteiro = (int)numeroQuebrado;
    // Podemos atribuir um numero quebrado a um inteiro utilizando o '(int)', dessa forma a parte quebrada não sera atribuída a variável. caracteres

    double num1 = 3.0;
    int num2 = 5;

    num1 = num2 * num1;

    Console.WriteLine("Minha idade é: " + idade);
    Console.WriteLine("Meu peso é: " + peso);
    Console.WriteLine("Valor do número dividido: " + splitNumber);
    Console.WriteLine("divisão resultando em quebrado: " + num1 / 7);
    // Imprimir diretamente o resultado de uma divisão de uma variável double que resulte em um numero quebrado, sera mostrado todo o valor quebrado, mesmo que o divisor não possua um numero apos o ponto.

    Console.WriteLine("Pressione qualquer tecla para sair...");
    Console.ReadLine();
  }
}