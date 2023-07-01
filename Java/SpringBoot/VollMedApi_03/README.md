# Curso 3 projeto de api Voll Med

Esta formação busca ensinar desde a criação de um projeto com Spring Boot, passando por segurança, testes automatizados e por fim o build. A ideia é criar uma api para a empresa fictícia Voll Med, que é uma clinica que precisa de um sistema para gerenciar as consultas.

É necessario os arquivos do curso anterior para continuidade deste curso.

## Adicionando consultas

A primeira funcionalidade que vamos implementar sera a de agendar consultas, sendo necessario criar o controller e o pacote `consultas` onde iremos adicionar a entidade, os DTOs, o repository, entre outros. Vamos começar adicionando o domínio para consultas, no pacote `domain` vamos adicionar mais uma pasta `consulta` e dentro dela criar 4 novos arquivos, sendo eles a entidade *Consulta*, o repository e mais 2 DTOs.

### Entidade Consulta

Na classe Consulta temos algumas diferenças até o momento, nela possuímos campos que farão relacionamentos com outras tabelas, sendo o tipo de relacionamento muito para um, ou seja uma consulta pode conter apenas um médico e um paciente. A anotações que utilizaremos sera a `@ManyToOne` que indica o tipo de relacionamento e a `@JoinColumn` que indica qual coluna estamos referenciando.

```java
@Table(name = "consultas")
@Entity(name = "Consulta")
@Getter
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode(of = "id")
public class Consulta {
  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  private Long id;

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "medico_id")
  private Medico medico;

  @ManyToOne(fetch = FetchType.LAZY)
  @JoinColumn(name = "paciente_id")
  private Paciente paciente;

  private LocalDateTime data;
}
```

Na anotação *ManyToOne* temos por padrão o fetch como `FetchType.EAGER` indicando que os dados relacionados devem ser carregados imediatamente quando a consulta é realizada. Porem é muito comum utilizar a opção que passamos, no caso a `FetchType.LAZY` que carrega os dados relacionados somente quando eles são acessados pela primeira vez. Já com a anotação *JoinColumn* passamos como parâmetro o `name` que especifica o nome da coluna no banco de dados, normalmente é utilizado um prefixo do nome da tabela junto com o `_id`.

### Consulta repository

O repository é basicamente o mesmo dos anteriores, e no momento esta vazio pois iremos adicionar os métodos de acordo com a demanda.

```java
public interface ConsultaRepository extends JpaRepository<Consulta, Long> {}
```

### DTOs de detalhamento e agendamento de consulta

Os 2 primeiros DTOs que vamos criar sera o `DadosDetalhamentoConsulta`:

```java
public record DadosDetalhamentoConsulta(Long id, Long idMedico, Long idPaciente, LocalDateTime data) {}
```

E o `DadosAgendamentoConsulta`:

```java
public record DadosAgendamentoConsulta(
    Long idMedico,

    @NotNull Long idPaciente,

    @NotNull 
    @Future 
    @JsonFormat(pattern = "dd/MM/yyyy HH:mm") 
    @JsonAlias({"dataConsulta", "data_consulta" }) 
    LocalDateTime data
  ){
}
```

Neste DTO temos a anotação `@Future` para indicar que a data selecionada precisa ser no futuro, além das anotações:

- **JsonFormat** : com o parâmetro *pattern* é possível mudar o padrão da data e hora que pode ser enviado no JSON, porem não altera como ele ira armazenar ou trabalhar com essa informação. O formato padrão é `2023-06-26T12:00` (é necessario utilizar o **T** para separar a data da hora).

- **JsonAlias** : cria apelidos pelo qual podemos chamar o campo no JSON. Por exemplo podemos tanto nomear o campo `data` como `dataConsulta`, `data_consulta` ou o nome original `data` no JSON que sera enviado no corpo da requisição.

### Migration para tabela consultas

No pacote `db.migration` vamos adicionar a migration `V7__create-table-consultas`.

```sql
create table consultas(
  id bigint not null auto_increment,
  medico_id bigint not null,
  paciente_id bigint not null,
  data datetime not null,
  
  primary key(id),
  constraint fk_consultas_medico_id foreign key(medico_id) references medicos(id),
  constraint fk_consultas_paciente_id foreign key(paciente_id) references pacientes(id)
);
```

