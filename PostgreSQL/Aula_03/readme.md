# Aula 03: comandos DML e DDL

Majoritariamente nesta aula, utilizaremos a ferramente **pgAdmin**, e caso seja utilizado outra, sera informado.

## DDL e DML

A diferença entre os dois esta relacionada principalmente com a finalidade de cada um, pois a primeira vista pode parecer que os 2 possuem funcionalidades semelhantes e intercambiáveis. O que com uma breve leitura já é possível perceber a grande distinção entre os dois.

O *DML* (Data Manipulation Language) tem como intuito manipular e gerenciar os dados de dentro das tabelas. Sendo principais instruções o `SELECT`, `INSERT`, `UPDATE` e `DELETE`. As operações afetam os dados dentro das tabelas, mas não modificam a estrutura do banco de dados.

Já o *DDL* (Data Definition Language) lida com a criação, alteração e exclusão de estruturas de banco de dados. Sendo as principais instruções o `CREATE`, `ALTER` e `DROP`. Suas operações são utilizadas para definir a estrutura do banco de dados, como criar tabelas, alterar colunas, adicionar restrições, criar índices e outras operações relacionadas à modelagem do banco de dados.

Em resumo, compreender os 2 é essencial para melhorar o gerenciamento e manipulação dos dados e da estrutura do banco de dados, pois as operações de ambos se misturam no código, e é fácil se perder sobre o que cada um esta modificando.

## Funções PostgreSQL

Até o momento o que foi visto de SQL foram conteúdos mais genéricos, funcionando para qualquer banco de dados relacional. Porem agora veremos funções para manipular dados das tabelas, e isto varia para cada banco de dados, o que torna alguns mais viáveis que outros. Para acessar a documentação com todos os tipos de funções e operadores clique no link <a href="https://www.postgresql.org/docs/current/functions.html">PostgreSQL Functions and Operators</a>.

### Funções de String

Existem diversas funções para manipular valores do tipo string, veremos algumas delas, mas para acessar a lista completa, acesse o <a href="https://www.postgresql.org/docs/current/functions-string.html">Link</a>.

- || : concatena textos, caso alguns dos campos seja nulo, o resultado sera nulo. Exemplo: `'Jão' || ' ' || 'Silva'`.

- CONCAT() : concatena textos, valores nulos serão ignorados. Exemplo: `CONCAT('Jão', NULL, ' ', 'Silva')`.

- UPPER()/LOWER() : transforma o texto para maiúsculo ou minusculo.

- TRIM() : remove espaços no começo e final da string.

- CHAR_LENGTH() : calcula o comprimento em caracteres da string.

- BIT_LENGTH() : calcula o tamanho em bytes da string.

- POSITION(IN): pesquisa em qual posição começa os caracteres dentro da string. Exemplo: `POSITION ('GMAIL' IN 'A palavra GMAIL começa na posição')` -> 11.

- SUBSTRING( FROM FOR ) : seleciona um pedaço de texto dentro da string, cuja posição é informada através do *FROM* e do *FOR*. Caso informado apenas o *FROM*, seleciona a partir do valor até o final da string, e caso informado apenas o *FOR*, seleciona do começo da string até o valor escolhido. Exemplos:

```sql
SELECT SUBSTRING ('Lorem ipsum dolor sit amet.' FROM 4 FOR 12) -> em ipsum dol;
SELECT SUBSTRING ('Lorem ipsum dolor sit amet.' FROM 15) -> lor sit amet.;
SELECT SUBSTRING ('Lorem ipsum dolor sit amet.' FOR 9) -> Lorem ips;
```

### Funções de data

Grande parte das funções de data trabalham com **timestamp**, que nada mais é do que as informações de "ano-mês-dia hora:minutos:segundos.milissegundos". Apenas com esse campos ja é podemos extrair diversas informações, como nome do dia da semana, nome do mês, numero da semana do ano e varias outras, além de também ser possível somar ou subtrair 2 ou mais timestamp. Para ver a lista completa de funções de data, acesse o <a href="https://www.postgresql.org/docs/current/functions-datetime.html">Link</a>.

- NOW() : traz o timestamp atual. Exemplo: `NOW()::DATE` selecionamos o timestamp atual e convertemos para o tipo de data, onde sera informado apenas o ano/mês/dia.

- EXTRACT( FROM ) : extrai informações de um timestamp. Exemplo: `EXTRACT(year FROM NOW())`, `EXTRACT(week FROM '2001-02-16 20:38:40')`.

