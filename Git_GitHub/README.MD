# Curso de Git e GitHub com o instrutor Vinicius Dias

## Para este curso utilizaremos o Git Bash, porem os comando podem ser executados em diversos tipos de terminais. No começo do arquivo temos os comando para gerenciar um repositório, e ao final do arquivo os comando para inspecionar o repositório

&nbsp;

## Comandos básicos para criar e gerenciar um repositório

&nbsp;

---

```bash
git init
```

Cria um repositório local. Ao entrar na pasta desejada podemos executar esse comando para iniciar o repositório.

- `git init --bare`: define um repositório puro, que só tem como função guardar as alterações executadas, e não propriamente possuindo uma cópia dos arquivos.

---

```bash
git add nome_do_arquivo
git add .
```

Adiciona um item na lista de monitoramento do git, já o `git add .` adiciona todos os arquivos da pasta nesta lista.

---

```bash
git commit -m "mensagem_aqui_dentro"
```

Cria uma especie de check point, atualizando o estado atual com as alterações dos arquivos que o git esta monitorando. Os commits devem ser feitos com sabedoria para que o histórico fique legível e linear. Modificações não prontas ou com problemas podem ser salvas com o `git stash`. É preciso adicionar uma mensagem em cada commit, por isso o parâmetro -m.

---

```bash
git remote
```

Lista todos os repositórios remotos disponíveis no arquivo.

- `git remote add nome_do_remoto caminho_para_repositório`: adiciona um repositório remoto, o caminho pode ser uma pasta, uma url, um repositório GitHub. exemplo:
- `git remote add repoLocal C:\Users\Cesar\Desktop\Curso_Dev`
- `git remote rename nome_atual novo_nome`: renomeia o repositório remoto.
- `git remote -v`: mostra a url dos repositórios remotos.

---

```bash
git clone endereço_do_repositório
```

Clona o repositório escolhido criando uma nova pasta com todos os arquivos dele. O nome da pasta pode ser alterado adicionando o novo nome no final do comando. exemplo:

- `git clone /c/Users/Cesar/Desktop/Curso_Dev/Git_GitHub/server/ server_ana`

---

```bash
git push repositório_remoto nome_da_branch
```

Envia o conteúdo de um repositório local para um repositório remoto. exemplo:

- `git push origin master`
- `git push repositório_remoto --delete nome_da_branch`: deleta uma branch remota.

---

```bash
git pull repositório_remoto nome_da_branch_do_remoto
```

Traz o conteúdo de um repositório remoto para o repositório local, lembrando que o nome da branch selecionada é o da branch setada no repositório remoto. Na maioria daz vezes o nome da branch do GitHub é 'main', enquanto a do repo local é 'master'. exemplo:

- `git pull servidor_ana master`

---

```bash
git branch
```

Lista todos as branch do projeto.

- `git branch nome_nova_branch`: cria uma nova branch. É possível criar uma nova branch e ja entrar nela com o código abaixo.
- `git checkout -b nome_nova_branch`: o '-b' é o responsável por criar a branch.

> Quando criamos uma nova branch e trabalhamos dentro dela, garantimos que o conteúdo da branch original não seja alterado, dessa forma caso as novas alterações não funcionem, podemos simplesmente descartar esse branch, porém caso seja necessário implementar essas alterações, então podemos efetuar um 'merge'

- `git branch -m novo_nome_da_branch`: renomear a branch.

- `git branch -d/-D nome_da_branch`: deleta uma branch local, caso a branch possua commits a frente da branch principal, então só sera possível excluir utilizando o `-D`.

> Geralmente excluimos uma branch enquanto estamos na branch principal.

---

```bash
git checkout
```

Utilizado para navegar entre estados no repositório. Podemos utilizar para alternar entre as branchs, para voltar a um estado anterior das modificações entre outros.

- `git checkout nome_da_branch`: alterna entre as branchs

```bash
git checkout hash_do_commit
```

Retorna para o estado do repositório do commit selecionado. Ao fazer isso o git nos avisa que o estado atual esta desanexado da HEAD(referencia a ramificação atual de trabalho), ou seja, não esta em nenhuma branch, qualquer commit feito sera descartado se sairmos desse commit. Porem podemos salvar as alterações criando uma nova branch e 'commitando' nela.
> Obs: não é preciso utilizar o hash inteiro do commit, a versão resumida com 7 dígitos sera suficiente

---

```bash
git merge
```