## Consulta controller

Como ultimo passo para começar a implementar a funcionalidade de consulta, vamos criar o controller. No pacote `controller` vamos adicionar a classe `ConsultaController`, e dentro dela criar o método `agendarConsulta`.

```java
@RestController
@RequestMapping("consultas")
public class ConsultaController {

  @PostMapping
  @Transactional
  public ResponseEntity agendarConsulta(@RequestBody @Valid DadosAgendamentoConsulta dados) {
    System.out.println(dados);
    return ResponseEntity.ok(new DadosDetalhamentoConsulta(null, null, null, null));
  }
}
```

No momento o método apenas imprime no console os dados enviados e retorna um DTO vazio como resposta, porem ele é apenas um ponto de partida. Sera necessario diversos passos até conseguirmos que essa funcionalidade funcione minimamente bem.

Antes de qualquer coisa devemos primeiro fazer a validação das regras de negocio, e como boa pratica esses códigos não devem ficar na classe controller, ela é responsável apenas pelo fluxo de execução, para tal tarefa temos a classe Service.

## Classe de serviço para consultas

A classe de serviço serve para trabalharmos com as regras de negocio, algoritmos, cálculos, validações, ou seja tudo que é referente a como o processo deve ser executado. Exemplificando com o nosso projeto para a clinica, como o processo de agendamento de consulta deve acontecer? Quais os horários que serão possíveis de agendar? Caso o paciente não escolha um médico especifico, a aplicação que deve escolher um aleatório de mesma especialidade? As respostas para essas perguntas geralmente são colocadas na classe Service.

No pacote `domain.consulta` vamos adicionar a classe `AgendaDeConsultas`, e para que o Spring carregue ela vamos adicionar a anotação `@Service`. O primeiro método vai ter o nome `agendar` e deve receber o DTO de agendamento de consulta.

```java
@Service
public class AgendaDeConsultas {
  public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
  }
}
```

A construção deste método sera feita de trás para frente, ou seja, vamos começar pelo ultimo passo e ir adicionando as dependências de cada um conforme a necessidade deles. Pode parecer confuso a primero vista, mas realmente ajuda a começar um método que é bastante grade.

Qual sera o ultimo código que esse método deve executar? Provavelmente sera o de salvar a consulta no banco de dados. Vamos então criar esse código e também adicionar o repository de consulta.

```java
@Autowired
private ConsultaRepository consultaRepository;

public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
  consultaRepository.save(consulta);
}
```

Para salvar a consulta precisamos de um objeto `consulta`, logo vamos criar essa entidade:

```java
public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
  var consulta = new Consulta(null, medico, paciente, dados.data());
  consultaRepository.save(consulta);
}
```

Porem a classe *Consulta* recebe a entidade *Medico* e *Paciente*, precisamos buscar elas no banco de dados.

```java
@Autowired
private MedicoRepository medicoRepository;
@Autowired
private PacienteRepository pacienteRepository;

public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
  var medico = medicoRepository.getReferenceById(dados.idMedico());
  var paciente = pacienteRepository.getReferenceById(dados.idPaciente());
  var consulta = new Consulta(null, medico, paciente, dados.data());
  consultaRepository.save(consulta);
}
```

Utilizamos o `getReferenceById` ao invés do `findById` por que não é necessario carregar todas as informações da entidade, já que precisamos apenas criar uma relação entre tabelas a referencia da entidade é o suficiente.

Chegamos no código final que deve ser executado pelo método, ele deve criar uma consulta e salvar ela no banco de dados. Agora o proximo passo sera aplicarmos as validações e as regras de negocio.

### Exception personalizada

Antes de prosseguirmos vamos criar uma exception personalizada, pois utilizaremos ela diversas vezes. Dentro do pacote `domain` vamos adicionar a classe `ValidacaoException`, que ira apenas chamar o construtor da classe mãe passando a mensagem recebida como parâmetro.

```java
public class ValidacaoException extends RuntimeException {
  public ValidacaoException(String mensagem) {
    super(mensagem);
  }
}
```

