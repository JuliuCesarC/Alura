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

Um dos primeiros arquivos que sera criado é um *controller*, onde iremos criar as rotas, e com ela podemos começar a interagir com a aplicação. Começaremos com o arquivo `MedicoController` que ficara na raiz do projeto no pacote `VollMedApi*01.controller`.

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

Durante o projeto sera criado alguns DTOs, e cada um deles deve ficar no pacote de seu domínio. Este tera o nome `DadosCadastroMedico` e sera criado no pacote `VollMedApi*01.medico`.

```java
public record DadosCadastroMedico(String nome, String email, String telefone, String crm, Especialidade especialidade, DadosEndereco endereco) {}
```

> *Especialidade* é uma classe **ENUM**, que representa as especialidades de um médico da clinica.

### DTO para o endereço

Assim como foi criado um DTO para os dados do cadastro de médico, vamos criar um para os dados do endereço, pois além de ser diversos campos, eles serão utilizados em outras classes, e, por esse motivo ele sera criado no pacote `VollMedApi*01.endereco`.

```java
public record DadosEndereco(String logradouro, String bairro, String cep, String cidade, String uf, String complemento, String numero) {}
```

Pronto, com isso já é possível imprimir no terminal as informações enviadas para o método `cadastrarMedico()`.

## Adicionando dependências para conexão com o banco de dados

Para criar uma conexão e posteriormente salvarmos informação no bando de dados, precisaremos de algumas novas bibliotecas, que podem ser procuradas no repositório Maven, ou ainda mais fácil utilizando a ferramenta **Spring Initializr** vista anteriormente. Primeiramente precisamos selecionar as opções de *projeto*, *linguagem* e *java* sendo respectivamente: **Maven**, **Java** e **17**.

Agora basta selecionar as dependências (ao segurar a tecla `CTRL` e clicar no item desejado, a lista de dependências não é fechada, facilitando a seleção de múltiplos itens). As quatro dependências são:

- **Spring Data JPA**

- **MySQL Driver**

- **Spring Validation**

- **Flyway Migration**

Então iremos clicar na opção `Explore`, que exibira a estrutura de arquivos do projeto, e também ja virá com o arquivo `pom.xml` selecionado. Logo basta descer até a tag *dependencies* e copiar as dependências selecionadas, colando elas no *pom.xml* do nosso projeto.

Para algumas IDEs é preciso ir até a seção do *Maven* e clicar para recarregar o projeto, assim baixando as novas dependências, mas no VS Code com o pacote Java Pack, isso ocorre automaticamente após salvas as alterações no arquivo *pom.xml*.

### Configurando a conexão com o banco de dados

Após instalar o *Spring Data JPA* a aplicação sempre tentara criar uma conexão com o banco de dados ao ser iniciada, o que ocorrera um erro pois ainda não configuramos essa conexão.

Para esta e diversas outras configurações, é utilizado o arquivo `application.properties`. Iremos configurar o *url*, o *username* e o *password*.

```properties
spring.datasource.url=jdbc:mysql://localhost/nome*database
spring.datasource.username=root
spring.datasource.password=*****
```

> O url é referente à url de conexão com o database do MySQL, seguido do usuário e a senha também do MySQL.

Lembrar de criar o database com o mesmo nome do informando na url no MySQL, caso contrario o programa sempre apresentara um erro durante a execução.

## Entidade JPA

Para salvar e posteriormente trazer informações do bando de dados, precisamos criar uma entidade que ira representar uma tabela no MySQL. Essa entidade é chamada de JPA (Java Persistence API).

O Spring Boot ja possui embutido um provedor de persistência de dados, bastando assim apenas adicionar algumas anotações em cima da classe que sera a entidade JPA.

As anotações que faremos na classe serão o `@Table` que indica qual tabela no banco de dados que esse JPA ira trabalhar, e a `@Entity` que indica que esta classe sera a responsável pela entidade JPA da tabela selecionada com o *Table*.

```java
@Table(name = "medicos")
@Entity(name = "Medico")
public class Medico {}
```

> É possível omitir o nome na anotação *Entity*, isso fara o Spring inferir que o nome da entidade é o mesmo nome da classe.

### Adicionando os campos

