# Curso de Windows Forms com o professor Victorino Vila

## Sequencia das aulas e os conteúdos apresentados

- Aula 1: Criando uma biblioteca e reorganizando os formulários.

Nessa aula criamos uma "Biblioteca de Classes (.Net Framework)", onde passamos algumas classes para dentro dessa biblioteca. Para utilizar os métodos dessa classe, foi necessario adicionar a referencia dessa biblioteca no projeto principal, em "Dependências" utilizar "Adicionar referencia de projeto...", e, também é preciso utilizar o comando abaixo no arquivo que ira utilizar as classes.

```C#
using NomeDaBiblioteca;
```

Além disso também organizamos os formulários, criando uma pasta para todos os formulários que são chamados no formulário 'Principal'. Ao passar esses formulários para uma subpasta não se faz necessario alterar as chamadas à classe, o programa ira funcionar normalmente sem nenhuma alteração.