- TO_CHAR() : transforma um timestamp para um formato informado. Exemplo:

```sql
to_char(NOW(), 'DD/MM/YYYY')
to_char(NOW(), 'HH12:MI Month')
```

No primeiro exemplo é convertido para o formato de dia/mês/ano (que é o formato utilizado no Brasil), e no segundo exemplo é convertido para horas:minutos no formato de 12H e ao lado o nome do mês. Para ver a tabela completa com todos os tipos de formatos aceitos no *to_char* acesse o <a href="https://www.postgresql.org/docs/current/functions-formatting.html#FUNCTIONS-FORMATTING-DATETIME-TABLE">Link</a>.

- AGE() : a função *age* é utilizada para saber a idade de algo epenas informando uma data, trazendo como resultado quantos anos, meses e dias se passaram a partir da data. Exemplo:

```sql
SELECT nome,
    EXTRACT(year FROM AGE(data_nascimento)) AS Idade
  FROM pessoa;
```

O código acima calcula a idade de uma pessoa através do campo de data de nascimento. Utilizamos o *EXTRACT* pois somente a idade em anos era necessária.

### Funções matemáticas

AS funções matemáticas são as que mais se diferenciam entre banco de dados SQL, e o PostgreSQL possui diversas funções, desde uma simples função para arredondar números até funções para calcular pontos geográficos (o que certamente não estudaremos neste curso), além dos óbvios operadores matemáticos básicos. Para ter ver a lista completa acesse o <a href="https://www.postgresql.org/docs/current/functions-math.html">Link</a>.

- FLOR() / CEIL() / ROUND() : arredonda um numero para baixo, para cima e para o numero inteiro mais proximo respectivamente. Ex: `Flor(99.999) -> 99`, `ceil(-33.8) -> -33`, `Round(72.4) -> 72`.

- PI() : valor aproximado de pi com 15 casas decimais. Ex: `pi() -> 3.141592653589793`

- TRUNC() : seleciona apenas o numero inteiro, ou quantas casas decimais forem informadas. Ex: `trunc(89.34568) -> 89`, `Trunc(pi(), 4) -> 3.1415`.

- POWER(x, n) : calcula a potencia de X elevado a N. Ex: `power(3, 3) -> 27`, `power(2, 4) -> 16`.

- LOG() / LOG(base, num) : calcula o logarítmico de um valor na base 10 e um valor na base informada. Ex: `LOG(100) -> 2`, `log(2, 16) -> 4`;

- RANDOM() : retorna um valor aleatório de 0 a 1  com 15 casas decimais. Ex: `random() -> 0.28859140522409876`

## Nomeando consultas com VIEW

O *VIEW* é uma ferramenta do PostgreSQL que permite nomear consultas, armazenando estas como uma tabela virtual. Isto garante maior segurança, pois não é possível alterar ou inserir novos valores através de uma tabela virtual.

Alguns dos benefícios mais nítidos são:

- A possibilidade de encapsular consultas complexas, melhorando a legibilidade e facilitando a manutenção, pois basta alterar o *VIEW* que todas as consultas feitas com ele serão atualizadas.

- Nomear consultas em si, tornando as consultas frequentes muito mais rápidas.

- A segurança de trabalhar com tabelas virtuais, limitando o acesso de terceiro aos dados originais das tabelas.

A sintaxe para criar um *VIEW* e para efetuar a consulta é:

```sql
CREATE VIEW vw_nome_da_view AS query;

SELECT * FROM vw_nome_da_view;
```

> Por convenção, é utilizado o `vw` no inicio do nome de um VIEW.

Abaixo temos um exemplo, onde criamos uma query que seleciona todos os cursos da categoria 1 (Front-end).

```sql
CREATE VIEW vw_cursos_frontEnd
  AS SELECT curso.nome AS Cursos
  FROM curso
  WHERE categoria_id = 1;
```

É possível atualizar alguns parâmetros de um *VIEW* já criado com o *ALTER VIEW*, porem é bastante limitado. Para ver a documentação do *ALTER* acesse o <a href="https://www.postgresql.org/docs/current/sql-alterview.html">Link</a>. Abaixo temos um exemplo:

```sql
ALTER VIEW vw_cursos_frontEnd
RENAME Cursos TO "Nome dos cursos";
```

Assim como em uma consulta normal, temos a possibilidade de utilizar um filtro na busca com o *WHERE* e/ou juntar tabelas com o *JOIN*. Em contra ponto temos uma perda de performance, pois efetuamos uma busca com o *VIEW*, e ao final é efetuado uma nova busca para o *WHERE* / *JOIN*.

