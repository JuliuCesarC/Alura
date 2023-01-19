# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

## **Aula 1**: Barra de ferramentas

O componente que adiciona uma barra de ferramente é o **ToolStrip**. No canto superior direito do elemento tem uma opção que mostra as principais propriedades do componente, e com isso utiliza a opção *Inserir itens Padrão*. Com isso diversos itens que são comumente utilizados em editor de texto iram aparecer, dentre eles iremos utilizar apenas o *Novo documento*, *Abrir documente existente* e *Salvar*.

Quando paramos com o mouse em cima de uma opção, geralmente uma dica do funcionamento deste item é exibido, e essa dica tem o nome de *ToolTip*. Os botões possuem diversas propriedades e uma delas permite alterar esse texto, que é a *ToolTipText*. Também é possível alterar esse texto dinamicamente com o comando:

```C#
tls_principal.Items[0].ToolTipText = "Incluir cliente";
```

> O *"[0]"* seleciona o botão que iremos trabalhar.

## **Aula 2**: Classe do Formulário

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

## **Aula 3**: DataAnnotations e Validação

O Windows Forms possui uma biblioteca que podemos utilizar para validação dos campos do formulário, que é a **ComponentModel.DataAnnotations**. Porem esta não é uma biblioteca que ja vem ativa no projeto, precisamos ativa-la na biblioteca que criamos *LibraryWF*, indo em *Referências* > *Adicionar referência* > *Assemblies* > *Framework* e procurando por *ComponentModel.DataAnnotations*.

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

## **Aula 4**: Trabalhando com as exceções

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

## **Aula 5**: Implementando a função na barra de ferramenta

Agora que ja criamos uma classe com as propriedades referente aos campos do formulário, e também validações para esses campos, podemos adicionar a primeira funcionalidade para a barra de ferramentas, que é o item de adicionar um novo usuário. Abaixo temos o código:

```C#
try
{
  Client.Unit C = new Client.Unit();
  C = FormDataToClass();
  C.CheckClass();
  MessageBox.Show("Usuário adicionado com sucesso", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
catch (ValidationException Ex)
{
  MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

> O método `FormDataToClass();` é um método que atribui os valores digitados no campo do formulário nas propriedades da classe *Client*. Sera tratado desse método posteriormente. O método `CheckClass();` foi o que criamos na **Aula 4**.

Para que seja exibido as mensagens de erro, utilizaremos o *Try/Catch*. Dentro do *try* criamos primeiramente uma instancia da unidade da classe *Client* e então atribuímos o retorno do método *FormDataToClass* nela. Apos isso verificamos se não houve nenhuma exceção com o método *CheckClass*.

Caso ocorra alguma erro, o **catch** ira capturar uma exceção do tipo *ValidationException*, e sera exibido todas as mensagens de erro que aconteceram. Essas mensagens são as definidas na validação das propriedade da classe *Client*.

### Método FormDataToClass

___

Como a função de atribuir os valores dos campos do formulário nas propriedades da classe *Client* podem ser utilizado diversas vezes, é interessante criar um método com essas funcionalidades. Por isso criamos o método *FormDataToClass*.

A maioria dos campos possuem a atribuição bem simples, porem alguns deles tem certas peculiaridades.

```C#
Client.Unit C = new Client.Unit();
  C.ID = txt_clientID.Text;
  C.Name = txt_clientName.Text;