A classe JPA precisa ter os mesmos campos e com os mesmos nomes das colunas na tabela do MySQL. Focaremos apenas no 3 campos que precisam de anotação, que são o **id** que precisa da anotação `@Id` indicando que ele sera a chave primaria da tabela, além da anotação `@GeneratedValue` já que esse valor sera atribuído automaticamente, o campo **especialidade** que precisa da `@Enumerated` pois ele é uma classe ENUM, e por ultimo o **endereco** que precisa da anotação `@Embedded`.

Explicando um pouco melhor o *Embedded*, ele é utilizado para incorporar um objeto complexo dentro de uma entidade. Utilizamos eles para evitar criar uma nova tabela para as informações de endereço, pois podemos incorporar essas informações na entidade *Medico*. Com isso eles serão tratados como um único valor no banco de dados.

```java
@Id
@GeneratedValue(strategy = GenerationType.IDENTITY)
private Long id;

@Enumerated(EnumType.STRING)
private Especialidade especialidade;

@Embedded
private Endereco endereco;
```

### Criando a entidade Endereço

Para que a entidade *Medico* e outras próximas possam utilizar a classe endereço, sera necessario criar uma entidade para ela. A forma como vamos cria-la é semelhante a de *Medico*, mas possui algumas diferenças.

Em cima da classe, ao invés de ter as anotações de tabelas, teremos a anotação `@Embeddable`, que indica que essa classe sera incorporada em outras entidades.

```java
@Embeddable
public class Endereco {}
```

E os campos serão atribuídos da mesma forma de qualquer classe `private String logradouro;`.

## Diminuindo verbosidade com o Lombok

Uma das bibliotecas que foram adicionadas no projeto foi o Lombok, que cria métodos em tempo de execução apenas fazendo anotações em cima da classe.

Para que nossa primeira entidade JPA esteja completa, precisamos de alguns métodos sejam implementados. As anotações do Lombok que utilizaremos são o `@Getter` para adicionar os getters para cada campo, `@NoArgsConstructor` para adicionar o construtor padrão sem nenhum parâmetro que é obrigatório para uma classe JPA, `@AllArgsConstructor` para adicionar um construtor com todos os parâmeros da classe e `@EqualsAndHashCode` para adicionar os métodos equals e hashCode.

O \*EqualsAndHashCode é mais utilizado no campo identificador da tabela, pois ele é um campo único que não pode pode ter seu valor repetido com nenhum outro na tabela.

```java
@Table(name = "medicos")
@Entity(name = "Medico")
@Getter
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode(of = "id")
public class Medico {}
```

> Ao passar o parâmetro *of* para a anotação *EqualsAndHashCode*, informamos qual o único campo que deve receber os métodos equals e hashCode.

O mesmo vale para a classe endereço, precisamos fazer algumas anotações.

```java
@Embeddable
@Getter
@NoArgsConstructor
@AllArgsConstructor
public class Endereco {}
```

## Criando o repository

Normalmente para acessar o banco de dados utilizamos classes DAO (Data Access Object), e criamos métodos para efetuar o **CRUD** da aplicação. Porém com o Spring Boot temos um mecanismo que simplifica essa tarefa, que é a interface `JpaRepository`.

Para criar um repository da classe médico, iremos adicionar no pacote `VollMedApi*01.medico` a interface `MedicoRepository`. Devemos também estender da interface `JpaRepository`, informando qual o nome da entidade que sera mapeada no banco de dados, e o tipo do identificador da entidade.

```java
public interface MedicoRepository extends JpaRepository<Medico, Long>{}
```

## Salvando informações no banco de dados

Agora que temos o repository criado, vamos utiliza-lo na classe controller apenas adicionando uma propriedade do tipo `MedicoRepository`. Porém não sera nos a colocar as informações na propriedade, e sim o Spring. Com a anotação `@Autowired` o Spring faz a **injeção de dependência** automaticamente, pois ele conhece a classe *MedicoRepository* ja que ela estende de uma interface do próprio Spring.

```java
@Autowired
private MedicoRepository repository;
```

O JpaRepository ja possui grande parte dos métodos que são utilizados para o CRUD, com exceção apenas para métodos mais complexos ou específicos para o caso. Começaremos com o `save`, que como o nome sugere, ira salvas o dados no DB.

```java
@PostMapping
@Transactional
public void cadastrarMedico(@RequestBody DadosCadastroMedico dados) {
  repository.save(new Medico(dados));
}
```