```sql
SELECT * FROM vw_cursos_frontEnd
  WHERE "Nome dos cursos" LIKE 'J%';

SELECT  categoria.id AS Categoria_id,
        vw_cursos_por_categoria.*
  FROM vw_cursos_por_categoria
  JOIN categoria ON categoria.nome = vw_cursos_por_categoria.categoria;
-- Uma consulta por nome como é feito acima, é mais custosa do que por ID por exemplo.
```

## SCHEMA

Um schema é uma estrutura que permite organizar e agrupar objetos do banco de dados, como tabelas, views, funções e outros objetos relacionados, utilizando namespaces lógicos que facilitem a compreensão da desta estrutura. Um database pode conter diversos Schemas, e cada Schema pode conter diversas tabelas (ou objetos de banco de dados), o que permite que haja tabelas com o mesmo nome em schemas diferentes sem haver conflito. É possível relacionar tabelas de schemas diferentes e também preencher uma tabela com dados de outra tabela em outro schema.

Como visto em outra aula, todo objeto de banco de dados precisa ser associado à um Schema. Logo, ao criar um objeto sem informar qual schema ele pertencerá, implicitamente ele sera associado ao schema padrão do PostgreSQL, que é o *public*.

Temos a seguinte sintaxe para criar um novo Schema e para excluir um Schema existente respectivamente:

```sql
CREATE SCHEMA nome_Schema;

DROP SCHEMA nome_Schema;
```

Agora para utilizar este novo Schema, será necessario informa-lo sempre que for trabalhar com um objeto que pertence a este schema. Abaixo temos alguns exemplos:

```sql
CREATE TABLE academico.pessoa_curso(
  pessoa_id INTEGER NOT NULL REFERENCES academico.pessoa(id),
  curso_id INTEGER NOT NULL REFERENCES academico.curso(id),
  PRIMARY KEY (pessoa_id, curso_id)
);

DROP TABLE academico.pessoa_curso;

SELECT * FROM academico.pessoa;
```

## ALTER TABLE

O comando *ALTER TABLE* tem como intuito alterar o objeto tabela, e assim como o comando *CREATE TABLE*, ele possui uma enormidade de parâmetros que podem ser utilizados para atualizar a tabela. Acesse a documentação através do <a href="https://www.postgresql.org/docs/current/sql-altertable.html">Link</a>. Abaixo teremos alguns exemplos de sua utilização:

- Alterando o nome da tabela, mudando o schema que a tabela pertence e renomeando a coluna respectivamente:

```sql
ALTER TABLE academico.nova_tabela RENAME TO aluno_formado;
ALTER TABLE academico.aluno_formado SET SCHEMA formado;
ALTER TABLE formado.aluno_formado RENAME nome TO nome_completo;
```

- Adicionando uma coluna, removendo uma coluna e alterando o tipo da coluna respectivamente:

```sql
ALTER TABLE formado.aluno_formado ADD COLUMN campo_teste INTEGER;
ALTER TABLE formado.aluno_formado ALTER COLUMN nome_completo TYPE VARCHAR(315);
ALTER TABLE formado.aluno_formado DROP COLUMN campo_teste;
```

Ao criar uma nova coluna em uma tabela que ja possuí dados inseridos, a coluna por inteiro tera o valor *NULL*. Logo para este caso, não é possível criar essa nova coluna com a restrição *NOT NULL*.

- Criando uma nova coluna do tipo inteiro e com restrição *não nulo* em uma tabela que ainda não possui linhas:

```sql
ALTER TABLE formado.aluno_formado 
  ADD COLUMN matricula INTEGER,
  ALTER COLUMN matricula SET NOT NULL;
```

Caso seja necessario criar um campo *não nulo* em uma tabela que ja possua informação, podemos criar o campo sem a restrição e atualizar todos os valores nulos, para depois então adicionar a restrição.

- Adicionando uma chave estrangeira para a coluna criada acima:

```sql
ALTER TABLE formado.aluno_formado 
  ADD CONSTRAINT restricao_matricula 
  FOREIGN KEY (matricula) REFERENCES academico.formado (id);
```

> Pelo que pude entender do *ADD CONSTRAINT*, é necessario adicionar um nome para a restrição, ao qual no exemplo acima é *restricao_matricula*.

## Adicionando dados através de uma query

Com SQL podemos utilizar uma consulta em uma tabela para preencher outra tabela com esses dados. É preciso se atentar ao fato de que os tipos tem que ser iguais, e a ondem dos campos precisam ser as mesmas.

