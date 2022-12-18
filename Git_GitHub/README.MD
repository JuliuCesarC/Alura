# Comandos básicos para criar e gerenciar um repositório.

#### Os comando podem ser executados em diversos tipos de terminais, porém nesse curso utilizamos o Git Bash.

- git init
  Cria um repositório local. Ao entrar na pasta desejada podemos executar esse comando para iniciar o repositório. - --bare: define um repositório puro, que só tem como função guardar as alterações executadas, e não propriamente possuindo uma cópia dos arquivos.

- git add nome_do_arquivo
- git add .
  Adiciona um item na lista de monitoramento do git, o 'add .' adiciona todos os arquivos da pasta nesta lista.

- git commit -m "mensagem_aqui_dentro"
  Faz uma atualização das alteração dos arquivos que o git esta monitorando. O commit é muito associado a um check point, onde é possível voltar a aquele ponto, ou relembrar o que foi alterado nesse commit. É preciso adicionar uma mensagem em cada commit, por isso o parâmetro -m.

- git remote
  Lista todos os repositórios remotos na pasta. - add nome_do_remoto caminho_para_repositório: adiciona um repositório remoto, o caminho pode ser uma pasta, uma url, um repositório GitHub. exemplo: - "add repoLocal C:\Users\Cesar\Desktop\Curso_Dev" - rename nome_atual novo_nome: renomeia o repositório remoto.

- git clone endereço_do_repositório
  Clona o repositório escolhido criando uma nova pasta com todos os arquivos dele. O nome da pasta pode ser alterado adicionando o novo nome no final do comando. exemplo: - "git clone /c/Users/Cesar/Desktop/Curso_Dev/Git_GitHub/server/ server_ana"

- git push repositório_remoto nome_da_branch
  Envia o conteúdo de um repositório local para um repositório remoto. exemplo: 
  - "git push origin master"
  - git push repositório_remoto --delete nome_da_branch: deleta uma branch remota.

- git pull repositório_remoto nome_da_branch_do_remoto
  Traz o conteúdo de um repositório remoto para o repositório local, lembrando que o nome da branch selecionada é o da branch setada no repositório remoto. Na maioria daz vezes o nome da branch do GitHub é 'main', enquanto a do repo local é 'master'. exemplo: - "git pull servidor_ana master"

- git branch
  Lista todos as branch do projeto. - git branch nome_nova_branch: cria uma nova branch. É possível criar uma nova branch e ja entrar nela com o código abaixo. - "git checkout -b nome_nova_branch" : o '-b' é o responsável por criar a branch.

#### Quando criamos uma nova branch e trabalhamos dentro dela, garantimos que o conteúdo da branch original não seja alterado, dessa forma caso as novas alterações não funcionem, podemos simplesmente descartar esse branch, porém caso seja necessário implementar essas alterações, então precisamos efetuar um 'merge'.

  - git branch -m novo_nome_da_branch: renomear a branch.

  - git branch -d/-D nome_da_branch: deleta uma branch local

- git checkout
Utilizado para navegar entre estados no repositório. Podemos utilizar para alternar entre as branchs, para voltar a um estado anterior das modificações entre outros.
  - git checkout nome_da_branch: alterna entre as branchs

- git merge
Junta uma branch selecionada com a branch atual. Caso haja algum conflito entre as branch, o Vscode ira mostrar onde os códigos se conflitaram, basta remover um dos 2 códigos e prosseguir com um commit. Preserva os commits da branch principal e da branch secundaria, isso significa e ouve uma bifurcação quando a branch secundaria foi criada, e uma intersecção quando houve um 'merge', mas os 2 caminhos continuam no histórico.

- git rebase
Mescla 2 branchs, diferentemente do 'merge', não preserva o caminho das branchs, ou seja, ira colocar no final da branch principal todos os commits da branch secundaria, essa forma ficando apenas um caminho, aparentemente nunca havendo uma bifurcação. Existe alguns problemas de rastreabilidade e segurança com esse método, por isso é preciso saber quando utilizar.

#### Como desfazer alterações:

- git checkout -- nome_do_arquivo
Caso não tenha adicionado as alterações no git add, podemos descartar as alterações no arquivo selecionado utilizando  'checkout'.
- git reset HEAD nome_do_arquivo
Caso as alterações tenham sido adicionadas com o git add, porém ainda não tenha sido feito o commit, podemos remover esses arquivos do git add com o comando 'reset'.
- git revert hash_do_commit
Reverte o commit selecionado. É preciso utilizar a hash inteiro do commit, e não a versão resumida. Não remove o commit do historio, apenas reverte as alterações e adiciona um commit informando o revert.

## Comandos para inspecionar e analisar um repositório.

- git status
  Mostra quais arquivos foram alterados, se existe algum arquivo não monitorado, quantos commits ja foram executados nesse repositório.

- git log
  Mostra uma lista de commits desse repositório. Caso haja muitos commits ele ira mostrar alguns por vez, com a tecla 'f' ele mostra mais commits, e a tecla 'q' sai desse modo. O git log possui diversos parâmetros, dentre eles - --oneline: mostra os commits em uma linha - -p: mostra em detalhe as alterações que foram executadas - -S "pesquisa_aqui": faz uma pesquisa nos aquivos do repositório para encontrar dentro do código o que foi digitado no campo de pesquisa. Exe: -S "console.log", retorna os commits que possuem um arquivo com esse código. - é possível formatar de maneira muito especifica como o comando abaixo. - --pretty="format:%H" : mostra apenas o hash do commit - --pretty="format:%h %s" : mostra apenas o hash resumido e a mensagem do commit - --pretty="format:%s %ae" : mostra a mensagem e o email do altor do commit

- git config
  Gerencia as configurações do git, pode ser utilizado para setar ou obter dados. - Definindo escopo - --global: define o escopo global - --local: define o escopo local, no repositório - Configuração - user.name "nome_do_usuário": define ou altera o nome de usuário - user.email "email": define ou altera o email - author.name "" - author.email "" - committer.name "" - committer.email "" - é possível obter a informação omitindo a parte com as aspas.
