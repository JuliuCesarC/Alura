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