Suponhamos o exemplo onde seja necessario guardar as informações de 2 colunas de uma tabela, podemos então criar uma tabela temporária e adicionar os dados necessários. Vejamos:

```sql
CREATE TEMPORARY TABLE cursos_programacao(
  id_curso INTEGER PRIMARY KEY,
  nome_curso VARCHAR(255) NOT NULL
);

INSERT INTO cursos_programacao
SELECT curso.id, curso.nome FROM academico.curso
  JOIN academico.categoria ON categoria.id = curso.categoria_id
  WHERE curso.categoria_id = 2
```

> O Schema precisa ser informado quando estamos referenciando a tabela em si, onde estamos selecionando a coluna, basta o nome da tabela junto com o nome da coluna.

No exemplo acima, inserimos dados na tabela *cursos_programacao* com o comando `INSERT INTO` normalmente, porem substituímos o *VALUES* pela query.

## Atualizando dados através de outra tabela

Semelhante com a função acima, também podemos atualizar dados de uma tabela com os dados de outra tabela. Temos a sintaxe:

```sql
UPDATE tabela1 SET campo_tabela1 = campo_tabela2
  FROM tabela2 WHERE condição;
```

O *campo_tabela1* é a coluna que recebera os dados, e o *campo_tabela2* é a coluna de onde os dados serão copiados.

Abaixo temos um exemplo onde é atualizado a coluna *nome* da tabela *cursos* através da coluna *nome_cursos* da tabela *cursos_basicos*.

```sql
UPDATE formado.cursos SET nome = nome_cursos
  FROM formado.cursos_basicos WHERE cursos.id = cursos_basicos.id;
```

Mesmo não havendo referencia com uma chave estrangeira entre as tabelas, ainda sim podemos criar uma condição onde o *id* da tabela *cursos* seja igual ao *id* da tabela *cursos_basicos*. Com isso, na linha que o *id* coincidir, devera ser atualizado o campo *nome* com os dados do campo *nome_cursos*.

## Deletando dados através de outra tabela

Com o *DELETE* a sintaxe é um pouco diferente, vejamos:

```sql
DELETE FROM tabela1
  USING tabela2
  WHERE condição;
```

Suponhamos uma loja de material de construção que queira remover do catalogo todos os parafusos *philips* de uma marca X. Temos então a tabela *catalogo* com todos os produtos vendidos, e a tabela *marcaX* contendo todos os produtos da marca x. Podemos executar o comando:

```sql
DELETE FROM catalogo
  USING marcaX
  WHERE catalogo.produto_id = marcaX.id
  AND marcaX.nome LIKE 'philips%';
```

Com o comando acima, removemos do catalogo todos os produtos da marca X que comessem com o nome *'philips'*.

## Dicas de segurança

Devido a grande possibilidade de haver enganos com o nome do campo digitado, ou o filtro de busca, se recomenda como boa pratica **realizar um SELECT antes de efetuar um DELETE ou um UPDATE**. Ou seja, evitar escrever diretamente uma operação tão arriscada como o DELETE sem antes testar, e acabar descobrindo algum erro somente apos executar o comando. Por isso crie um SELECT como se estivesse efetuando um DELETE, e após confirmar que era o campo desejado, substitua o código. Por exemplo:

```sql
SELECT nome FROM formado.cursos WHERE id = 7;

DELETE FROM formado.cursos WHERE id = 7;
```

Conferido que o a linha desejada é mesmo a de id igual a 7, então basta substituir o SELECT pelo DELETE.

## Transações ACID

Uma transação no PostgreSQL, é uma sequência de operações de banco de dados que são tratadas como uma unidade lógica e indivisível. Uma transação garante que um conjunto de operações seja executado com sucesso e de forma consistente, mantendo a integridade dos dados.

O conceito de transações no PostgreSQL é baseado nas propriedades ACID, que são:

- Atomicidade (Atomicity): uma transação é tratada como um átomo indivisível, ou seja, os comando ou serão executados todos, ou não serão executados nenhum, e caso ocorra algum erro durante a execução da transação, todas as alterações serão desfeitas em um processo chamado rollback.

- Consistência (Consistency): uma transação garante que o banco de dados esteja em um estado consistente antes e após sua execução. Isso significa que todas as restrições e regras de integridade definidas no esquema do banco de dados devem ser obedecidas durante a transação.