Junta uma branch selecionada com a branch atual, exemplo: `git merge new_list`. Preserva os commits das 2 branchs, isso significa que ouve uma bifurcação quando a branch secundaria foi criada, e, uma intersecção quando executamos um 'merge', mas os 2 caminhos continuam no histórico.
> Caso haja algum conflito entre as branch, o Vscode ira mostrar na tela onde os códigos se conflitaram, basta remover um dos 2 códigos e prosseguir com o merge.

---

```bash
git rebase
```

Mescla 2 branchs, diferentemente do 'merge', não preserva o caminho das branchs, ou seja, ira mesclar todos os commits em um único caminho, deixando o histórico aparentando que nunca houve uma bifurcação. Existe alguns problemas de rastreabilidade e segurança com esse método, por isso é preciso saber quando utilizar.

---

&nbsp;

### Utilizando o Rebase para juntar vários commits em um só

&nbsp;

Uma das funcionalidades do rebase é poder juntar alguns commits em apenas um, e isso é possível com o rebase interativo `git rebase -i`.

> Apos executar o comando, o git bash ira mostrar uma tela com varias informações, e no topo dessa tela temos os commits selecionados, a ordem é de cima para baixo do mais antigo para o mais novo commit. Na frente de cada commit temos a palavra 'pick', que deve ser substituída por um 's' caso esse commit deva se ligar ao commit anterior. Geralmente o commit principal sera o mais antigo e ficara com o 'pick', os outros commits ficaram com um 's'. Para terminar essa parte é só apertar a tecla "esc" e executar o `:x`. Após isso ira aparecer a segunda tela com o comentário de todos os commits, que devem ser apagados para restar apenas um comentário no topo da tela. No git bash o comentário resultante ira ficar na cor amarela. Novamente para finalizar a tarefa, clicar na tecla "esc" e executar o `:x`.

```bash
git rebase -i estado_atual~numero_de_commits
```

Para juntar os commits primeiro precisamos informar o estado atual e o numero de commits que iremos juntar. Por exemplo, estamos no estado mais atual e precisamos juntar os 3 ultimos commits, então podemos executar o comando: `git rebase -i HEAD~3`.

```bash
git rebase -i hash_do_commit_anterior
```

Podemos também selecionar o hash do commit anterior ao qual eu quero selecionar, por exemplo, se o intuito é juntar 4 commits em um, o hash selecionado é o do commit anterior ao dele, ou seja o quinto commit. Exemplo `git rebase -i cced65a`.

---

&nbsp;

### Trazendo um commit especifico para o estado atual com cherry-pick

&nbsp;

O cherry-pick nos permite trazer apenas um commit especifico para o estado que estamos trabalhando. Isso o diferencia bastante de um merge ou um rebase.

```bash
git cherry-pick hash_do_commit
```

Traz apenas as alterações que estavam incluídas no commit.
> Por exemplo, suponhamos uma branch secundaria feita para adicionar novas funcionalidades, porem apos descobrir um bug na branch master, criamos um hotfix nessa branch secundaria, então podemos levar esse hotfix para a master, sem trazer as funcionalidades da branch secundaria que ainda não estão prontas.

---

&nbsp;

### Como desfazer alterações

&nbsp;

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

&nbsp;

### Git Stash

&nbsp;

A funcionalidade do stash é muito interessante, ele remove e guarda todas as alterações feitas que ainda não foram "commitadas" em um local temporário, deixando o repositório no estado do ultimo commit feito. Dessa forma não é necessario criar uma branch nova para pequenas modificações ou criar um commit com alterações não prontas. Posteriormente podemos escolher se iremos trazer de volta ou descartar essas alterações.

```bash
git stash
```

Guarda as alterações ainda não "commitadas" em um local temporário. Por exemplo pode ser utilizado para salvar alguma alteração antes de executar um git pull.

```bash
git stash list
```

Mostra a lista de todos os stash's criados.

```bash
git stash apply
```

Aplica as alterações do ultimo stash salvo no estado atual do repositório. Caso seja necessario trazer as alterações de um stash especifico, adicionamos o numero dele no final: `git stash apply 3`.

```bash
git stash pop
```

Muito parecido com o apply, porem além de aplicar as alterações do stash mais recente, ele remove o stash da lista.

```bash
git stash drop
```

Remove o ultimo stash da lista, pode também remover um stash especifico passando o numero do mesmo no final do comando: `git stash drop 4`.

```bash
git stash clear
```

Remove todos os stash's salvos.

&nbsp;

### Release

&nbsp;

---

```bash
git tag -a nome_da_tag -m "mensagem_aqui_dentro"
```

