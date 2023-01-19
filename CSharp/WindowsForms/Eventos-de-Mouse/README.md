# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

## Aula 1: Eventos de mouse

Dentro do aquivo *Frm_MouseEvent* vimos alguns eventos que podemos capturar, sendo eles o **MouseEnter**, **MouseLeave**, **MouseDown**, **MouseUp**, **MouseMove** e **MouseClick**. Os próprios nomes dos eventos já são sugestivos para como eles funcionam.

No arquivo *Frm_MouseCursor* vimos como alterar o ícone do cursor do mouse dependendo do que estamos querendo indicar. Por exemplo o comando abaixo deixa o cursos no modo de espera, que é o spin azul do windows, indicando que é preciso esperar o final do processo.

```C#
this.Cursor = Cursors.WaitCursor;
// 
// processo aqui dentro...
// 
this.Cursor = Cursors.Default;
```

> Lembrando que como foi feito acima, é preciso mudar para o cursor padrão(Default) no final do processo.

### Propriedades e informações nos eventos

Ao abrir o evento para adicionar as funcionalidades nele, temos a propriedade *"e"*, que possui diversas informações sobre o evento, como a posição X e Y onde foi acionado o evento, qual o botão do mouse foi clicado e o *Delta* que mostra quantas vezes foi girado o botão do meio do mouse(rodinha do mouse). Nos arquivos *Frm_MouseCapture* e *Frm_FloatingMenu* foi explorado essas informações.

Abaixo temos um exemplo de validação para quando um evento só sera executado dependendo de qual botão foi clicado.

```C#
if( e.Button == MouseButtons.Right )
{
  // Comandos...
}
```

> A propriedade *e.Button* informa qual botão foi utilizado, e dentro do próprio C# temos como verificar se foi o botão escolhido com o enumerador **MouseButtons**.

## Aula 2: Menu flutuante

Para criar um menu flutuante é preciso faze-lo dinamicamente, pois ele aparecera apenas caso alguma ação seja tomada, por exemplo clicar com o botão direito do mouse, como vimos na aula 01.

Primeiramente é preciso criar uma instancia do menu, onde iremos adicionar cada item nela. É preciso criar uma instancia do item para cada item necessario. Abaixo temos um exemplo do código.

```C#
// O 'ContextMenuStrip' cria o menu dinamicamente.
var ContextMenu = new ContextMenuStrip();
// O 'ToolStripMenuItem' cria o item que iremos adicionar.
var vTollTip001 = new ToolStripMenuItem();

vTollTip001.Text = "Item menu 1";
ContextMenu.Items.Add( vTollTip001 );
```

> Criando um método que retorna o item necessario, evitamos muito código repetido.

Até o momento o menu foi criado mas não foi exibido, é preciso adiciona-lo na tela. O método utilizado é o **Show(parâmetros)**, que tem na instancia do *ContextMenuStrip*. Este método exige 2 paramentos, o primeiro é sobre quem ele ira aparecer, e o segundo em que posição ira aparecer.

```C#
var ContextMenu = new ContextMenuStrip();
// O 'assembleItem' é o método que retorna o item.
var vToolTip01 = assembleItem("Novo item", "key");
var vToolTip02 = assembleItem("Item 2", "Frm_ValidaSenha");

ContextMenu.Items.Add(vToolTip01);
ContextMenu.Items.Add(vToolTip02);
ContextMenu.Show(this, new Point(e.X, e.Y));
```

> O primeiro parâmetro *this* representa o formulário que estamos trabalhando, dessa forma o menu ira aparecer sobre ele. O segundo é a posição, que como vimos na aula 01, a propriedade *"e"* possui as posição **X** e **Y** do evento.

Porem os item ainda não possuem funcionalidades, e iremos adicionar elas na instancia do item criado. Novamente temos mais de um paço para realizar isto, sendo o primeiro, criar um método muito semelhando ao método do componente de um formulário.

```C#
void vToolTip01_Click(object sender, EventArgs e)
// Os parâmetros do método são os mesmos dos componentes do formulário.
{
  MessageBox.Show("Opção selecionada.");
}
```

Então iremos lincar esse método a um evento de click do item.

```C#
// Comandos...
// 
ContextMenu.Items.Add(vToolTip01);
ContextMenu.Show(this, new Point(e.X, e.Y));

vToolTip01.Click += new System.EventHandler(vToolTip01_Click);
```

