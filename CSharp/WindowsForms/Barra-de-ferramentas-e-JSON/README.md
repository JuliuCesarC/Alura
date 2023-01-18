# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

- Aula 1: Barra de ferramentas.

O componente que adiciona uma barra de ferramente é o **ToolStrip**. No canto superior direito do elemento tem uma opção que mostra as principais propriedades do componente, e com isso utiliza a opção *Inserir itens Padrão*. Com isso diversos itens que são comumente utilizados em editor de texto iram aparecer, dentre eles iremos utilizar apenas o *Novo documento*, *Abrir documente existente* e *Salvar*.

Quando paramos com o mouse em cima de uma opção, geralmente uma dica do funcionamento deste item é exibido, e essa dica tem o nome de *ToolTip*. Os botões possuem diversas propriedades e uma delas permite alterar esse texto, que é a *ToolTipText*. Também é possível alterar esse texto dinamicamente com o comando:

```C#
tls_principal.Items[0].ToolTipText = "Incluir cliente";
```

> O *"[0]"* seleciona o botão que iremos trabalhar.

- Aula 2: Formulário.

Criamos uma classe dentro do arquivo *LibraryWF* que sera responsável pelos campos do formulário. Dentro dela criamos outras 2 classes, a primeira é referente a unidade, ou seja um cliente em especifico, ja a segunda é referente a lista dessas unidades, todos os cliente cadastrados.

Na classe referente a unidade criamos uma propriedade para cada campo no formulário. Exemplo:

```C#
public string ID { get; set; }
```

Na classe referente a lista, criamos uma lista e tipamos ela para receber apenas a unidade acima.

```C#
public List<Unit> listUnit { get; set; }
```

> *Unit* é o nome da classe da unidade.

- Aula 3: DataAnnotations e Validação.

O Windows Forms possui uma biblioteca que podemos utilizar para validação dos campos do formulário, que é a **ComponentModel.DataAnnotations**. Porem não é uma biblioteca que ja vem ativa no projeto, precisamos ativa-la indo em *Dependências* e clicando na opção *Adicionar referência*, isso ira abrir uma janela onde iremos procurar na opção *Assemblies>Framework* a biblioteca *referência*.

Com essa biblioteca podemos por exemplo definir que uma propriedade é obrigatória, forçando o usuário a colocar um valor para prosseguir. Para fazer isso temos que adicionar a classe *Required* acima da propriedade. Exemplo abaixo:

```C#
[Required(ErrorMessage = "Código do cliente obrigatório")]
public string ID { get; set; }
```

> A classe *Required* precisa estar entre os colchetes *[ ]*.

Podemos definir a mensagem de erro que ira aparecer caso a logica não seja satisfeita.

A biblioteca não valida se o campo foi preenchido, ela valida se a propriedade da classe esta vazia. Isso ira funcionar corretamente pois iremos atrelar o campo do formulário a propriedade da classe.

Porem somente os comandos acima não são suficiente, é preciso formar um erro caso a validação retorne *false*. Abaixo temos um conjunto de códigos responsáveis por capturar todas as exceções e jogar o erro.

```C#
ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
List<ValidationResult> results = new List<ValidationResult>();

bool isValid = Validator.TryValidateObject(this, context, results, true);

if( isValid == false )
{
  StringBuilder sbrErrors = new StringBuilder();
  foreach( var validationResult in results )
  {
    sbrErrors.AppendLine(validationResult.ErrorMessage);
  }
  throw new ValidationException(sbrErrors.ToString());
}
```

O `ValidationContext` e o `List<ValidationResult>` são responsáveis por capturar das diretivas o resultado dos testes.

O `TryValidateObject` valida os testes, e caso alguns dos testes tenha uma exceção, ira retornar false.

A variável `StringBuilder` sera utilizada para construir o texto que sera exibido na mensagem de erro. É possível utilizar apenas a *string*, porem com o *StringBuilder* temos o método *AppendLine* que permite colocar cada mensagem em uma linha separada.

Como existe a possibilidade de haver diversos erros de uma vez, implementamos um `foreach` para varrer a variável **results** e montar o texto com todos os erros utilizando o **AppendLine**.

Por fim, forçamos o erro com o `throw` e a exceção **ValidationException**. Lembrando que essa exceção sera utilizada no Formulário *Frm_RegisterClient_UC* como veremos a seguir.
