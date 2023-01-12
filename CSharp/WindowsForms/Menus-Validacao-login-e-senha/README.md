# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

- Aula 1: Criando uma biblioteca e reorganizando os formulários.

Nessa aula criamos uma __Biblioteca de Classes (.Net Framework)__, onde passamos algumas classes para dentro dessa biblioteca. Para utilizar os métodos dessa classe, foi necessario adicionar a referencia dessa biblioteca no projeto principal, em "Dependências" utilizar "Adicionar referencia de projeto...", e, também é preciso utilizar o comando abaixo no arquivo que ira utilizar as classes.

```C#
using NomeDaBiblioteca;
```

Além disso também organizamos os formulários, criando uma pasta para todos os formulários que são chamados no formulário 'Principal'. Ao passar esses formulários para uma subpasta não se faz necessario alterar as chamadas à classe, o programa ira funcionar normalmente sem nenhuma alteração.

- Aula 2: Adicionando o menu.

O elemento __MenuStrip__ adiciona uma barra de menu no topo do formulário, e podemos adicionar os itens desejados, categorias com mais itens dentro, teclas de atalho e as ações desses itens. Podemos também adicionar ícones através da propriedade _Image_.
> Ao clicar na opção para adicionar ira abrir uma aba onde podemos escolher o ícone de um "Recurso local" ou de um "Arquivo de recurso de projeto", para este exemplo utilizaremos a segunda opção, o que necessita adicionar essas imagens e ícones no recurso do projeto. Isso é feito através das "propriedades" do projeto principal, na aba de "Recursos", e na opção de imagem só é aceito arquivos 'png' e nos ícones, arquivos 'ico'.

Para adicionarmos teclas de atalho nos itens, é utilizado a propriedade _ShortcutKey_

- Aula 3: Transformando o Formulário para o formato MDI.

Por padrão os formulários abertos através do formulário principal estão no formato
__DialogBox__, o que congela o formulário anterior. Porem caso seja necessario abrir mais de uma aba, ou que seja possível trabalhar no formulário anterior, utilizaremos o formato __MDI__. Sendo possível abrir múltiplas abas dentro do formulário principal.

> MDI: Multiple-Document Interface.

Para que funcione corretamente é preciso também alterar a chamado dos formulários. Anteriormente era necessários apenas utilizar a instancia da classe com o `.ShowDialog`, porem agora precisamos do código abaixo:

```C#
KeyDown.MdiParent= this;
KeyDown.Show();
```

Também nesta aula, criamos opções de layout de apresentação das abas abertas no formulário, por exemplo o layout de cascata tem o código:

```C#
this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
```

### Propriedade Anchor

A propriedade __Anchor__ permite fixar os elementos dentro do formulário em 4 posições, sendo elas _top_, _right_, _bottom_ e _left_. Com isso podemos tornar esses elementos dinâmicos de acordo com o tamanho da tela.

> Selecionando _top_ e _right_ por exemplo, teremos um elemento que segue a borda direita da aba e não altera o próprio tamanho.

Ao trabalhar com o __Anchor__ alguns problemas de sobreposição dos elementos pode acontecer, umas das formar de resolver esse problema e limitando o tamanho da aba no menor valor e/ou maior valor com as propriedades __MinimumSize__ e __MaximumSize__.

- Aula 4: User Control e TabControl.

Outra forma de abrir os formulários é utilizando o controle de usuário(User Control), que pode ser aberto dentro do elemento __TabControl__, ou outros elementos. O User Control é um  formulário que deve ser criado igual outro, porem ele não possui as bordas padrões do windows, onde estão os botões de minimizar, maximizar e de fechar. Mas podemos adicionar praticamento todos os elementos de um formulário normal.

Para adicionar o formulário _User Control_ dentro do elemento __TabControl__ do formulário principal, precisamos dos comando abaixo.

```C#
Frm_HelloWorld_UC helloWorld_UC = new Frm_HelloWorld_UC();
// Primeiro criamos uma instancia do User Control.
TabPage TB = new TabPage();
// Então criamos uma TabPage dinamicamente.
TB.Name = "Hello_World_" + NameControlHelloWorld;
TB.Text = "Hello_" + NameControlHelloWorld;
// Concatenamos o nome da aba com um numero, para que cada aba tenha um nome diferente.
TB.ImageIndex = 1;
TB.Controls.Add(helloWorld_UC);
// Adicionamos a instancia de User Control na TabPage.
tbc_application.TabPages.Add( TB );
// E por ultimos adicionamos a TabPage no TabControl.
NameControlHelloWorld++;
```

> O 'tbc_application' é o nome que foi colocado no TabControl. Também adicionamos um ícone ao lado do nome da aba com o 'ImageIndex', para escolher essa imagem primeiramente é preciso adicionar o elemento __ImageList__ no formulário, e adicionar as imagens dentro desse elemento. Segundo é preciso associar o __ImageList__ no elemento __TabControl__ através da propriedade _ImageList_.

### Removendo uma TabPage

Até o momento foi visto como adicionar novas abas dentro do __TabControl__, agora veremos como fechar uma aba.

```C#
tbc_application.TabPages.Remove(tbc_application.SelectedTab);
```

> O 'tbc_application.SelectedTab' ira indicar qual a aba que esta selecionada no momento. É preciso criar uma validação antes de executar o comando, pois caso não tenha nenhuma aba aberta, e o comando for executado, ira acusar um erro.
