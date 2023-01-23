# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

## **Aula 1**: Implementando funcionalidades na Barra de Ferramenta

No curso anterior adicionamos os itens da Barra de Ferramentas, mas a funções que cada um deveria executar não. Nesta aula iremos adicionar a funcionalidade do item *Limpar formulário*, que sera o mais simples, e também do item *Incluir novo cliente*.

Começando com o primeiro, para limpar o formulário é muito simples, basta criar um método que torna a propriedade *Text* como vazio, com algumas especificidades em 3 campos, o **ComboBox**, o **CheckBox** e o **RadioButton**.

```C#
txt_clientID.Text = "";
txt_district.Text = "";
// ...
cmb_state.SelectedIndex = -1;
chk_fathersName.Checked = true;
rdb_male.Checked = true;
```

Para o **ComboBox** selecionamos o item *"-1"* com a propriedade *SelectedIndex*, com isso ele ira ficar vazio. Para o **CheckBox** e o **RadioButton** utilizamos a propriedade *Checked*.

### Adicionando o cliente

Para este projeto, foi escolhido guardar os cliente no formato **JSON**, em uma pasta no próprio computador. A classe *Binder* criada na biblioteca *LibraryWF* ficara responsável por salvar o cliente. Além disso adicionamos um método para fazer a **Serialização** dentro da classe *Client*.

Dentro do código fonte do formulário, no evento do item *Incluir novo cliente* foi implementado diversos códigos que veremos mais a frente.

Começaremos com a classe *Binder*. As propriedades adicionadas foram a `directory` responsável por armazenas o caminho do diretório escolhido, a `message` responsável pela mensagem de erro ou de sucesso e a `status` responsável por armazenar o estado caso ocorra um erro ou caso tenha executado tudo normalmente.

Para trabalhar com arquivos, comumente utilizaremos a biblioteca **IO**, e neste projeto não é diferente. Para utilizar essa biblioteca basta adicionar o namespace `using System.IO;` no começo do arquivo da classe.

No método construtor adicionamos os comando abaixo.

```C#
status = true;
try
{
  if (!Directory.Exists(DirectoryFolder))
  {
    Directory.CreateDirectory(DirectoryFolder);
  }
  directory = DirectoryFolder;
  message = "Conexão criada com sucesso.";
}
catch (Exception Ex)
{
  status = false;
  message = "Não foi possível efetuar a conexão: " + Ex.Message;
}
```

> A classe *Directory* pertence a biblioteca *IO*. O *DirectoryFolder* é o diretório que recebemos através do método construtor.

Começamos com um *TryCatch* pois trabalhando com arquivos sempre pode ocorrer alguns erros, e logo em seguida utilizamos o método **Exists** da classe *Directory* para validar se o diretório informado existe. Caso esse diretório não exista, criaremos ele através do *CreateDirectory*, e logo em seguida adicionamos o caminho do diretório na propriedade *directory*.

___

Dentro da classe adicionamos um método que sera o responsável por adicionar o cliente.

```C#
public void AddClient(string id, string jsonUnit)
{
  status = true;
  try
  {
    if (File.Exists(directory + "\\" + id + ".json"))
    // Verifica se ja existe um cliente com esse 'id'.
    {
      status = false;
      message = "Não é possível incluir pois o ID ja esta sendo usado. ID: " + id;
    }
    else
    {
      File.WriteAllText(directory + "\\" + id + ".json", jsonUnit);
      status = true;
      message = "Cliente adicionado com sucesso.";
    }
  }
  catch (Exception Ex)
  {
    status = false;
    message = "Não foi possível efetuar a conexão: " + Ex.Message;
  }
}
```

> Colocando o *status* como false quando ocorre algum erro, mais frente no código fonte do formulário poderemos utiliza-lo para fazer alguma validação antes de prosseguir.

Para adicionar o cliente precisamos do *ID*, pois o nome do arquivo sera o próprio *ID*, e da classe *Serializada* para *JSON*. Com essas duas informações e mais o *directory* que ja esta salvo na propriedade da classe, podemos utilizar o método **WriteAllText** para adicionar o arquivo no diretório.

___

Na classe *Client* adicionamos o comando para *Serializar* um JSON.

```C#
public static string SerializedClassUnit(Unit unit)
{
  return JsonConvert.SerializeObject(unit);
}
```

