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

Com essa biblioteca podemos por exemplo definir que uma propriedade é obrigatória, o tamanho mínimo ou máximo, filtrar o conteúdo com uma expressão regular, entre outros. Abaixo temos alguns exemplos.

```C#
[Required(ErrorMessage = "CEP do cliente obrigatório.")]
[RegularExpression("([0-9]+)", ErrorMessage = "CEP do cliente deve conter apenas números.")]
[StringLength(8, MinimumLength = 8, ErrorMessage = "CEP do cliente deve conter 8 dígitos.")]
public string CEP { get; set; }
```

> As classes de validação precisam estar entre os colchetes *[ ]*.

O `[Required]` torna obrigatório que a propriedade possua um valor.

O `[RegularExpression]` valida o conteúdo de acordo com o filtro *regex* utilizado. Por exemplo o *"([0-9]+)"* verifica se o texto possui apenas números.

O `[StringLength]` define o tamanho que a string deve ter. Por exemplo *"(8, MinimumLength = 8, ...)"* define o valor máximo de caracteres em 8, e o *MinimumLength* define o mínimo em 8, com isso o texto deve conter especificamente 8 caracteres.

Além desses também temos o `[Range]` que só pode ser utilizado em propriedades numéricas.

```C#
[Range(0, double.MaxValue, ErrorMessage = "...")]
```

O primeiro parâmetro é o valor mínimo, e o segundo o valor máximo, que no caso acima é o valor máximo do *double*.

É indicado sempre ao final da classe de validação, definir uma mensagem de erro que ira aparecer no caso da logica não ser satisfeita.

A biblioteca não valida se o campo do formulário foi preenchido, ela valida se a propriedade da classe esta vazia. Isso ira funcionar corretamente pois iremos atrelar o campo do formulário a propriedade da classe.

- Aula 4: Trabalhando com as exceções.

Para que as validações implementadas na aula anterior funcionem corretamente, é preciso capturar todas as exceções e exibi-las na tela, para que o usuário corrija o erro. Abaixo temos um trecho do código responsável por essa tarefa:

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