- Isolamento (Isolation): a propriedade de isolamento garante que os efeitos de uma transação em execução sejam invisíveis para outras transações concorrentes até que a transação seja concluída ("comitada"). Isso evita que alterações parciais ou inconsistentes sejam vistas por outras transações.

- Durabilidade (Durability): após o término de uma transação bem-sucedida (commit), todas as alterações feitas durante a transação são permanentes e persistirão, mesmo em caso de falha do sistema ou reinicialização do banco de dados. As alterações são gravadas de forma durável nos meios de armazenamento.

O PostgreSQL cria transações implicitamente em diversas operações, porém é possível criar transações de maneira manual. Para esta tarefa temos os seguintes comando

- `BEGIN`: é utilizado para iniciar uma transação no PostgreSQL. Após o início da transação, todas as operações subsequentes são tratadas como parte desta transação até que seja emitido um comando COMMIT ou ROLLBACK.

- `COMMIT`: é usado para confirmar as alterações feitas dentro de uma transação e torná-las permanentes no banco de dados. Após o COMMIT, as alterações se tornam visíveis para outras transações.

- `ROLLBACK`: serve para desfazer as alterações feitas dentro de uma transação e cancelar a transação. Restaura o banco de dados ao estado anterior à transação.

Vejamos os exemplos abaixo:

```sql
BEGIN;
DELETE FROM formado.cursos_basicos WHERE id = 8;
COMMIT;

BEGIN;
UPDATE formado.cursos SET nome = 'TypeScript intermediário'
  WHERE id = 4;
ROLLBACK;
```

Toda transação começa com o BEGIN, então executamos os comandos desejados, e caso tudo ocorra corretamente, efetuamos um COMMIT, caso não um ROLLBACK.

## Importando e exportando dados de uma tabela

Iremos ver como importar e exportar dados através da ferramenta *pgAdmin* e posteriormente veremos o comando que pode ser executado no *SQL Shell*. Os tipos de arquivos aceitos nas duas operações são o **CSV**, **binário** e **texto**. Começaremos com a exportação, e abaixo temos a descrição detalhada da operação.

Para importar/exportar informações, primeiro é necessario selecionar uma tabela para executar a operação. No *pgAdmin* na aba da esquerda temos o banco de dados, e ao selecionar um database temos dentro dele os objetos do banco de dados, sendo uma dessas opção a **Schema**, que armazena os objetos relacionados à tabela, e uma das ultimas opções é a **Tables**, que armazena todas as tabelas do schema. Ao clicar com o botão direito do mouse em cima de uma tabela, sera aberto uma caixa de dialogo com diversas opções, e dentre elas a opção **Import/Export Data**, e ao clicar nesta opção a janela para as duas operações sera aberta.

> Caso o caminho do PostgreSQL no *pgAdmin* ainda não tenha sido selecionado nas preferencias, pode ocorrer o erro de `Binary Path`. Na mesma pasta deste documento temos o arquivo com a solução para esse problema.

Na primeira tabPage **General**, temos as opções:

- `Import/Export` : seleciona qual a operação desejada.
- `Filename` : caminho onde sera exportado ou importado o arquivo.
- `Format` : seleciona o formato para operação, sendo o mais comum o **CSV**.
- `Encoding` : seleciona o tipo de codificação do texto, o padrão sendo **UTF-8**.

Na segunda tabPage **Options**, temos as opções:

- `OID` : o "Object Identifier Types" é utilizado internamente pelo PostgreSQL, são tipos de dados especiais que representam identificadores de objetos no banco de dados, como chaves primarias.
- `Header` : indica se a primeira linha é um cabeçalho.
- `Delimiter` : caractere que separa os valores. Por padrão é a virgula.
- `Quote` : delimitador do campo. Por padrão é aspas duplas.

Na terceira tabPage **Columns**, temos a opção:

- `Columns to export` : mostra as colunas que serão exportadas.

Após conferir todos os parâmetros, basta clicar em **Ok** para confirmar a operação.

Agora veremos os códigos para executar as operações no *SQL Shell*, que também é o mesmo código que o *pgAdmin* rodou por baixo dos panos:

```sql
--Export
COPY formado.export_cursos (id, nome) 
  TO 'C:/Users/User/Desktop/CURSO_~1/Alura/POSTGR~1/Aula_03/EXPORT~1.CSV'
  DELIMITER ',' CSV ENCODING 'UTF8' QUOTE '\"' ESCAPE '''';""

--Import
copy formado.export_cursos (id, nome) 
  FROM 'C:/Users/Cesar/Desktop/CURSO_~1/Alura/POSTGR~1/Aula_03/EXPORT~1.CSV'
  DELIMITER ',' CSV HEADER ENCODING 'UTF8' QUOTE '\"' ESCAPE '''';""
```

