# Curso de Git e GitHub com o instrutor Vinicius Dias

## Para este curso utilizaremos o Git Bash, porem os comando podem ser executados em diversos tipos de terminais. No começo do arquivo temos os comando para gerenciar um repositório, e ao final do arquivo os comando para inspecionar o repositório

### Os comando podem ser executados em diversos tipos de terminais, porém nesse curso utilizamos o Git Bash

## Comandos básicos para criar e gerenciar um repositório.
&nbsp;

---

```bash
git init
```

Cria um repositório local. Ao entrar na pasta desejada podemos executar esse comando para iniciar o repositório.

- git init --bare: define um repositório puro, que só tem como função guardar as alterações executadas, e não propriamente possuindo uma cópia dos arquivos.

---

```bash
git add nome_do_arquivo
git add .
```

Adiciona um item na lista de monitoramento do git, já o 'git add .' adiciona todos os arquivos da pasta nesta lista.

---

```bash
git commit -m "mensagem_aqui_dentro"
```

Faz uma atualização das alteração dos arquivos que o git esta monitorando. O commit é muito associado a um check point, onde é possível voltar a aquele ponto, ou relembrar o que foi alterado nesse commit. É preciso adicionar uma mensagem em cada commit, por isso o parâmetro -m.

---

```bash
git remote
```

Lista todos os repositórios remotos disponíveis na pasta.

- git remote add nome_do_remoto caminho_para_repositório: adiciona um repositório remoto, o caminho pode ser uma pasta, uma url, um repositório GitHub. exemplo:
- "git remote add repoLocal C:\Users\Cesar\Desktop\Curso_Dev"
- git remote rename nome_atual novo_nome: renomeia o repositório remoto.

---

```bash
git clone endereço_do_repositório
```

Clona o repositório escolhido criando uma nova pasta com todos os arquivos dele. O nome da pasta pode ser alterado adicionando o novo nome no final do comando. exemplo:

- "git clone /c/Users/Cesar/Desktop/Curso_Dev/Git_GitHub/server/ server_ana"

---

```bash
git push repositório_remoto nome_da_branch
```

Envia o conteúdo de um repositório local para um repositório remoto. exemplo:

- "git push origin master"
- git push repositório_remoto --delete nome_da_branch: deleta uma branch remota.

---

```bash
git pull repositório_remoto nome_da_branch_do_remoto
```

Traz o conteúdo de um repositório remoto para o repositório local, lembrando que o nome da branch selecionada é o da branch setada no repositório remoto. Na maioria daz vezes o nome da branch do GitHub é 'main', enquanto a do repo local é 'master'. exemplo:

- "git pull servidor_ana master"

---

```bash
git branch
```

Lista todos as branch do projeto.

- git branch nome_nova_branch: cria uma nova branch. É possível criar uma nova branch e ja entrar nela com o código abaixo.
- "git checkout -b nome_nova_branch": o '-b' é o responsável por criar a branch.

### Quando criamos uma nova branch e trabalhamos dentro dela, garantimos que o conteúdo da branch original não seja alterado, dessa forma caso as novas alterações não funcionem, podemos simplesmente descartar esse branch, porém caso seja necessário implementar essas alterações, então precisamos efetuar um 'merge'

- git branch -m novo_nome_da_branch: renomear a branch.

- git branch -d/-D nome_da_branch: deleta uma branch local

---

```bash
git checkout
```

Utilizado para navegar entre estados no repositório. Podemos utilizar para alternar entre as branchs, para voltar a um estado anterior das modificações entre outros.

- git checkout nome_da_branch: alterna entre as branchs

```bash
git checkout hash_do_commit
```

#### Retorna para o estado do repositório do commit selecionado. Ao fazer isso o git nos avisa que o estado atual esta desanexado da HEAD(referencia a ramificação atual de trabalhando), ou seja, não esta em nenhuma branch, qualquer commit feito sera descartado ao voltarmos para alguma branch. Porem podemos salvar as alterações criando uma nova branch e 'commitando' nela. Obs: não é preciso utilizar o hash inteiro do commit, a versão resumida com 7 dígitos sera suficiente

---

```bash
git merge
```

Junta uma branch selecionada com a branch atual. Caso haja algum conflito entre as branch, o Vscode ira mostrar onde os códigos se conflitaram, basta remover um dos 2 códigos e prosseguir com um commit. Preserva os commits da branch principal e da branch secundaria, isso significa e ouve uma bifurcação quando a branch secundaria foi criada, e uma intersecção quando houve um 'merge', mas os 2 caminhos continuam no histórico.

---

```bash
git rebase
```

Mescla 2 branchs, diferentemente do 'merge', não preserva o caminho das branchs, ou seja, ira colocar no final da branch principal todos os commits da branch secundaria, essa forma ficando apenas um caminho, aparentemente nunca havendo uma bifurcação. Existe alguns problemas de rastreabilidade e segurança com esse método, por isso é preciso saber quando utilizar.

### Utilizando o rebase para juntar vários commits em um só

Uma das funcionalidades do rebase é poder juntar alguns commits em apenas um, e isso é possível com o rebase interativo `git rebase -i`.

```bash
git rebase -i estado_atual~numero_de_commits
```

Para juntar os commits primeiro precisamos informar o estado atual e o numero de commits que iremos juntar, ficando assim: `git rebase -i HEAD~3`. O resultado sera a junção dos 3 commits anteriores ao estado atual de trabalho(HEAD).

