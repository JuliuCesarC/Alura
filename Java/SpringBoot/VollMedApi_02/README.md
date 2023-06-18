# Curso 2 projeto de api Voll Med

Esta formação busca ensinar desde a criação de um projeto com Spring Boot, passando por segurança, testes automatizados e por fim o build. A ideia é criar uma api para a empresa fictícia Voll Med, que é uma clinica que precisa de um sistema para gerenciar as consultas.

Para o curso 2 já começaremos com o projeto a partir do curso anterior, e também com a entidade *Paciente* pronta.

## Configurando os retornos da API

No curso anterior focamos principalmente em construir os métodos da api para que eles funcionassem como planejado, e no momento todos estão retornando nenhuma informação caso o método seja processado corretamente, apenas retorna o código http 200 (com exceção do método *listar* que obviamente retorna uma lista de medicos ou pacientes). Utilizaremos para manipular as resposta a classe do Spring **ResponseEntity**.

### Excluir médico

Começaremos com o método mais simples. Na declaração do método excluir iremos substituir o void pela classe ResponseEntity, e como retorno a resposta `noContent` código 204 que indica requisição processada com sucesso e nenhum conteúdo como resposta.

```java
public ResponseEntity excluirMedico(@PathVariable Long id) {
  var medico = repository.getReferenceById(id);
  medico.excluir();
  return ResponseEntity.noContent().build();
}
```

> O método noContent não constrói a resposta, por isso é necessario o `build`.

### Listar médico

No método de *listar* temos uma situação um pouco diferente, pois ele retorna um objeto do tipo `Page<DTO>`, mas como o ResponseEntity também pode receber um generic, basta envolver o *Page* com a classe `ResponseEntity<Page<DTO>>`.

```java
public ResponseEntity<Page<DadosListagemMedico>> listarMedico(
  @PageableDefault(size = 10, sort = { "nome" }) Pageable paginacao) {
  var page = repository.findAllByAtivoTrue(paginacao).map(DadosListagemMedico::new);
  return ResponseEntity.ok(page);
}
```

Resposta `ok()` código 200. Como parâmetro passamos o objeto *page* que contem a resposta da listagem.

### Atualizar médico

Para o método de atualizar é interessando retornar as informações do médico já com os dados atualizados. Como vamos retornar informações do médico, precisamos criar um DTO de detalhamento das informações do médico. Resposta `ok()` código 200, e como parâmetro passamos o DTO.

```java
public ResponseEntity atualizarMedico(@RequestBody @Valid DadosAtualizacaoMedico dados) {
  var medico = repository.getReferenceById(dados.id());
  medico.atualizarInformacoes(dados);
  return ResponseEntity.ok(new DadosDetalhamentoMedico(medico));
}
```

Criamos o DTO já com o construtor para receber como parâmetro a entidade de médico, com isso funcionando diretamente com os dados ou com a entidade.

```java
public record DadosDetalhamentoMedico(Long id, String nome, String email, String crm, String telefone,
    Especialidade especialidade, Endereco endereco) {
  public DadosDetalhamentoMedico(Medico medico) {
    this(medico.getId(), medico.getNome(), medico.getEmail(), medico.getCrm(), medico.getTelefone(),
        medico.getEspecialidade(), medico.getEndereco());
  }
}
```

### Cadastrar médico

O código correto para este método seria o http 201 (CREATED), que indica que um registro foi criado na api. Porem ele possui algumas regras a serem seguidas, sendo:

- Retornar o código 201

- Retornar no corpo da resposta os dados que acabaram de ser cadastrados

- Retornar o cabeçalho (header) *Location* com a URI

> Uma URI é uma url especifica para identificar um recurso recém cadastrado.

Este método é um pouco mais complexo que os demais, então vamos seguir os 3 itens acima. Para retornar o código 201 utilizaremos o `created()` passando como parâmetro a URI, e o segundo é a resposta com os dados onde utilizaremos o `body()` passando como parâmetro um DTO, vamos utilizar o mesmo DTO do método atualizar médico.

```java
public ResponseEntity cadastrarMedico(@RequestBody @Valid DadosCadastroMedico dados, UriComponentsBuilder uriBuilder) {
  var medico = new Medico(dados);
  repository.save(medico);
  var uri = uriBuilder.path("/medicos/{id}").buildAndExpand(medico.getId()).toUri();

  return ResponseEntity.created(uri).body(new DadosDetalhamentoMedico(medico));
}
```

Como tanto no DTO como na URI vai precisar da entidade *Medico*, separamos ela em uma variável.

#### URI builder

A URI como vista na lista de requisitos é o endereço para acessar o registro, e o Spring já possui uma classe para construir essa url, que é a `UriComponentsBuilder`. Essa classe é interessante por que sempre ira construir a URI com a url do servidor atual. Para utilizar essa classe é preciso fazer sua assinatura como parâmetro do método cadastrar, da forma como feita no trecho de código anterior.

O *uriBuilder* ira conter a url atual do servidor, porem é preciso fazer ele apontar para o endpoint de listar um médico detalhadamente. Este método ainda não foi adicionado no controller, mas iremos fazer isso em seguida. Para adicionar um caminho na url utilizaremos o `path()`, passando como parâmetro o caminho desejado. Esse caminho dever se para o controller atual `/medicos` e também para uma segunda rota onde é informado o id do médico assim como no método *excluir* `/medicos/idDoMedico`.

```java
var uri = uriBuilder.path("/medicos/{id}").buildAndExpand(medico.getId()).toUri();
```

Dentro de *path* além do caminho */medicos* , passamos um segundo caminho com um parâmetro dinâmico. Utilizamos um esse parâmetro por que o id do médico sempre sera diferente. Em seguida temos o método `buildAndExpand()` que ira inserir no parâmetro a informação passada para ele. Por fim temos o `toUri()` que como o nome sugere transforma o objeto em uma URI.

#### Método listar médico detalhado

Agora temos que criar o método para listar o médico detalhadamente. Ele precisar ter uma sub rota assim como o endpoint *excluir*, e mesmo que os 2 tenham a mesma rota o verbo dos 2 sera diferente. O DTO da resposta sera o mesmo do método *atualizar*.

```java
@GetMapping("/{id}")
public ResponseEntity detalharMedico(@PathVariable Long id) {
  var medico = repository.getReferenceById(id);
  return ResponseEntity.ok(new DadosDetalhamentoMedico(medico));
}
```

Como resposta temos o código 200 `ok()` e passamos o DTO como parâmetro.