> Como visto nos códigos acima, é muito mais simples efetuar as mesmas tarefas pela ferramenta *pgAdmin*, com todos os parâmetros já visíveis na janela.

## Sequencias

O PostgreSQL possui um objeto chamado *SEQUENCE*, que gera valores numéricos sequenciais. Já vimos anteriormente o tipo SERIAL que pode ser utilizado em uma coluna, este tipo é uma sequencia também. Porém podemos criar uma sequencia manualmente utilizando o comando `CREATE SEQUENCE`. Ele possui alguns parâmetros na sua criação, para acessar a documentação clique no <a href="https://www.postgresql.org/docs/current/sql-createsequence.html">Link</a>. Vejamos a sintaxe:

```sql
CREATE SEQUENCE nome_sequencia;
```

Para manipular esta sequencia temos 3 principais métodos (<a href="https://www.postgresql.org/docs/current/functions-sequence.html">Sequence Manipulation Functions</a>), vejamos abaixo:

- `NEXTVAL(name)` : avança a sequencia para o proximo valor e retorna esse valor.

- `CURRVAL(name)` : retorna o valor atual da sequencia.

- `SETVAL(name, value)` : seta um valor para a sequencia.

```sql
CREATE SEQUENCE sequencia;

SELECT NEXTVAL('sequencia') -> 1
SELECT CURRVAL('sequencia') -> 1
SELECT SETVAL('sequencia', 13)
SELECT NEXTVAL('sequencia') -> 14
```

> O nome dentro do método precisa estar entre aspas simples.

Agora vejamos um exemplo:

```sql
CREATE SEQUENCE sequencia_id;

DROP TABLE auto_s;
CREATE TABLE auto_s(
  id INTEGER PRIMARY KEY DEFAULT NEXTVAL('sequencia_id'),
  nome VARCHAR(255) NOT NULL
);
```

O parâmetro *DEFAULT* define para o campo que caso não seja informando um valor, então por padrão sera o proximo valor da sequencia, que é definido pelo *NEXTVAL*.

### Quebrando a sequencia

Quando estamos trabalhando com sequencias em uma coluna de uma tabela, é preciso se atentar ao fato de ser possível quebrar essa sequencia (o mesmo vale para o SERIAL). Para compreender melhor esse problema, criaremos um exemplo baseado na tabela criada acima:

```sql
INSERT INTO auto_s(nome) VALUES('Jão');
INSERT INTO auto_s(id, nome) VALUES(2, 'Jenfiner');
INSERT INTO auto_s(nome) VALUES('Lusca');
```

O problema ocorre, por que na segunda linha adicionamos explicitamente um valor para o *id*, com isso a sequencia não avança com o *NEXTVAL*. Então na terceira linha tentamos adicionar um novo valor sem informar o *id*, a sequencia avança e tenta adicionar uma linha com o "id = 2", porem ele ja existe, então o comando gera um erro e não conseguimos adicionar um valor. Somente se for tentando outra vez é que sera adicionado a nova linha.

## Criando tipos

Até o momento definimos o tipo de uma coluna diretamente na sua declaração, o que serve para grande parte dos casos. Porem podemos criar um tipo com todas as características desejadas e apos definir o campo com sendo deste tipo. Isso pode ser muito util por exemplo quando é necessario repetir em varias tabelas um mesmo tipo, mas existe outras utilidades para o `CREATE TYPE`, e para acessar a documentação acesse o <a href="https://www.postgresql.org/docs/current/sql-createtype.html">Link</a>. Agora vejamos um exemplo:

```sql
CREATE TYPE tp_status AS ENUM ('open', 'closed', 'new');

CREATE TABLE pull_request(
  id SERIAL PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  status tp_status
);

INSERT INTO pull_request(title, status) 
  VALUES('Integrating Google Sign-In', 'closed');
INSERT INTO pull_request(title, status) 
  VALUES('error google sign-In', 'new pull');
```

O exemplo acima cria um tipo chamado *tp_status* que é um ENUM, então aplica este tipo no campo *status* da mesma forma que outros tipo como SERIAL ou VARCHAR. Apos a criação da tabela, tentamos inserir dados 2 vezes, a primeira bem sucedida, e a segunda com um erro no campo *status*, pois "new pull" não esta incluso nos valores definidor no tipo ENUM.