### Validando a integridade das informações

As primeiras validações que vamos fazer é das informações enviadas pelo usuário, no caso o id do paciente e do médico. O repository do Spring ja possui um método para verificar se um id existe no banco de dados, que é o `existsById`. Porem a escolha do médico é opcional, ou seja o id pode ou não vir, mas caso venha é preciso validar.

```java
public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
  if (!pacienteRepository.existsById(dados.idPaciente())) {
    throw new ValidacaoException("Id do paciente não encontrado.");
  }
  if (dados.idMedico() != null && !medicoRepository.existsById(dados.idMedico())) {
    throw new ValidacaoException("Id do medico não encontrado.");
  }

  // código omitido
}
```

### Escolhendo um médico aleatório

Como mencionado anteriormente o id do médico é opcional, e caso não seja informado a aplicação deve escolher aleatoriamente um médico de mesma especialidade disponível na data. Vamos então adicionar um novo método dentro da classe *AgendaDeConsultas* chamado `escolherMedico` que deve receber o DTO de agendamento de consultas. No momento esse DTO não esta recebendo a especialidade, mas basta adicionar o campo com `Especialidade especialidade`.

Este método sera tanto para escolher um médico pelo id como para escolher um médico aleatório, então caso venha o id retornamos o médico, caso não, é preciso verificar se a especialidade veio na requisição. Por fim em caso dele passar pelas duas condições iremos chamar um método do repository para fazer a consulta.

```java
private Medico escolherMedico(DadosAgendamentoConsulta dados) {
  if (dados.idMedico() != null) {
    return medicoRepository.getReferenceById(dados.idMedico());
  }
  if (dados.especialidade() == null) {
    throw new ValidacaoException("Especialidade é obrigatória no caso do médico não ser escolhido.");
  }

  return medicoRepository.escolherMedicoAleatorioLivreNaData(dados.especialidade(), dados.data());
}
```

A funcionalidade de escolher um médico aleatório poderia ser feita dentro da classe, buscando as informações de consulta e verificando quais médicos estavam disponíveis naquele horário e que tinham a mesma especialidade. Porem a maneira mais eficiente de executar essa tarefa é diretamente com uma consulta personalizada no banco de dados.

A consulta `escolherMedicoAleatorioLivreNaData` não esta seguindo o padrão das *consultas derivadas* que devem ser feitas em ingles, pois ela é uma consulta muito especifica e complexa.

### Consulta personalizada para escolher médico

Para criar essa query personalizada vamos utilizar o **JPQL** (Java Persistence Query Language) que faz consultas no banco de dados usando as entidades JPA. Ela é uma linguagem de consulta orientada a objetos semelhante ao SQL, mas trabalha com entidades, atributos e relacionamentos em vez de tabelas e colunas.

Com o auxilio da anotação `@Query`, informamos ao Spring qual a consulta que vamos efetuar. Ela aceita tanto consultas no formato JPQL como também as nativas, bastando adicionar o parâmetro `nativeQuery` como TRUE. Abaixo temos exemplo com os 2 formatos:

- **JPQL**

```java
@Query("SELECT u FROM User u WHERE u.status = 1")
Collection<User> findAllActiveUsers();
```

- **SQL nativo**

```java
@Query(
  value = "SELECT * FROM USERS u WHERE u.status = 1", 
  nativeQuery = true)
Collection<User> findAllActiveUsersNative();
```

Agora vamos para a classe repository do médico onde iremos adicionar o método `escolherMedicoAleatorioLivreNaData` que deve receber a especialidade e a data. Em cima do método vamos adicionar a anotação `@Query` e informar a consulta.

```java
@Query("""
        select m from Medico m
          where m.ativo = true
          and m.especialidade = :especialidade
          and m.id not in(
              select c.medico.id from Consulta c
                where c.data = :data
          )
        order by rand()
        limit 1
    """)
Medico escolherMedicoAleatorioLivreNaData(Especialidade especialidade, LocalDateTime data);
```