Além disso, como esse é um método que vai alterar informações no banco de dados, precisamos de uma transação ativa durante a execução do métodos, para isso utilizamos a anotação `@Transactional`.

## Migrations com Flyway

Ao tentar cadastrar um médico recebemos um erro 500, por que não foi possível encontrar a tabela, isso se deve ao fato de que ainda não criamos as tabelas. E como boa pratica não é recomendado criar manualmente essas tabelas, e sim utilizar uma *migration*, pois com elas temos melhor controle sobre o banco de dados e um histórico de evolução do database.

**OBS**: Qualquer alteração no database deve ser feito através de uma **migration**. Sempre que for criar uma nova migration, parar a aplicação.

Um das bibliotecas adicionadas ao projeto foi o Flyway, que ja possui uma certa integração com o Spring Boot facilitando a tarefa. Voltando para a pasta `src/main/resources`, vamos adicionar o pacote `db/migration`, e dentro desta pasta iremos criar as migrations. O Flyway possui um padrão de nomenclatura para as migrations, que é `V1__nome-descritivo.sql`, e a cada novo item alteramos a versão (V1, V2), além de que é preciso saliente que são 2 underlines apos a versão.

A primeira migration tem o nome `V1__create-table-medicos.sql` e contem o código:

```sql
create table medicos(
  id bigint not null auto*increment,
  nome varchar(100) not null,
  email varchar(100) not null unique,
  crm varchar(6) not null unique,
  especialidade varchar(100) not null,
  logradouro varchar(100) not null,
  bairro varchar(100) not null,
  cep varchar(9) not null,
  complemento varchar(100),
  numero varchar(20),
  uf char(2) not null,
  cidade varchar(100) not null,

  primary key(id)
);
```

### Histórico e erros nas migrations

O Flyway cria no DB uma tabela chamada `flyway_schema_history`, que é um histórico que armazena algumas informações de cada migration executada. Uma delas a coluna `success`, que armazena 1 para uma migration executada corretamente e 0 caso não.

Digamos então que ao tentar executar a aplicação e ocorra algum erro na migration, por exemplo se o código sql estiver incorreto, a aplicação ira parar e será gravado no historio na coluna *success* o valor 0. Isso impedira que a aplicação seja iniciada até que o erro no database seja corrigido (caso exista) e a linha referente ao erro no historio do Flyway seja removida. Podemos utilizar o comando sql abaixo para remover o valor do histórico:

```sql
DELETE FROM flyway_schema_history WHERE success = 0;
```

## Validações com o Bean Validation

Até este ponto ja conseguimos cadastrar um médico salvando suas informações no DB, mas assim como qualquer formulário precisamos validar essas informações, e para isso utilizaremos a biblioteca Spring Validation que adicionamos no projeto anteriormente. Ela funciona adicionando anotações em cima da propriedade que desejamos efetuar a validação, e geralmente utilizamos na classe DTO.

A classe DTO que representa o cadastro de médicos é a `DadosCadastroMedico`, e é nela que iremos adicionar as anotações. Existem diversas opções de validação para um campo, e para saber os detalhes de cada um basta pesquisar a documentação. Mas veremos algumas das mais comuns e algumas especificas para o projeto.

- `@NotBlank` : a string não pode esta vazia ou conter apenas espaços

- `@NotNull` : o campo não pode ser nulo

- `@Email` : possui um padrão de email

- `@Pattern(regexp = "")` : define um padrão para o campo de acordo com um regex informado. Por exemplo o regex `"\\d{8}"` indica que o campo deve conter apenas números e um total de 8 dígitos.

- `@Valid` : valida os campos de outro DTO

- `@Future` : valida se a data informada esta no futuro

- `@Size(min = , max = )` : o campo precisa estar entre o mínimo e o máximo informado. Pode ser aplicado em *string*, *collection*, *map* e *array*.

Lembrando que existem parâmetros que podemos informar para cada anotações, como o `message` onde podemos informar uma mensagem caso o campo em questão não passe na validação.

Observação, para exibir a mensagem é preciso criar um classe para lidar com as exceções, sendo ela do tipo `MethodArgumentNotValidException`. Neste artigo temos um exemplo de como aplicar o processo [Link](https://www.baeldung.com/spring-boot-bean-validation).