> Lembrando que é preciso utilizar o *"+="* para adicionar o evento.

O **Click** é uma evento padrão que a instancia do item também tem, e adicionamos a ele um evento de click que quando ativado ira executar o método que criamos, que neste exercício foi o *vToolTip01_Click*.

## Aula 3: Adicionando um menu flutuante no arquivo *Frm_Principal_Menu_UC*

Nesta aula adicionamos um menu com a funcionalidade de gerenciar as abas abertas, que é mostrado na tela quando clicado com o botão direito do mouse sobre as abas. As funcionalidades são *Apagar aba*, *Apagar todas a esquerda*, *Apagar todas a direita* e *Apagar todas menos a aba selecionada*.

A primeira opção *Apagar aba* ja tinha sido implementada no curso anterior, e possui o comando bem simples. Utilizando o método *Remove* do *TabPages*, podemos remover a aba selecionada.

```C#
tbc_application.TabPages.Remove(tbc_application.SelectedTab);
```

> O *tbc_application* é o nome do elemento **TabControl**.

A ultima opção é a junção da segunda e da terceira. Então veremos a ultima opção abaixo. Como foi visto no curso anterior, para remover uma aba a maneira correta é começando da ultima aba para a primeira. Por exemplo a opção *Apagar todas a esquerda*, começa da aba logo a esquerda da selecionada, em direção a primeira aba da lista.

```C#
int SelectedItem = tbc_application.SelectedIndex;
// Removendo a esquerda:
for( int i = SelectedItem - 1; i >= 0; i-- )
{
  tbc_application.TabPages.Remove(tbc_application.TabPages[i]);
}
```

Para remover as abas a esquerda, atribuiremos a aba selecionada menos 1 à variável *"i"*, e iremos varrer até a primeira aba.

> O menos 1 é para garantir que a aba selecionada não seja removida.

```C#
int SelectedItem = tbc_application.SelectedIndex;
// Removendo a direita:
for( int i = tbc_application.TabPages.Count - 1; i > SelectedItem; i-- )
{
  tbc_application.TabPages.Remove(tbc_application.TabPages[i]);
}
```

Já para remover as abas a direita, iremos atribuir o total de abas menos 1 à variável *"i"*, e o loop sera do total de abas até a aba selecionada.

## Aula 4: Criando um formulário de cadastro de cliente

Nesta aula criamos um formulário do tipo *Controle de usuário*, onde adicionamos diversos campos e novos componentes para simular um cadastro de cliente.

O primeiro novo elemento foi o **CheckBox** que é uma caixa que pode ser marcada e desmarcada. Foi utilizada para ativar ou desativar o campo do *nome do pai*. O evento padrão é o *CheckedChanged*, que como sugere o nome é ativado quando alterna entre marcado e desmarcado.

O segundo é o **RadioButton** que é parecido com o **CheckBox**, porem só tem utilidade se for usado em conjunto com outros **RadioButton**. O funcionamento dele depende do contexto que ele esta, por exemplo ao marcar o componente, o anterior é desmarcado, assim somente uma opção pode ser marcada por vez, porem caso esteja dentro de um **GroupBox**, os únicos **RadioButton** que serão afetados são os de dentro do **GroupBox**. Ou seja, cada **RadioButton** só interfira nos outros **RadioButton** que estão no mesmo nível.

O ultimo é o **ComboBox**, que é um campo que quando clicado abre uma caixa com varias opções que podem ser escolhidas, muito semelhante ao **Select** do *JavaScrip*. Utilizamos no formulário para escolher o estado onde mora. Utilizamos a classe **File** que vimos nos cursos anteriores para ler um arquivo *txt* que possuí todos os estados do Brasil. Para adicionar o item, o **ComboBox** possui o comando `Items.Add` que ira adicionar o item na caixa de opções.

```C#
foreach( var line in lines )
{
  cmb_state.Items.Add(line);
}
```

> *cmb_state* é o nome do elemento **ComboBox**.

Como cada linha do arquivo é um item da lista *"lines"*, podemos fazer um *foreach* para varrer essa lista e adicionar cada item dela no **ComboBox**. Dessa forma evitamos ter que digitar 27 linhas de comando só para adicionar os estados.
