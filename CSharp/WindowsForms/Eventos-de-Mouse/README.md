# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

- Aula 1: Eventos de mouse.

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

- Aula 2: Menu flutuante.

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
