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

## Segurança com Spring Security

O Spring possui um modulo especifico para tratar de segurança, que é o **Spring Security**. Esse pacote tem 3 grandes objetivos, que são:

- **Autenticação** : disponibiliza uma gama de opções customizáveis para autenticar o usuário, como por exemplo se vai ser feito através de um formulário, token (como o JWT), baseado em terceiros (como OAuth), algum protocolo, etc. Ele possui uma boa flexibilidade em como vamos gerenciar esse processo de autenticação.

- **Autorização** : disponibiliza configurações para como lidar com permissões e acessos concedidos a um usuário autenticado. Podemos configurar com base em permissão especificas, como por exemplo bloquear perfis com permissão *A* de acessar métodos de permissão *B*. Podemos também ter controle de acesso através de URL, baseado em método e baseado em anotação.

- **Proteção contra ataques** : disponibiliza alguns recursos para proteger a aplicação de uma variedade de ataques comuns, sendo alguns deles o Cross-Site Scripting (XSS), clickjacking, Cross-Site Request Forgery (CSRF), Injeção de SQL, entre outros. Ele utiliza alguns mecanismos de defesa, como a validação e sanitização de entrada, prevenção de CSRF por meio de tokens, tratamento adequado de erros de segurança e configurações de segurança personalizadas.

No caso desse projeto o que vamos fazer é o controle de acesso e autenticação, pois até o momento ele poderia ser acessado por qualquer um que soubesse da url (caso a api estivesse hospedada em um servidor). E devemos nos atentar ao fato de que esse controle de acesso deve levar em consideração que uma api é **Stateless**, ou seja, ela não guarda estado, não existe uma seção aberta, o que difere de uma aplicação web que é **Stateful**, onde precisa guardar as informações do usuário logado.

A solução que vamos utilizar sera a de tokens com o **JWT**. Mas o que é um token? Abaixo temos um exemplo:

```java
var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
```

Um token nada mais é que uma string que contem algumas informações que passaram por um algoritmo de encriptação, e utilizamos o mesmo algoritmo também para validar o token.

Agora veremos como sera o funcionamento da api com o JWT:

1. Usuário envia as informações para o login : dentro a api teremos uma rota para o login, onde a aplicação ira consultar no banco de dados se o usuário realmente esta cadastrado.

2. Api retorna o token : caso os dados sejam validados então a aplicação cria e retorna um token do JWT.

3. Novas requisições devem enviar o token : agora o front end que ira consumir a api deve enviar no cabeçalho da requisição o token JWT para validar da operação.

4. Api executa o método : caso o token seja valido, a aplicação executa o método em questão.

### Adicionando o pacote Security

Primeiramente precisamos adicionar a nova dependência, e podemos utilizar o mesmo método do curso anterior onde utilizamos a ferramenta *Spring Initializr* para copiar as dependências e colar elas no arquivo `pom.xml`. Esse pacote adicionar 2 novas dependências, a *starter-security* e a *security-test*.

A partir deste momento todos os métodos da aplicação foram bloqueados, sendo apenas possível executar um método ao efetuar o login. Caso esteja utilizando uma ferramente como o **Insomnia** ou **Postman**, sera exibido apenas um erro de acesso negado, mas ao tentar executar através da web, sera aberto uma janela de login do próprio Spring Security, onde geralmente o usuário padrão é `user` e a senha é uma que ele imprime no console sempre que a api é iniciada.

## \ AVISO /

A partir deste momento serão necessários diversos passos até chegarmos no resultado mínimo esperado, com esse meio tempo sendo muito dificultado o teste da api ou das funcionalidades implementadas. Mas basta aplicar todos os passos que o projeto funcionara. Iremos seguir uma sequencia de quais tarefas serão feitas primeiro, porem diversas funcionalidades podem ser executadas antes ou depois.
