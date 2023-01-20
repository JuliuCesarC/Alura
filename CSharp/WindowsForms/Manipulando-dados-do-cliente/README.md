# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

## **Aula 1**: Implementando funcionalidades na Barra de Ferramenta

No curso anterior adicionamos os itens da Barra de Ferramentas, mas a funções que cada um deveria executar não. Nesta aula iremos adicionar a funcionalidade do item *Limpar formulário*, que sera o mais simples, e também do item *Adicionar novo cliente*.

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

Dentro do código fonte do formulário, no evento do item *Adicionar novo cliente* foi implementado diversos códigos que veremos mais a frente.

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

Na classe *Client* adicionamos o comando para *Serializar* um JSON.

```C#
public static string SerializedClassUnit(Unit unit)
{
  return JsonConvert.SerializeObject(unit);
}
```

Existe bastante semelhança entre o método de *Desserializar*, a diferença se da ao fato de que ele recebe uma classe *Unit* e retorna uma *string*.

## **Aula 2**: Finalizando a funcionalidade do primeiro item da barra de ferramentas

Dentro do código fonte do formulário temos o evento do item *Adicionar novo cliente*, que mudou bastante, mas ainda continua com alguns comandos do curso anterior. Vejamos abaixo o código.

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
