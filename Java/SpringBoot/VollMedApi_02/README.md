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

## Estrutura de pacotes da aplicação

Antes de seguirmos para a proxima tarefa, vamos alterar os pacotes da api. As pastas *medico*, *paciente* e *endereco* são do domínio da aplicação, logo eles pertenceram ao pacote `domain`. Além desse, adicionaremos o pacote `infra`, que será responsável pela infraestrutura do projeto, como segurança, exceções, entre outros. Com isso o projeto fica com o seguintes 3 pacotes na pasta raiz do projeto, `controller`, `domain` e `infra`.

## Tratando possíveis erros na API

O Spring por padrão ja envia algumas informações para o usuário caso ocorra algum erro, porem ela trata qualquer problema como uma *exception* e devolve o código de erro 500. Porem o ideal é devolver o código mais especifico para o tipo de erro. Outra informação que o Spring também envia é o *stack trace* do erro, e além de não ser muito legível ela contem diversas informações da api, o que pode até se configurar como uma brecha de segurança. Podemos desabilitar a configuração do stack trace no arquivo `application.properties`.

```properties
server.error.include-stacktrace=never
```

Para saber mais sobre as configurações que podemos utilizar no *properties*, basta consultar a documentação [Common Application Properties](https://docs.spring.io/spring-boot/docs/current/reference/html/application-properties.html).

### Classe responsável pelas exceções

Uma opção para tratar o erro seria criar um try catch no método desejado e enviar a resposta adequada, porem isso cria uma problema onde sera necessario adicionar o bloco de código em todos os métodos, e além disso podemos ter outros controllers com o mesmo tipo de erro. Para resolver isso criaremos uma classe responsável por capturar e tratar cada tipo de exceção e enviar a resposta correta para o usuário.

Dentro do pacote *infra* vamos criar o arquivo `TratadorDeErros`, e para indicar ao Spring que essa é uma classe para tratar erros vamos colocar a anotação `@RestControllerAdvice` na classe. Agora basta adicionar o método referente a cada tipo de exceção.

### Erro 404

Vamos tratar primeiro o método detalhar médico, que caso seja enviado um id que não existe, o código de erro correto seria o 404 (não encontrado). Na classe *TratadorDeErros* vamos adicionar o método `tratarErro404` e acima do método a anotação `@ExceptionHandler`, que indica que este é um método que ira tratar um tipo de exceção. O erro que vamos tratar sera a da classe `EntityNotFoundException`, então vamos passar ela como parâmetro para a anotação.

```java
@ExceptionHandler(EntityNotFoundException.class)
public ResponseEntity tratarErro404() {
  return ResponseEntity.notFound().build();
}
```

Assim como os métodos do controller vamos retornar a classe ResponseEntity com o `notFound` que ira criar o erro 404 NOT FOUND.

### Erro 400

Quando o usuário tenta efetuar uma requisição enviando dados inválidos e ocasionando um erro de validação, o código que devera ser devolvido é o 400 BAD REQUEST, por exemplo no método `cadastrarMedico`. Como estamos utilizando o Bean Validation para fazer as validações, o Spring se integra com ele e caso ocorra alguma exceção, ele ja enviar o erro 400, porem além do código ele retorna diversas informações que não seriam necessárias. Vamos tratar essa exceção para enviar apenas os campos que tiveram problema com suas respectivas mensagens.

Dentro da classe tratador de erros vamos adicionar mais um método chamado `tratarErro400`. O tipo de exceção que ele ira capturar sera o `MethodArgumentNotValidException`, e como vamos precisar capturar as mensagens de erro, iremos assinar esse tipo como parâmetro do método em questão.

```java
@ExceptionHandler(MethodArgumentNotValidException.class)
public ResponseEntity tratarErro400(MethodArgumentNotValidException ex) {}
```

Caso agora seja colocado apenas o retorno com o ResponseEntity com o devido método, o usuário ira receber apenas o código sem nenhuma resposta no corpo. E como citado anteriormente, precisaremos capturar as mensagem de erro, o que pode ser feito através da função `getFieldErrors()` da propriedade *ex*.

```java
var erros = ex.getFieldErrors();
```

Agora dentro dessa variável temos o mesmo json que o Spring enviava como resposta para o erro 400, e como queremos apenas alguma campos, vamos utilizar um DTO para converter esse objeto.

```java
return ResponseEntity.badRequest().body(erros.stream().map(DadosErroValidacao::new).toList());
```

O `badRequest` é o responsável pelo código 400, e apos ele chamamos o *body* para enviar informações no corpo da requisição. Então utilizamos o ja conhecido `stream` para lidar com a lista da variável *erros* e o `map` para executar uma função em cada item da lista, chamamos o construtor do DTO com o `::new`, dessa forma convertendo a lista para o padrão do DTO. Lembrando que é preciso utilizar o `toList` para converter o objeto em uma lista.

Esse DTO sera utilizado exclusivamente nessa classe, então vamos criar ele dentro dela mesmo.

```java
private record DadosErroValidacao(String campo, String mensagem) {
  public DadosErroValidacao(FieldError erro) {
    this(erro.getField(), erro.getDefaultMessage());
  }
}
```

O DTO precisa conter apenas o campo e sua mensagem. O construtor sera chamado la no `stream` e passado como parâmetro um objeto do tipo `FieldError`. Esse objeto contem os métodos `getField` e `getDefaultMessage`, que utilizamos para chamar o construtor padrão.

Pronto, agora o método cadastrar médico retorna uma resposta padronizada contendo apenas os campos e os erros.