```

Primeiramente criamos uma instancia da classe *Client*, o que nos permite acessar as propriedades refentes aos campos. Por exemplo, `C.ID` é a propriedade da classe, e `txt_clientID` é o campo do formulário.

O campo do *Nome do pai* possui uma diferença, ele pode ou não estar ativo, para isso precisamos criar uma verificação.

```C#
if (chk_fathersName.Checked)
{
  C.FathersName = txt_fathersName.Text;
  C.HaveFather = true;
}
else
{
  C.HaveFather = false;
}
```

> O *chk_fathersName* é o nome do elemento *CheckBox*. O *C.HaveFather* é a propriedade booliana referente ao *Nome do pai* ser ou não ser informado.

No formulário temos um componente **CheckBox**, a validação sera feita com ele utilizando o *chk_fathersName.Checked*.

O campo do *Gênero* também é muito semelhante e foio método *Checked* para verificar qual opção foi selecionada.

Para o campo do *Estado* temos algumas diferenças. Temos o código abaixo:

```C#
if (cmb_state.SelectedIndex < 0)
{
  C.State = "";
}
else
{
  C.State = cmb_state.Items[cmb_state.SelectedIndex].ToString();
}
```

Primeiro verificamos se o usuário selecionou alguma opção do **ComboBox**, caso não tenha selecionado, atribuímos a propriedade *State* um valor vazio, dessa forma gerando um erro. Caso tenha selecionado, atribuímos o valor do campo utilizando o *Items* e o *SelectedIndex* à propriedade.

No campo de *Renda familiar* utilizaremos uma classe do **VisualBasic** para auxiliar a tarefa.

```C#
if (Information.IsNumeric(txt_familyIncome.Text))
{
  double income = Convert.ToDouble(txt_familyIncome.Text);
  if (income < 0)
  {
    C.familyIncome = 0;
  }
  else
  {
    C.familyIncome = income;
  }
}
```

> Para utilizar o *Information* precisamos adicionar a referencia **VisualBasic** na biblioteca *LibraryWF*.

A classe *Information* possui diversos métodos como *IsDate*, *IsArray*, *IsError*, entre outros, mas para este projeto iremos utilizar o *IsNumeric* que como o nome sugere verifica se o conteúdo digitado no campo é um numero valido.

Em seguida converte o texto para *double* e verifica se esse valor é menor que 0, caso seja então atribuímos 0 a propriedade, caso não atribuímos o valor do campo na propriedade.

Ainda nessa aula validamos algumas informações que não dizem respeito ao formulário, mas sim ao conteúdo digitado. Na classe *Client* temos o método `CheckComplement` onde adicionamos essas validações.

## **Aula 6**: JSON

Uma funcionalidade que iremos implementar no formulário é que na hora que o usuário digitar um CEP, os outros campos de endereço sejam preenchidos automaticamente. Para isso utilizaremos uma *API* chamada **viacep**. Através da URL iremos informar o CEP digitado e ela ira retornar um **JSON** com as informações da rua, Bairro, estado, entre outros.

Levando em consideração que um JSON pode ser transformado em uma classe, e uma classe em um JSON, temos uma ideia de como iremos capturar esses dados e inseri-los no formulário.

O primeiro passo é criar uma requisição para esta *API* e transformar os dados recebidos em algo que possa ser interpretado pelo programa no processo que veremos depois, que é a **Desserialização**.

```C#
HttpWebRequest requisicao = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + CEP + "/json/");
// A 'HttpWebRequest' serve para criar uma requisição HTTP.
HttpWebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
// E a 'HttpWebResponse' serve para obter a resposta.

