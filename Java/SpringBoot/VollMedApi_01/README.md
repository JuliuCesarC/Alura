# Aula 1 projeto de api Voll Med

Esta formação busca ensinar desde a criação de um projeto com Spring Boot, passando por segurança, testes automatizados e por fim o build. A ideia é criar uma api para a empresa fictícia Voll Med, que é uma clinica que precisa de um sistema para gerenciar as consultas.

Como este é um curso que pode ser consumido por pessoas com pouco ou nenhum conhecimento em Spring Boot, iremos seguir uma linha logica para facilitar a compreensão do funcionamento de uma api que utiliza esta tecnologia. Isso significa que não necessariamente seguiremos o caminho mais performático.

Este documento ira seguir um passo a passo do mais básico, como a criação do projeto, para o mais avançado, que é o build do projeto. Porém não sera apresentado todos os códigos, pois basta consultar os arquivos para tal, além de que algumas observações também estarão comentadas nesses arquivos.

## Spring Initializr

O Spring Initializr é uma ferramenta que auxilia na criação um projeto com Spring. Podemos escolher diversas opções de projetos, e para este em especifico temos as opções:

|                  |        Opção         |
| :--------------- | :------------------: |
| **Project**      |        Maven         |
| **Language**     |         java         |
| **Spring Boot**  |        3.1.0         |
| **packaging**    |         Jar          |
| **Java**         |          17          |
| **Dependencies** | Spring Boot DevTools |
|                  |        Lombok        |
|                  |      Spring Web      |

Mais dependências serão necessárias, mas por agora começaremos com apenas estas 3. Apos isso basta clicar em **Generate** para baixar o projeto.

O projeto vem com uma estrutura de pastas simples e com alguns arquivos criados. Um desses arquivos é o que termina com o nome `nomeApplication.java`, que sera responsável por iniciar a aplicação.

## Estrutura de pastas

Existes diversas formas e boas praticas para criar a estrutura de pastas de um projeto, e não sera diferente neste projeto, seguiremos algumas convenções para estruturar os arquivos. Na pasta `src/main/java` seguiremos o seguinte padrão:

- **controller** : responsável por mapear as rotas da api, e chamar os métodos para cada função.

- **domain** : responsável pelo domínio, como o Médico, Pacientem Consulta, entre outros.

> Dentro do pacote *domain.medico* por exemplo, teremos a entidade Medico, os DTOs, e alguns outros arquivos referentes ao domínio da entidade médico.

- **infra** : responsável pela infraestrutura da api, como a parte de segurança, a parte de tratamento de exceções e outras configurações.

Voltando agora para a pasta `src/main/resources`, temos o seguinte estrutura:

- **db.migration** : responsável pos armazenas as *migrations*.

> Migration são os comando sql que faram as alterações no banco de dados, como criar novas tabelas, altera colunas, adicionar colunas, ou seja, tudo que precise alterar o banco de dados sera feito através de uma migration.

- **resources** : dentro da própria pas resources temos os aquivos `application.properties`, que armazenam algumas configurações para a api.

## Primeiro paço

Um dos primeiros arquivos que sera criado é um *controller*, onde iremos criar as rotas, e com ela podemos começar a interagir com a aplicação. Começaremos com o arquivo `MedicoController` que ficara na raiz do projeto no pacote `VollMedApi_01.controller`.

### Carregando a classe

Para que o spring carregue a classe, é necessario fazer a anotação `@RestController` acima da classe, e além disso, informaremos qual o caminho da url, que é `@RequestMapping("medicos")`. Ou seja sempre que recebemos uma requisição para o caminho `"/medicos"`, ele cairá nesse controller.

```java
@RestController
@RequestMapping("medicos")
public class MedicoController {}
```

### Adicionando o primeiro método

Iremos criar o método `cadastrarMedico`, e precisamos fazer a anotação para indicar qual verbo que chamará esse método, que no caso é o POST e a anotação fica `@PostMapping`. Além disso, iremos receber as informações para castrar o médico através do corpo da requisição, então antes de declarar o parâmetro, adicionamos a anotação `@RequestBody`.

```java
@PostMapping
public void cadastrarMedico(@RequestBody String dados) {
  System.out.println(dados);
}
```

### Criando um DTO

Por padrão é utilizado o formato **JSON** para transferência de informações em requisições http, porem não é interessante trabalhar com o json "cru", criando funções para procurar os campos e os valores no meio da string. O Spring Boot ja disponibiliza um serializador de json, e com a nova classe **Record**, podemos criar um **DTO** (Data Transfer Object) que representará os campos e os valores que serão enviados e devolvidos nas requisições.

Durante o projeto sera criado alguns DTOs, e cada um deles deve ficar no pacote de seu domínio. Este tera o nome `DadosCadastroMedico` e sera criado no pacote `VollMedApi_01.medico`.

```java
public record DadosCadastroMedico(String nome, String email, String telefone, String crm, Especialidade especialidade, DadosEndereco endereco) {}
```

> *Especialidade* é uma classe **ENUM**, que representa as especialidades de um médico da clinica.

### DTO para o endereço