```bash
git rebase -i hash_do_commit_anterior
```

Podemos também selecionar o hash do commit anterior ao qual eu quero selecionar, por exemplo, se o intuito é juntar 4 commits em um, o hash selecionado é o do commit anterior ao dele, ou seja o quinto commit. Lembrando que se utilizar esse método não no commit mais recente, é preciso selecionar commits anteriores ao atual, não é possível selecionar commits mais novos que o atual.

---

### Como desfazer alterações

```bash
git checkout -- nome_do_arquivo
```

Caso não tenha adicionado as alterações no git add, podemos descartar as alterações no arquivo selecionado utilizando  'checkout'.

```bash
git reset HEAD nome_do_arquivo
```

Caso as alterações tenham sido adicionadas com o git add, porém ainda não tenha sido feito o commit, podemos remover esses arquivos do git add com o comando 'reset'.

```bash
git revert hash_do_commit
```

Reverte o commit selecionado. Não remove o commit do historio, apenas reverte as alterações e adiciona um commit informando o revert.

---

### Git Stash

A funcionalidade do stash é muito interessante, ele remove e guarda todas as alterações feitas que ainda não foram "commitadas" em um local temporário, deixando o repositório no estado do ultimo commit feito. Dessa forma não é necessario criar uma branch nova para pequenas modificações ou criar um commit com alterações não prontas. Posteriormente podemos escolher se iremos trazer de volta ou descartar essas alterações.

```bash
git stash
```

Guarda as alterações ainda não "commitadas" em um local temporário. Por exemplo pode ser utilizado para salvar alguma alteração antes de executar um git pull.

- git stash list: mostra a lista de todos os stash's criados.

```bash
git stash apply
```

Aplica as alterações do ultimo stash salvo no estado atual do repositório. Caso seja necessario trazer as alterações de um stash especifico, adicionamos o numero dele no final:

- "git stash apply 3"

```bash
git stash pop
```

Muito parecido com o apply, porem alem de aplicar as alterações, ele remove o stash da lista.

```bash
git stash drop
```

Remove o ultimo stash da lista, pode também remover um stash especifico passando o numero do mesmo no final do comando.

- "git stash drop 1"

```bash
git stash clear
```

Remove todos os stash's salvos.

### Release

---

```bash
git tag -a nome_da_tag -m "mensagem_aqui_dentro"
```

Adiciona uma tag no estado atual. Geralmente utilizado para indicar uma versão release do programa, e ao enviar essa tag para o GitHub por exemplo, temos uma aba especifica de Release do repositório onde sera mostrado todas as tags e os estados/commit dessas tags. É possível também baixar um arquivo compactado dessa versão do repositório.

## Comandos para inspecionar e analisar um repositório

```bash
git status
```

Mostra quais arquivos foram alterados, se existe algum arquivo não monitorado, quantos commits ja foram executados nesse repositório.

---

```bash
git log
```

Mostra uma lista de commits desse repositório. Caso haja muitos commits ele ira mostrar alguns por vez, com a tecla 'f' ele mostra mais commits, e a tecla 'q' sai desse modo. O git log possui diversos parâmetros, dentre eles

- git log --oneline: mostra os commits em uma linha
- git log -p: mostra em detalhe as alterações que foram executadas
- git log -S "pesquisa_aqui": faz uma pesquisa nos aquivos do repositório para encontrar dentro do código o que foi digitado no campo de pesquisa. Exe:
  - git log -S "console.log": retorna os commits que possuem um arquivo com esse código.

### É possível formatar de maneira muito especifica como os comandos abaixo

- git log --pretty="format:%H" : mostra apenas o hash do commit
- git log --pretty="format:%h %s" : mostra apenas o hash resumido e a mensagem do commit
- git log --pretty="format:%s %ae" : mostra a mensagem e o email do altor do commit

---

```bash
git diff
git diff hash_1..hash_2
```
git diff
git diff hash_1..hash_2
```

No primeiro código mostra de forma detalhada as alterações feitas que ainda não foram adicionadas e 'commitadas', e no segundo código mostra a diferença entre o primeiro commit e segundo commit selecionados. Excelente comando para verificar o que foi modificado e implementado até o estado atual do repositório. Obs: é preciso colocar os 2 pontos entre a hash's para funcionar o comando.

---

```bash
git diff
git diff hash_1..hash_2
```

No primeiro código mostra de forma detalhada as alterações feitas que ainda não foram adicionadas e 'commitadas', e no segundo código mostra a diferença entre o primeiro commit e segundo commit selecionados. Excelente comando para verificar o que foi modificado e implementado até o estado atual do repositório. Obs: é preciso colocar os 2 pontos entre a hash's para funcionar o comando.

---

```bash
git config
```

Gerencia as configurações do git, pode ser utilizado para setar ou obter dados.

- git config --global: define o escopo global
- git config --local: define o escopo local, no repositório
- git config --local user.name "nome_do_usuário": define ou altera o nome de usuário no escopo local.
- git config --global user.email "email": define ou altera o email do usuário no escopo global
- git config --local author.name ""
- git config --local author.email ""
- git config --local committer.name ""
- git config --local committer.email ""

#### É possível obter a informação omitindo a parte com as aspas. Exe

- "git config --local user.name"
