# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

Para executar o formulário atual, é preciso informar o nome do formulário no 'Program.cs':

```C#
Application.Run(new Frm_NomeDoFormulário());
```

- Aula 1: HelloWorld.

Apresentação do Windows Forms, tipos de elementos que podem ser adicionados no formulário, como posicionar esses itens, propriedades do formulário e dos elementos, tipos de eventos e pratica com eventos de click. Alguns comandos utilizados: `Application.Exit();`, `btn_alteraTitulo_Click`.

- Aula 2: KeyDown.

Utilizando o evento de keyDown, entendendo funcionamento do label, além de alterar mais as propriedades para chegar no resultado desejado. Alguns comandos utilizados: `txt_input_KeyDown`, `AppendText`, `KeyCode.ToString()`.

- Aula 3: CheckPassword.

Implementando métodos de classes em eventos, criando um formulário interativo onde o resultado apresentado mudava de acordo com o input do usuário. Alguns comandos utilizados: `PasswordChar`, `ChecaForcaSenha.ForcaDaSenha`.

- Aula 4: Mask.

Entendendo funcionamento do MaskTextBox, e como inserir uma mascara em um campo de texto e inserindo mascara dinamicamente. Alguns comandos utilizados: `.Mask`, `Focus();`

- Aula 5: ValidadeCPF, ValidateCPF_2.

A mascara de texto restringe os formatos que o usuário pode escrever, e para verificar se o dado é valido, utilizamos um método que valida o CPF. Alguns comandos utilizados: `ForeColor`, `Color.Green`. No segundo exercício utilizamos a caixa de dialogo do Form para interagir com o usuário, validamos os dados antes de executar o método ValidaCPF. Alguns comandos utilizados: `MessageBox.Show`, `MessageBoxButtons.YesNo`, `DialogResult.Yes`.

```C#
MessageBox.Show("CPF Válido", "Mensagem Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
```

- Aula 6: Principal.

Criamos um formulário com os botões de cada formulário criado nas aulas anteriores, com podemos abrir cada formulário individualmente sem precisar alterar o inicializador no 'Program.cs'. Para isso utilizamos um método do Form que é o `ShowDialog();`,que é fornecido ao criar uma instancia de um formulário, Exemplo:

```C#
Frm_keyDown keyDown= new Frm_keyDown();
keyDown.ShowDialog();
```
