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