Existe bastante semelhança entre o método de *Desserializar*, a diferença se da ao fato de que ele recebe uma classe *Unit* e retorna uma *string*.

## **Aula 2**: Finalizando a funcionalidade do primeiro item da barra de ferramentas

Dentro do código fonte do formulário temos o evento do item *Incluir novo cliente*, que mudou bastante, mas ainda continua com alguns comandos do curso anterior. Vejamos abaixo o código.

```C#
try
{
  Client.Unit C = new Client.Unit();
  C = FormDataToClass();
  C.CheckClass();
  C.CheckComplement();

  string clientJson = Client.SerializedClassUnit(C);
  Binder F = new Binder("C:\\Users\\Cesar\\Desktop\\Curso_Dev\\Alura\\CSharp\\WindowsForms\\Manipulando-dados-do-cliente\\Banco-de-dados");

  // ...
}
```

A primeira parte do comando é praticamente a mesma, transferimos os dados do formulário para a classe *Client*, executamos as 2 validações como anteriormente. Os novos comando são o método estático *SerializedClassUnit*, que ira transformar a classe em um JSON, e posteriormente sera usado no método **AddClient** que vimos na aula anterior, além de criarmos uma instancia da classe *Binder* informando o diretório onde pretendemos guardar os clientes.

```C#
try
{
  // ...

  if (F.status)
  // Testa se não houve nenhum erro ao criar a instancia da classe 'Binder'.
  {
    F.AddClient(C.ID, clientJson);

    if (F.status)
    // Verifica se não houve nenhum erro ao adicionar o cliente.
    {
      MessageBox.Show("OK: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else
    {
      MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
  else
  {
    MessageBox.Show("ERRO: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
}
// ...
```

A segunda parte é responsável por adicionar o cliente e verificar possíveis erros que podem ocorrer nesse processo. Cada um desses processos retornando uma mensagem através do *F.message*, com ele podemos mostrar ao usuário aonde ocorreu o erro.

```C#
// ...
catch (ValidationException Ex)
{
  MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
catch (Exception Ex)
{
  MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

Por fim a ultima parte onde fica o *catch*, adicionamos um novo *catch* que ficara responsável pelos erros do tipo *Exception*, pois o do tipo *ValidationException* serve apenas pera as validações do formulário.

## **Aula 3**: Seleciona cliente cadastrado

Todas as funcionalidades implementadas são muito semelhante em sua implementação, sendo a maior diferença o comando principal da classe **File**. Para ver todos os comandos de validação e de verificação das funções, entrar no arquivo **Frm_RegisterClient_UC**.

Dentro do arquivo *Binder* adicionamos a função que ira buscar o cliente no diretório e retorna-lo para ser adicionado suas informações no formulário. Os único comando que o diferencia do *Incluir novo cliente* é o abaixo.

```C#
string content = File.ReadAllText(directory + "\\" + id + ".json");
```

___

Dentro do código fonte do formulário adicionamos as funções do item *Seleciona cliente cadastrado*. O código que realmente faz o trabalho esta abaixo.

```C#
string clientJSON = F.Search(txt_clientID.Text);

