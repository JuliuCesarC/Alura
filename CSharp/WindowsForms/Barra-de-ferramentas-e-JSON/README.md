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