> Utilizamos o *text block* **"""** para quebrar as linhas e melhorar a legibilidade do código.

No arquivo [JPQL_query](https://github.com/JuliuCesarC/Alura/blob/main/Java/SpringBoot/VollMedApi_03/JPQL_query.md) temos a explicação detalhada do método, para este documento vamos apenas dar uma olhada pelo funcionamento da query. Ela começa selecionando apenas médicos que estão ativos e tenham a mesma especialidade especificada no parâmetro `especialidade`, em seguida verificamos se o id do médico não esta em nenhuma outra consulta na mesma data, por fim ordena a lista de médicos de forma aleatória e seleciona o primeiro da lista.

### Validações

O proximo passo para o método `agendar` sera implementar as validações de regras de negocio, porem a forma como vamos executar essa tarefa é muito importante, devemos inserir todas as validações dentro do método? ou devemos criar uma classe com todas as validações e então chamar eles no método? Apesar de ambas serem uma opção, certamente não estão seguindo as boas praticas. A melhor solução seria criar **classes separadas para cada validação** o que torna o código pequeno, facilitando o teste, a manutenção, a aplicação e a legibilidade.

Se vamos criar classes separadas para cada validação, fica a duvida, sera necessário instanciar todas elas para então chamar o método de validar? Essa é outra vantagem de utilizar o Spring, dentro da classe `AgendaDeConsultas` podemos simplesmente declarar uma propriedade sendo uma lista de uma interface e anotarmos ela com o `@Autowired`, que o Spring ira inserir nessa lista todas as classes que estão implementando essa interface. Com isso basta varrer essa lista chamando o método de validar com cada classe, independente de quantas forem ou se vamos remover ou adicionar novas no futuro. Precisamos salientar que as classes que implementarem a interface precisam estar sendo carregadas pelo Spring e também devem ter o mesmo nome para o método principal.

Pode parecer um pouco confuso no começo, mais vamos começar por partes. Primeiramente vamos criar o pacote `consulta.validacoes` em seguida vamos adicionar a interface que todas as classes de validação para consulta iram implementar, que sera a `ValidadorAgendamentoDeConsulta`. Como explicamos anteriormente, eles devem ter o mesmo nome para o método principal ao qual escolhemos o `validar`.

```java
public interface ValidadorAgendamentoDeConsulta {

  void validar(DadosAgendamentoConsulta dados);

}
```

O proximo passo é adicionar as classes de validação, porem para esse documento vamos apresentar apenas uma classe para não tornar o arquivo muito extenso. Nas classes de validação existem algumas anotações para as partes que se destacam, em caso de duvida basta consultar cada classe.

A primeira validação que faremos sera a `ValidadorHorarioFuncionamentoClinica`, que precisa validar se a consulta esta sendo agendada entre os horários de 7:00 as 18:00 horas e de segunda a sábado. Como essa validação não é uma classe de serviço, de configuração ou outra semelhante, vamos fazer a anotação genérica de `@Component`. Além disso não podemos esquecer de implementar a interface criada anteriormente.

```java
@Component
public class ValidadorHorarioFuncionamentoClinica implements ValidadorAgendamentoDeConsulta {
  public void validar(DadosAgendamentoConsulta dados) {
    var dataConsulta = dados.data();

    var domingo = dataConsulta.getDayOfWeek().equals(DayOfWeek.SUNDAY);
    var antesDaAberturaDaClinica = dataConsulta.getHour() < 7;
    var depoisDoEncerramentoDaClinica = dataConsulta.getHour() > 18;
    if (domingo || antesDaAberturaDaClinica || depoisDoEncerramentoDaClinica) {
      throw new ValidacaoException("Consulta fora do horário de funcionamento da clínica");
    }
  }
}
```

Vamos explicar essa validação por partes, primeiro adicionarmos o método principal `validar` e logo em seguida separamos a data em uma variável. A primeira condicional é o dia domingo, que podemos selecionar com o método `getDayOfWeek()` e para tornar a variável um booliano encadeamos o `equals` que ira verificar se o dia informado é igual ao dia de domingo `DayOfWeek.SUNDAY`. As outras 2 condicionais do horário são muito simples de selecionar, bastando utilizar o método `getHour()` comparando com o horário setado pela clinica. Por fim verificamos se qualquer uma das condicionais é verdadeira, caso seja o método joga uma exceção que barra a aplicação.

### Aplicando as validações

Apos adicionar todas as classes de validação, vamos voltar para o arquivo `AgendaDeConsultas` onde iremos criar uma propriedade que ira armazenar a lista com todas as validações.

```java
@Autowired
private List<ValidadorAgendamentoDeConsulta> validadoresAgendar;
```

Precisamos destacar essa funcionalidade, pois ela facilita imensamente a aplicação de múltiplas validações. O funcionamento dela consiste em criar uma propriedade do tipo `List` com o generics sendo a interface que implementamos nas validações, e assinarmos ela com a anotação `@Autowired`. O Spring Automaticamente cria uma lista com todas as classes que estão implementando a interface e então injeta ela na propriedade.

Agora dentro do método `agendar` vamos varrer a propriedade chamando o método principal `validar`.

```java
validadoresAgendar.forEach(v -> v.validar(dados));
```

Com apenas uma linha adicionamos 6 validações até o momento, podendo ser expandida, alterada ou removida sem a necessidade de nenhuma modificação no método *agendar*.

### Retornando entidade Consulta

Para finalizar o método `agendar` basta retornar a entidade Consulta, com isso temos o código final:

```java
public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
  if (!pacienteRepository.existsById(dados.idPaciente())) {
    throw new ValidacaoException("Id do paciente não encontrado, ou paciente não cadastrado.");
  }
  if (dados.idMedico() != null && !medicoRepository.existsById(dados.idMedico())) {
    throw new ValidacaoException("Id do medico não encontrado.");
  }
  validadoresAgendar.forEach(v -> v.validar(dados));

  var medico = escolherMedico(dados);
  var paciente = pacienteRepository.getReferenceById(dados.idPaciente());
  if (medico == null) {
    throw new ValidacaoException("Não existe médico disponível neste horário");
  }
  var consulta = new Consulta(null, medico, paciente, dados.data());

  consultaRepository.save(consulta);
  return new DadosDetalhamentoConsulta(consulta);
}
```

## Adicionando as consultas

Vamos retornar para a classe controller `ConsultaController` onde vamos chamar o método `agendar`.

```java
@Autowired
private AgendaDeConsultas agenda;

@PostMapping
@Transactional
public ResponseEntity agendarConsulta(@RequestBody @Valid DadosAgendamentoConsulta dados) {
  var dto = agenda.agendar(dados);
  return ResponseEntity.ok(dto);
}
```

Primeiramente criamos a propriedade `agenda`, que vamos chamar dentro do método e salvar seu retorno na variável `dto`, que por fim retornamos no ResponseEntity.

## Tratando novo tipo de exceção

No estado atual a aplicação ja conseguimos adicionar uma consulta caso todos os dados estejam corretos, porem ao bater em uma validação, a reposta da aplicação é 403 e sem nenhuma mensagem, o que faz com que o usuário sequer saiba qual foi o problema. Para resolver isso vamos adicionar mais um tipo de exceção que a classe `TratadorDeErros` vai lidar.

```java
@ExceptionHandler(ValidacaoException.class)
public ResponseEntity tratarErroRegraDeNegocio(ValidacaoException ex) {
  return ResponseEntity.badRequest().body(ex.getMessage());
}
```

O tipo da exceção sera `ValidacaoException` e o código http de resposta sera o 400 BAD REQUEST, onde enviamos a mensagem de erro da validação.

## Documentação com SpringDoc

Neste momento temos a aplicação praticamente finalizada, com todas as rotas funcionando corretamente, porem para que o cliente consiga utilizar essa aplicação seria necessario criar uma documentação manualmente ou disponibilizar o código fonte para quem ira consumir a api, mas nenhuma das 2 alternativas são interessantes, pois não necessariamente o cliente tera conhecimento em java e Spring Boot, e ficar modificando a documentação sempre que houver uma alteração na api é muito trabalhoso. É nessa situação que podemos utilizar a biblioteca **SpringDoc**, que ira gerar uma documentação automaticamente da nossa api.

Essa biblioteca após instalada gera 2 rotas, uma delas para uma pagina html onde podemos acessar a documentação e até mesmo fazer alguns testes, e outra para um JSON contendo as informações da api. Nas configurações da nossa aplicação, bloqueamos todas as rotas com exceção da */login*, isso pode ser desejado ja que não queremos que todos tenham acesso as informações da api, porem para este projeto vamos deixar essas rotas abertas. No arquivo `SecurityConfigurations` vamos adicionar mais uma configuração.

```java
req
    .requestMatchers(HttpMethod.POST, "/login").permitAll()
    .requestMatchers("/v3/api-docs/**", "/swagger-ui.html", "/swagger-ui/**").permitAll()
    .anyRequest().authenticated();
```

As primeiras 2 url são para o arquivo JSON e para a pagina da documentação, e a terceira url é para alguns documentos que a pagina web precisa carregar, como css e configurações. Utilizamos o `/**` para indicar que qualquer subdiretório a partir dessa rota também estará incluso.

Podemos acessar as seguintes rotas:

- `/v3/api-docs` : retorna um json contendo as informações da api.

- `/swagger-ui/index.html` : acessa a pagina web com a documentação da api.

Dentro da pagina temos as rotas com seus parâmetros e o tipo de resposta esperado. Além disso podemos expandir alguma opção de rota e clicar no botão `Try it out` para abrir um bloco de texto onde iremos inserir os parâmetros necessários e então clicar em executar para testar a rota.

### Configurando pagina da documentação para token JWT

Apesar de ser possível testar as rotas pela pagina de documentação, todas elas são bloqueadas para uma requisição sem o token JWT, e por padrão não temos uma opção onde inserir esse token, sera necessario criar uma configuração para isso.

Na documentação do SpringDoc temos um tópico que explica como fazer essa configuração e disponibiliza o código que vamos ver abaixo. Para adicionar a segurança com token na documentação da api é necessario disponibilizar um método com o nome `customOpenAPI` para o SpringDoc. Vamos criar essa classe dentro do pacote `infra.springdoc` e com o nome `SpringDocConfigurations`.

```java
@Configuration
public class SpringDocConfigurations {
  @Bean
  public OpenAPI customOpenAPI() {
    return new OpenAPI()
        .components(new Components()
            .addSecuritySchemes("bearer-key",
                new SecurityScheme().type(SecurityScheme.Type.HTTP).scheme("bearer").bearerFormat("JWT")));
  }
}
```

Na linha do return é instanciado o objeto *OpenAPI* e em seguida é chamado o método que configura componentes, sendo esse componente o `addSecuritySchemes` onde ele recebe como parâmetro a chave `bearer-key` e um objeto `SecurityScheme` que indica que a configuração é para o protocolo HTTP, o esquema é `bearer` e o formato `JWT`.

Agora que criamos o arquivo de configuração, precisamos informar ao SpringDoc quais rotas vão utilizar o token para fazer a autenticação, e fazemos isso através da anotação `@SecurityRequirement` passando como parâmetro a chave que foi definida na configuração acima `bearer-key`. Essa anotação pode ser feita tanto nos métodos individualmente ou na classe inteira. Como todos os métodos com a exceção de *login* são bloqueados, vamos adicionar nas classes *MedicoController*, *PacienteController* e *ConsultaController* a anotação como feito abaixo.

```java
@RestController
@RequestMapping("medicos")
@SecurityRequirement(name = "bearer-key")
public class MedicoController {}
```

Após efetuar as configurações e atualizar a pagina da documentação veremos algumas mudanças, agora em cada opção de rota existe um ícone de cadeado, e na parte superior direita temo um novo botão chamado `Authorize`, ambos servem para adicionar o token JWT na requisição porem a opção do *authorize* envia o token em todas as rotas.

## Testes automatizados para a API

Os testes que efetuamos até o momento são testes manuais, feitos com o Insomnia, com o navegador ou até mesmo coma a documentação. Porém é muito importante criar **testes automatizados**, principalmente para as regras de negocio como por exemplo o controller de *Consulta*, e as classes de validação. Porém neste curso vamos focar nos testes das classes do Spring Boot, como o **controller** e o **repository**. Já as classes de validação podem ser facilmente testadas com testes unitários, utilizando por exemplo o JUnit ou Mockito, o que não veremos nesse curso.

A biblioteca padrão para escrever testes automatizadas é a **JUnit**, mas não é necessario adicionar ela pois quando criamos o projeto com o Spring Boot, ele trouxe como padrão a dependência `spring-boot-starter-test` que adiciona diversas bibliotecas, sendo algumas delas:

- **JUnit**: Uma das bibliotecas de teste mais populares em Java, usada para escrever testes de unidade.

- **Mockito**: Uma biblioteca de mocking em Java que permite criar objetos simulados (mocks) para testes. O Mockito ajuda a isolar partes específicas do código durante os testes, substituindo dependências externas.

- **AssertJ**: Uma biblioteca de asserção que oferece uma API fluente e expressiva para escrever asserções em testes. Ela facilita a verificação de resultados esperados em testes de unidade.

- **Hamcrest**: Outra biblioteca de asserção que fornece um conjunto de matchers para verificar condições em testes. Os matchers do Hamcrest oferecem uma sintaxe mais legível e expressiva para escrever asserções.

- **Spring Test**: Fornece suporte para escrever testes de unidade e integração usando o framework Spring. Ele oferece recursos como a execução de testes dentro do contexto do Spring, injeção de dependência automática e gerenciamento de transações.

- **Spring Boot Test**: Fornece anotações e recursos adicionais para escrever testes de unidade e integração no contexto do Spring Boot. Ele inclui anotações como @SpringBootTest, @WebMvcTest, @DataJpaTest, entre outras, que permitem configurar e executar testes em diferentes camadas do aplicativo.

### Importante

Ao utilizar o VS Code como IDE, é preciso verificar se a extenção [Test Runner for Java](https://marketplace.visualstudio.com/items?itemName=vscjava.vscode-java-test) esta instalada, pois é ela que permite trabalharmos com testes automatizados em java.

### Testando a classe repository

Para o primeiro teste vamos utilizar a classe *médicoRepository*, que possui três métodos. O primeiro é o `findAllByAtivoTrue`, que foi escrita no formato de *consulta derivada*, ou seja, o próprio Spring se encarrega de testar esse tipo de consulta, nesse caso especifico ele verifica se existe um campo `ativo` na tabela de médico e se ele é do tipo booliano. O terceiro método é o `findAtivoById`, que apesar de ser uma consulta personalizada, ela é muito simples para criar uma classe de teste para esse caso. O segundo método é o tipico caso que vale a pena criar um teste, é uma consulta personalizada de relativa complexidade e de suma importância para o funcionamento da aplicação, logo vamos criar um teste para o método `escolherMedicoAleatorioLivreNaData`.

Para criar a classe de teste temos algumas opções, podemos criar manualmente ou com algum atalho. No Intellij com o método selecionado podemos apertar o atalho `Alt` + `Insert` e escolher a opção *Test...*, ele ira abrir uma janela com algumas opções e basta clicar em *ok*. Já para o VS Code dentro da classe desejada podemos utilizar o atalho `Ctrl` + `Shift` + `P` e filtrar pela opção **Java: Go to Test**, com ela sera exibida uma sequencia de pop ups onde podemos escolher as opções desejadas, e apesar de não ser apenas clicar em ok como no Intellij, é super intuitivo:

1. Ao clicar em *Go to Test* ele obviamente não ira encontrar um arquivo de testes referente a essa classe, então exibe 2 opções, a primeira é a que vamos escolher `generate tests...`.

2. Em seguida sera exibido uma caixa de texto onde devemos informar o caminho do arquivo, mas como utilizamos esse atalho ja dentro da classe, ele automaticamente preenche esse campo com o caminho. No caso o caminho fica *med.voll.VollMedApi_03.domain.medico.MedicoRepositoryTest*

3. Agora sera exibido uma lista de checkbox contendo todos os métodos da classe, basta selecionar a desejada e clicar em OK. No caso vamos escolher a *"escolherMedicoAleatorioLivreNaData"*.

Ambas as IDEs criam o arquivo ja na pasta correta, que é a `src.test.java`, além de seguir os pacotes corretos da classe, que seria `domain.medico`. A estrutura de arquivo sera igual a que criamos, porem dentro da pasta *test*.