Client.Unit C = new Client.Unit();
C = Client.DesSerializedClassUnit(clientJSON);
writeOnForm(C);
```

> O método *Search* é o que adicionamos na classe *Binder*.

Primeiramente buscamos o cliente com o método *Search*, e então criamos uma instancia de *Client* e transformamos os dados do cliente do formato JSON para uma classe com o *DesSerializedClassUnit*, apos isso utilizamos o método *writeOnForm* para escrever os dados no formulário.

___

O método *writeOnForm* abaixo possui os mesmos comando de quando passamos os dados do formulário para a classe, porem agora é ao contrario.

```C#
txt_clientID.Text = C.ID;
txt_clientName.Text = C.Name;
// ...
```

Para selecionar o estado no **ComboBox** utilizamos um loop *for*. O código é praticamente o mesmo de quando utilizamos o CEP para fazer uma requisição à uma API, e precisamos escolher o estado de acordo com o retorno.

## **Aula 4**: Adicionando as funções de *Alterar* e *Deletar*

Não fugindo a regra dos itens anteriores, adicionamos os métodos na classe *Binder*, sendo eles *Save* e o *Delete*. A unica diferença é o método da classe *File*. Para o item *Delete* temos abaixo.

```C#
File.Delete(directory + "\\" + id + ".json");
```

___

Para o item *Save* temos uma junção de *Incluir novo cliente* e de excluir.

```C#
File.Delete(directory + "\\" + id + ".json");
File.WriteAllText(directory + "\\" + id + ".json", jsonUnit);
```

> O *jsonUnit* é a classe já *Serializada* que recebemos como parâmetro.

___

Para o *Delete* no código fonte do formulário, adicionamos algumas novas funcionalidades.

```C#
Binder F = new Binder(directory);
if (F.status)
{
  string clientJson = F.Search(txt_clientID.Text);
  Client.Unit C = new Client.Unit();
  C = Client.DesSerializedClassUnit(clientJson);
  writeOnForm(C);

  Frm_Question Db = new Frm_Question("Deseja excluir cliente?", "Frm_Question");
  Db.ShowDialog();

  if (Db.DialogResult == DialogResult.Yes)
  {
    F.Delete(txt_clientID.Text);
    if (F.status)
    {
      MessageBox.Show("OK: " + F.message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
      ClearForm();
    }
    // ...
  }
}
```

Assim como o *Seleciona cliente cadastrado*, utilizamos o método *writeOnForm* para escrever no formulário os dados do cliente que sera excluído, dando assim maior garantia para o usuário que é aquele o cliente escolhido.

Trouxemos do Curso 2 o formulário **Frm_Question** para abrir uma *DialogBox* perguntado se o cliente tem certeza que deseja excluir o cliente.

Caso o usuário concorde, então excluimos o cliente com o *F.Delete* e verificamos se o método executou normalmente com o *F.status*. Por fim utilizamos o *ClearForm* para limpar os dados do formulário.

Para o *Save*, os comando são os mesmos que o de *Incluir novo cliente*, a principal diferença é o comando `F.Save(C.ID, clientJson);`.

## **Aula 5**: Adicionando uma DialogBox para selecionar o cliente

O método utilizado até agora para selecionar um cliente, ou deletar um cliente, foi utilizando o *Código do cliente* que o usuário digitou no formulário. Porem existem maneiras muito mais praticas para buscar por um arquivo, e um desses é criando um formulário para utilizar com o **DialogBox**.

Criamos o formulário *Frm_Search*, que sera o responsável por exibir os itens no **ListBox** e selecionar o cliente. Mas para funcionar corretamente precisamos adicionar alguns métodos que iram ler todos os arquivos dentro do diretório e depois envia-los para o formulário.

Dentro da classe *Binder* criamos o método que ira buscar por todos os itens do diretório.

```C#
public List<string> SearchAll()
{
  status = true;
  List<string> List = new List<string>();
  try
  {
    var files = Directory.GetFiles(directory, "*.json");
    for (int i = 0; i < files.Length - 1; i++)
    {
      string content = File.ReadAllText(files[i]);
      List.Add(content);
    }
    return List;
  }
  catch (Exception Ex)
  {
    status = false;
    message = "Não foi possível encontrar o cliente: " + Ex.Message;
  }
  return List;
}
```

> O *List\<string\>* na declaração do método, indica que sera retornado uma lista de strings.

O método **GetFiles** é o responsável por selecionar os arquivos, o primeiro parâmetro é o diretório que sera feita a busca, e o segundo parâmetro é o que ele ira buscar, por exemplo o comando `"a*.ico"` ira filtrar todos os arquivos que começão com a letra *a*, e terminai com a extenção *.ico*.

Em seguida criamos um loop com o intuito de ler individualmente cada arquivo e escrever os seus dados na lista de string *List*. Por fim retornamos essa lista.

___

No formulário principal adicionamos um botão que abrira a *DialogBox*. Dentro do evento de click dele colocamos o código abaixo.

```C#
Binder F = new Binder(directory);
if (F.status)
{
  List<string> List = new List<string>();
  List = F.SearchAll();
  // Adiciona todos os dados dos clientes na lista de strings 'List'.
  if (F.status)
  {
    List<List<string>> searchList = new List<List<string>>();
    
    for (int i = 0; i < List.Count; i++)
    {
      Client.Unit C = Client.DesSerializedClassUnit(List[i]);
      // Interpreta os dados da lista de clientes.
      searchList.Add(new List<string> { C.ID, C.Name });
      // Cria uma lista com os dados importantes 'C.ID, C.Name', e adiciona essa lista na lista de listas 'searchList'.
    }
    Frm_Search S = new Frm_Search(searchList);
    S.ShowDialog();
    // Mostra os formulário na tela.

    if (S.DialogResult == DialogResult.OK)
    // Verifica se o usuário clicou no botão de escolher o cliente.
    {
      var IdSelect = S.IdSelect;
      string clientJSON = F.Search(IdSelect);

      Client.Unit C = new Client.Unit();
      C = Client.DesSerializedClassUnit(clientJSON);
      writeOnForm(C);
      // Escreve os dados no formulário.
    }
  }
  // ...
}
// ...
```

Utilizamos o *List\<List\<string\>>* para criar um **Array Bidimensional**, que nada mais é que uma lista de listas.

Dentro do código fonte do formulário *Frm_Search* adicionamos um *DialogResult.OK* no botão que seleciona uma opção na lista, dessa forma podemos capturar essa informação com o *S.DialogResult*.

Os comandos apos o *if* do *DialogResult* são os mesmos do método *Seleciona cliente cadastrado*, com a diferença que a busca é feita através do id selecionado `F.Search(IdSelect);`.

## **Aula 5**: Exibindo itens no ListBox

Para adicionar os itens na **ListBox** e no **ComboBox** precisamos entender um pouco seu funcionamento. Esses e outros elementos podem receber *string* e classes como itens da lista, e uma string nada mais é que uma classe implícita, que no momento de ser exibida na tela sera executado o comando `string.ToString();`. Ao passar a classe como item do componente, acontecera o mesmo, porem o que sera exibido é algumas informações da classe, e não o conteúdo desejado.

Para resolver o problema descrito acima, precisamos criar um método dentro da classe que sobrescreva o método **ToString**. Abaixo temos o exemplo da classe que adicionamos no formulário *Frm_Search*, que representara cada item da lista.

```C#
class ItemBox
{
  public string id { get; set; }
  // O 'id' é o que sera enviado para o formulário principal ao escolher o item na lista.
  public string name { get; set; }
  // O 'name' sera o texto exibido na tela.

  public override string ToString()
  {
    return name;
  }
}
```

Utilizando a palavra chave **override** substituiremos o método original *ToString*, com isso podemos escolher o que sera exibido na tela quando o **ListBox** executar esse método, que no caso é o texto do *name*.

___

### Por que utilizar um classe ao invés de uma string?

O método correto para a maioria dos elementos como o **ListBox** ou o **ComboBox**, é utilizar uma classe, pois as buscas nos servidores onde estão os dados dos clientes por exemplo, são feitas em sua maioria através de um ID ou um código, e não através de um nome.

Porem para o usuário, buscar pelo nome do cliente é muito mais simples, com isso precisamos de uma maneira de atrelar o nome do cliente ao seu código, para que quando o usuário selecionem o nome desejado, a busca seja feita através do código do cliente.

Por isso é recomendado o uso de uma classe, por poder trabalhar melhor com a lista, fazer uma busca pelo nome, organizar a lista em ordem alfabética, e tudo isso sem perder o *link* entre o nome e o código do cliente.

___

Ainda dentro do formulário, adicionamos o método responsável por adicionar os intens no *ListBox*, e que sera ativo no método construtor.

```C#
lst_search.Items.Clear();

for (int i = 0; i < _SearchList.Count; i++)
{
  ItemBox item = new ItemBox();
  item.id = _SearchList[i][0];
  item.name = _SearchList[i][1];
  lst_search.Items.Add(item);
}
```

> Como o *_SearchList* é uma **lista bidimensional**, precisamos indicar a primeira e a segunda posição nessa lista `[i][0]`.

___

O botão de escolher o item da lista também possui algumas particularidades que veremos no comando abaixo.

```C#
ItemBox selectedItem = (ItemBox)lst_search.Items[lst_search.SelectedIndex];
IdSelect = selectedItem.id;
DialogResult = DialogResult.OK;
// Informa que ao fechar o formulário nesse método, o 'DialogResult' sera 'OK'.
this.Close();
```

Criamos uma variável do tipo *ItemBox* e atribuímos nela o item selecionado. O `lst_search.Items[...]` seleciona um item na lista e assim como o **ComboBox**, podemos selecionar o item através do `SelectedIndex`.

Apesar de todos os itens do **ListBox** serem uma classe, o C# não converte implicitamente esse item em uma classe novamente, é necessario forçar isso explicitamente, e fazemos isso através do `(ItemBox)`.

## **Aula 6**: Trocando a ordem das classes

Até o momento adicionamos a instancia do cliente(*Client*) e a instancia do fichário(*Binder*) dentro do formulário principal, porem a forma como as dados do cliente são manipulados não dis respeito á classe principal, apenas a classe cliente deveria se responsabilizar por essa tarefa. Para resolver isso iremos transportar todos os métodos referentes ao fichário para a classe cliente.

Primeiramente iremos adicionar os novos métodos na classe *Client*. Abaixo teremos os códigos de todos os métodos e um breve resumo.

```C#
public void addBinder(string connection)
{
  Binder F = new Binder(connection);
  if (F.status)
  {
    string clientJson = SerializedClassUnit(this);
    F.AddClient(this.ID, clientJson);
    if (!F.status)
    {
      throw new Exception(F.message);
    }
  }
  else
  {
    throw new Exception(F.message);
  }
}
```

Como agora o método *SerializedClassUnit* esta dentro da mesma classe, o parâmetro é a própria classe, por isso o *this*. O mesmo vale para a propriedade *ID*.

Veremos que os próximos métodos são muito semelhantes, que por sequencia são muito semelhantes aos que estavam no código fonte do formulário principal.

___

```C#
public Unit searchBinder(string id, string connection)
{
  Binder F = new Binder(connection);
  if (F.status)
  {
    string clientJSON = F.Search(id);
    return DesSerializedClassUnit(clientJSON);
  }
  // ...
}
```

Como a classe que esta sendo buscada provavelmente não esta instanciada, não podemos utilizar o *this.ID*, pois essa propriedade estará vazia, por isso precisamos receber o *id* como parâmetro.

___

```C#
public void Save(string connection)
{
  Binder F = new Binder(connection);
  if (F.status)
  {
    string clientJson = SerializedClassUnit(this);
    F.Save(this.ID, clientJson);
    if (!F.status)
    {
      throw new Exception(F.message);
    }
  }
  // ...
}
```

O método de salvar alteração é praticamente o mesmo de adicionar novo.

___

```C#
public void Delete(string connection)
{
  Binder F = new Binder(connection);
  if (F.status)
  {
    F.Delete(this.ID);
    if (!F.status)
    {
      throw new Exception(F.message);
    }
  }
  // ...
}
```

___

```C#
public List<string> searchAllBinder(string connection)
{
  Binder F = new Binder(connection);
  if (F.status)
  {
    return F.SearchAll();
  }
  // ...
}
```

O método que busca todos os clientes para o **ListBox** também precisa ser adicionado.

___

Agora como removemos a responsabilidade do fichário do formulário principal, o programa ficou um pouco menor.

Abaixo temos o código do método adicionar novo e de salvar alterações, que são idênticos.

```C#
Client.Unit C = new Client.Unit();
C = FormDataToClass();
C.CheckClass();
C.CheckComplement();
C.addBinder(directory);
MessageBox.Show(/*...*/);
```

> A unica diferença é o método *addBinder*, que seria *Save*.

___

Abaixo temos o código do método *Delete*, que é o mesmo do *Seleciona cliente cadastrado*, porem com o código de deletar a mais.

```C#
if (txt_clientID.Text.Trim() == "")
{
  MessageBox.Show("Código do cliente  vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
else
{
  Client.Unit C = new Client.Unit();
  C = C.searchBinder(txt_clientID.Text, directory);
  if (C == null)
  {
    MessageBox.Show("Cliente não encontrado.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
  else
  {
    writeOnForm(C);
    Frm_Question Db = new Frm_Question("Deseja excluir cliente?", "Frm_Question");
    Db.ShowDialog();
    if (Db.DialogResult == DialogResult.Yes)
    {
      C.Delete(directory);
      MessageBox.Show("Cliente apagado com sucesso.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
      ClearForm();
    }
  }
}
```

> O *Seleciona cliente cadastrado* termina na linha do código `writeOnForm(C);`, o resto do código diz respeito ao método *Delete*.