Adiciona uma tag no estado atual. Geralmente utilizado para indicar uma versão release do programa, e ao enviar essa tag para o GitHub por exemplo, temos uma aba especifica de Release do repositório onde sera mostrado todas as tags e os estados/commit dessas tags. É possível também baixar um arquivo compactado dessa versão do repositório.

---

&nbsp;

### Buscando por bugs com o Bisect

&nbsp;

O Bisect é uma poderosa ferramenta para buscar bugs, o usuário indica entre quais commits deve ser feita a pesquisa, então ele executa uma busca binaria com o intuito de encontrar o commit onde foi adicionado o bug.
> A busca funciona como um passeio, o git ira ficar mudando o estado do repositório, e cabe a nos indicar se o commit esta bom ou ruim a cada novo estado que o bisect nos apresenta, dependendo da quantidade de commits selecionados a busca encontrara rapidamente o bug.

```bash
git bisect start
```

O primeiro comando é o que ira iniciar o git bisect.

```bash
git bisect bad estado_ruim
```

O segundo comando é o que iremos informar o commit que esta ruim, podemos navegar até o commit com o git checkout e executar o comando `git bisect bad`, ou apenas informar o hash/tag/HEAD do commit: `git bisect bad HEAD`. Lembrando que o HEAD é o estado atual de trabalho.

```bash
git bisect good estado_bom
```

O terceiro comando é o que iremos informar o commit que esta bom. Possui as mesmas funcionalidades do segundo comando. `git checkout` -> `git bisect good` ou apenas `git bisect good 20b92f9`.

> Após executar o segundo e terceiro comando, começa a busca, onde iremos informar com `git bisect good` se o estado que ele entrou esta bom, e `git bisect bad` se o estado esta ruim. No final da busca ele ira mostrar os detalhes do commit que adicionou o bug. Então é só aplicar um `git revert` para desfazer o commit.

```bash
git bisect reset
```

Finaliza o comando bisect.

---

&nbsp;

## Comandos para inspecionar e analisar um repositório

&nbsp;

```bash
git status
```

Mostra quais arquivos foram alterados, se existe algum arquivo não monitorado, quantos commits ja foram executados nesse repositório.

---

```bash
git log
```

Mostra uma lista de commits desse repositório.
> Caso haja muitos commits, ele ira mostrar alguns por vez, com a tecla 'f' ele mostra mais commits, e a tecla 'q' sai desse modo.

- `git log --oneline`: mostra os commits em uma linha
- `git log -p`: mostra em detalhe as alterações que foram executadas
- `git log -S "pesquisa_aqui"`: faz uma pesquisa nos aquivos do repositório para encontrar dentro do código o que foi digitado no campo de pesquisa. Exemplo:
  - `git log -S "console.log"`: retorna os commits que possuem um arquivo com esse código.

É possível também formatar de maneira muito especifica o git log, exemplos:

- `git log --pretty="format:%H"` : mostra apenas o hash inteiro do commit
- `git log --pretty="format:%h %s"` : mostra apenas o hash resumido e a mensagem do commit
- `git log --pretty="format:%s %ae"` : mostra a mensagem e o email do altor do commit

---

```bash
git diff
git diff hash_1..hash_2
```

No primeiro código mostra de forma detalhada as alterações feitas que ainda não foram adicionadas e 'commitadas', e no segundo código mostra a diferença entre o primeiro commit e segundo commit selecionados.
> Um ótimo comando para verificar tudo o que já foi modificado e implementado até o estado atual do repositório. Obs: é preciso colocar os 2 pontos entre as hash's para funcionar o comando.

---

```bash
git config
```

Gerencia as configurações do git, pode ser utilizado para setar ou obter dados.

- `git config --global`: define o escopo global
- `git config --local`: define o escopo local, no repositório.
- `git config --local user.name "nome_do_usuário"`: define ou altera o nome de usuário no escopo local.
- `git config --global user.email "email"`: define ou altera o email do usuário no escopo global
- `git config author.name ""`
- `git config --local author.email ""`
- `git config committer.name ""`
- `git config committer.email ""`

É possível obter a informação omitindo a parte com as aspas. Exemplo:

- `git config local user.name`
- `git config --global author.email`

---

```bash
git blame nome_do_arquivo
```

Mostra quem foi o responsável por cada linha no arquivo indicado.
> O vscode possui uma extenção chamada "GitLens", que fornece essa funcionalidade dentre outras. Como funciona dentro do vscode, qualquer arquivo aberto que esta sendo monitorado pelo git, apresentara as funcionalidades do GitLens, facilitando muito a pesquisa dentro do repositório.