int cont;
byte[] buffer = new byte[1000];
// Criamos uma variável 'buffer' para armazenar os dados.
StringBuilder sb = new StringBuilder();
// O 'StringBuilder' sera utilizado para acumular a resposta e gerar um texto.
string temp;
// 'O temp' sera utilizado para armazenar temporariamente os dados durante o loop.
Stream stream = resposta.GetResponseStream();
// Com o 'Stream' obtemos o fluxo de dados da resposta HTTP.
do
{
  cont = stream.Read(buffer, 0, buffer.Length);
  temp = Encoding.UTF8.GetString(buffer, 0, cont).Trim();
  sb.Append(temp);
} while (cont > 0);
return sb.ToString();
```

Um resumo do funcionamento do loop. O primeiro comando é o `stream.Read`, que serve para ler o fluxo de dados e armazenar uma parte dele no *buffer*, além disso o retorno dele informa a quantidade de bytes lidos, que será atribuídos à variável *cont*. Usando o `Encoding.Default`, armazenamos na variável *temp* a conversão da resposta para *string*. No terceiro comando juntamos os dados na variável *sb*.

Por fim retornamos os dados de *sb* no formato *string*. Lembrando que este código esta dentro do método *GeraJSONCEP* na classe *Cls_Utils*.

O segundo passo é criar um classe que sera a responsável por **Desserializar**  o JSON e atribuir os valores nas propriedades. Dentro da biblioteca *LibraryWF* criamos a classe CEP, e dentro dela criamos outra classe *Unit* e um método *DesSerializedClassUnit*.

A classe *Unit* é responsável pelas propriedades que receberam os valores da *API*, lembrando que os nomes das propriedades tem que ser o mesmo nome que vem no *JSON*.

```C#
public class Unit
{
  public string cep { get; set; }
  public string logradouro { get; set; }
  // ...
}
```

Ja para o método, precisamos instalar a o pacote NuGet chamado **Newtonsoft.Json**, que atualmente é o mais baixado. Para instalar esse pacote, seguiremos os passos *Ferramentas* > *Gerenciado de Pacotes do NuGet* > *Gerenciar pacotes do NuGet para a solução* > *Procurar*, provavelmente a primeira opção sera o pacote desejado.

```C#
public static Unit DesSerializedClassUnit(string vJson)
{
  return JsonConvert.DeserializeObject<Unit>(vJson);
}
```

> O tipo que ele precisa retornar é a classe *Unit*, por isso tipamos ele com o *\<Unit\>*

### Adicionando os dados no formulário automaticamente

___

Para adicionar as informações no formulário, precisamos de um gatilho para isso, e o mais recomendado para esse exemplo é o evento *Leave*, que quando o usuário sai do campo de texto ele é ativado. Abaixo temos o código adicionado no evento.

```C#
string vCEP = txt_CEP.Text.Trim();
if (vCEP != "")
// Primeiro verificamos se ele não esta vazio.
{
  if (vCEP.Length == 8)
  // Então verificamos se possui 8 digitos.
  {
    if (Information.IsNumeric(vCEP))
    // Então utilizamos a classe 'Information' do VisualBasic para validar se o texto é numérico.
    {
      var vJSON = Cls_Utils.GeraJSONCEP(vCEP);

      CEP.Unit Cep = new CEP.Unit();
      Cep = CEP.DesSerializedClassUnit(vJSON);

      txt_streetAddress.Text = Cep.logradouro;
      txt_district.Text = Cep.bairro;
      txt_city.Text = Cep.localidade;

      // 
      // ComboBox
      // 
    }
  }
}
```

Apos o encadeamento de *Ifs* temos os comandos, o primeiro é o que vimos no começo da aula, que foi o método que gera um texto a partir da busca na *API*.

Logo então criamos uma instancia da classe *Unit* e executamos o método *DesSerializedClassUnit*, com isso teremos todas as informações recebidas pela *API* em propriedades separadas na classe *Unit*. Basta agora atribuir essas valores nos campos desejados como vimos em `txt_district.Text = Cep.bairro;`.

Porem para o componente **ComboBox** é um pouco diferente. O nome do estado que vem da *API* esta no formato de siglas *SP*, e as opções dentro do ComboBox são o nome com a sigla *São Paulo (SP)*. Com isso podemos buscar dentre esses itens o que possui a sigla do estado selecionado. Vejamos o código abaixo.

```C#
for (int i = 0; i < cmb_state.Items.Count - 1; i++)
{
  var vPos = Strings.InStr(cmb_state.Items[i].ToString(), "(" + Cep.uf + ")");
  if (vPos > 0)
  {
    cmb_state.SelectedIndex = i;
  }
}
```

Primeiramente criamos um loop para varrer todas as opções do ComboBox, e em cada item devemos procurar se a sigla do estado existe dentro do texto do item. Para fazer essa busca utilizamos o método **InStr** da classe *Strings*.

O método *InStr* possui como primeiro parâmetro o ponto inicial da string que ele deve começar a busca, o segundo parâmetro é em que string devemos buscar `Items[i]`, e o terceiro parâmetro é o que devemos buscar `"(" + Cep.uf + ")"`.

> Ao omitir o primeiro parâmetro no método *InStr*, o programa assume que a busca deve começar no primeiro caractere.

Para selecionar o item quando encontrado, utilizamos o **SelectedIndex**.
