# Formação em SQL com PostgreSQL

## Tipos de dados

O PostgreSQL possui diversos tipos de dados que serão armazenados, tipos numéricos, tipos de caracteres, datas, entre outros. Para ver com detalhe todos os tipos de dados acessar o link <a href="https://www.postgresql.org/docs/current/datatype.html">PostgreSQL data types</a>.

Para este documento veremos apenas os mais comuns.

### Tipos numéricos

- **integer**: armazena números inteiros de `-2.147.483.648` até `+2.147.483.647`.
- **real**: armazena números com casas decimais com até 6 dígitos de precisão.
- **serial**: utilizado para criar uma coluna autoincrementável, somando +1 toda vez que é incluído, não sendo necessario passar nenhum numero. Armazena do numero `1` ao `2.147.483.647`.

> Pode ser utilizado para criar uma coluna de *id*.

- **numeric(precision, scale)**: armazena números com alta precisão. O primeiro parâmetro é a quantidade de dígitos do campo, e o segundo é a quantidade de dígitos após a ponto decimal.

Um exemplo para o numeric é o saldo de uma conta bancaria, podemos criar o campo:

```sql
saldo NUMERIC(10, 2)
```

É possível armazenar valores com 8 dígitos antes e 2 dígitos após o ponto decimal.

### Tipos de caracteres

- **varchar(n)**: armazena um texto que pode conter no máximo **n** caracteres.

> Um exemplo para o varchar é um campo de nome, onde podemos passar como parâmetro o valor 255, limitando assim o comprimento máximo do texto em 255 caracteres.

- **char(n)**: armazena um texto com um tamanho especifico de caracteres. Caso não seja informado a quantidade correta, sera preenchido com espaços em branco.

> Para criar um campo de CPF por exemplo, podemos utilizar `char(11)`.

- **text**: armazena um texto com até 1GB de tamanho.

### Tipo Booliano

- **boolean**: armazena um dado binário verdadeiro ou falso.

### Tipos data/hora

- **date**: armazena datas no formato *yyyy-mm-dd*, sendo respectivamente ano, mês e dia.
- **time**: armazena horários no formato *hh:mm:ss*, sendo respectivamente horas, minutos e segundos.
- **timestamp**: armazena data e hora no formato *yyyy-mm-dd hh:mm:ss*.

## Operadores lógicos

Assim como em uma linguagem de programação temos os operadores lógicos, no SQL também temos, sendo alguns deles:

- `>`: maior que
- `<`: menor que
- `=`: igual a
- `>=`: maior igual
- `<=`: menor igual
- `!=` ou `<>`: diferente de

### Operadores específicos do SQL

O SQL possui alguns operadores específicos, como os 3 que veremos abaixo.

> Todos os 3 operadores podem ser utilizados junto com o `NOT`, dessa forma invertendo a logica. Ex: `NOT LIKE`.

- `BETWEEN`: retorna true caso o valor informado ou buscado esteja entre as condições informadas.

Abaixo temos um exemplo, onde é selecionado todas as colunas das linhas que estão entre a data informada.

```sql
SELECT * FROM aluno 
  WHERE matriculado_em BETWEEN '2022-01-01' AND '2022-12-31';
```

- `IN`: retorna true caso o valor informado ou buscado seja uma das condições informadas.

Abaixo temos um exemplo, onde é selecionado todas as colunas das linhas que tenham o *id* igual aos valores informados.

```sql
SELECT * FROM aluno WHERE id IN (1, 3, 5, 7, 9);
```

- `LIKE`: retorna true caso o valor informado ou buscado esteja dentro do padrão de texto informado.
  - `%`: caractere especial que corresponde a qualquer número de caracteres.
  - `_`: caractere especial que corresponde a um único caractere.

Abaixo temos um exemplo, que seleciona todos as colunas das linhas que possuam um email que termine com *gmail.com*.

```sql
SELECT * FROM aluno WHERE email LIKE '%gmail.com';
```

Agora um exemplo que seleciona todos os professores que tenham no campo materia um texto que se encaixe no padrão, podendo ser "Matemática" com ou sem acento, e começando ou não com letra maiúscula.

```sql
SELECT * FROM professor WHERE materia LIKE '_atem_tica';
```

> O operador **LIKE** pode ser utilizado para um campo de busca, escapando do camelCase caso o texto digitado não seja especificamente igual.

### Operadores AND e OR

Esses 2 operadores servem para criar múltiplas condições, sendo utilizados junto com os outros operadores. Por exemplo:

```sql
SELECT * FROM aluno 
  WHERE nome LIKE 'J%'
  AND cpf IS NOT NULL
  OR idade >= 25;
```

O exemplo acima seleciona todos os alunos que tenham um nome que comece com a letra *J* **E** tenham o campo de *cpf* não sendo nulo, **OU** apenas que tenham idade maior ou igual a 25.

## Criando um database

Primeiramente selecionamos o servidor com o comando `SELECT NOW();`, e então utilizamos o:

```sql
CREATE DATABASE nome_do_database;
```

É possível também passar outros parâmetros ao criar o database, por exemplo abaixo:

```sql
CREATE DATABASE nome_do_database
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;
```

Ao remover o ponto e virgula do final da primeira linha de código, podemos apertar o *ENTER* para ir para proxima linha, assim sendo possíveis digitar todos os parâmetros sucessivamente. Na ultima linha de código basta adicionar novamente o ponto e virgula para finalizar o comando.

### Removendo um database

```sql
DROP DATABASE nome_do_database;
```

### Visualizando os databases

Para visualizar todos os bancos de dados, podemos utilizar o:

```sql
\l
```

## Criando um tabela

Criaremos uma tabela simulando as informações de um aluno. Para criar uma tabela, utilizaremos o código abaixo:

```sql
CREATE TABLE aluno(
  id SERIAL,
  nome VARCHAR(255),
  data_nascimento DATE,
  idade INTEGER,
  cpf CHAR(11),
  altura real,
  observacao TEXT,
  notas_acumuladas NUMERIC(10,2),
  ativo BOOLEAN,
  horario_aulas TIME,
  matriculado_em timestamp
);
```

## Inserindo dados na tabela

Agora para inserir dados na tabela **aluno** utilizaremos o código abaixo:

```sql
INSERT INTO aluno(
  nome,
  data_nascimento,
  idade,
  cpf,
  altura,
  observacao,
  notas_acumuladas,
  ativo,
  horario_aulas,
  matriculado_em
)
VALUES (
  'Jão da Silva',
  '1999-04-08',
  24,
  '11111111111',
  1.68,
  'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi tempus orci eu auctor congue. Phasellus eu auctor turpis. Mauris pharetra convallis diam, vel malesuada dolor mattis quis. Donec egestas leo ac quam tempus volutpat. Phasellus sollicitudin interdum quam et vestibulum.',
  1785,
  TRUE,
  '7:10:00',
  '2022-01-15 15:35:37'
);
```

O comando `INSERT INTO` adiciona os dados na tabela, e comumente veremos primeiro sendo descrito os campos, e depois os valores. Mas é possível omitir os campos e adicionar apenas o valores, como em:

```sql
INSERT INTO aluno VALUES( ... );
```

## Atualizando os campos

Para atualizar os dados, utilizaremos o comando `UPDATE`. Com ele podemos alterar os campos de apenas uma linha, ou de toda a tabela.

```sql
UPDATE aluno
  SET nome = 'Jão Abreu da Silva',
  cpf = '44455226756',
  observacao = 'Phasellus sollicitudin interdum quam et vestibulum. Pellentesque ligula odio, rhoncus eget imperdiet et.',
  notas_acumuladas = 1821
  WHERE id = 1;
```

O código acima atualiza apenas as colunas desejadas do aluno cujo o *id* é igual a 1.

Podemos também alterar as colunas de toda a tabela omitindo o `WHERE`, como abaixo:

```sql
UPDATE aluno
  SET
  observacao = 'Todos devem ter esta observação.';
```

> Lembrando que não é muito indicado alterar toda a tabela, pois isso pode acarretar em alguns problemas caso ocorra algum engano.

## Deletando uma linha/tabela

Utilizaremos o comando `DELETE` para excluir uma linha da tabela ou até mesmo a tabela.

```sql
DELETE FROM aluno
  WHERE nome = 'Roberto';
```

Deletamos o *aluno* cujo nome é *Roberto*. Para remover a tabela, basta digitar a primeira linha de código.

```sql
DELETE FROM aluno
-- Remove a tabela.
```

## Filtros e seleção dados na tabela

Selecionando todos os campos e todas as linhas da tabela.

```sql
SELECT * FROM aluno;
```

Selecionando apenas o campo *nome* de todas as linhas da tabela.

```sql
SELECT nome FROM aluno;
```

Selecionando múltiplos campos.

```sql
SELECT nome AS "Nome do aluno",
  data_nascimento AS "Data de nascimento",
  ativo
  FROM aluno
```

> O comando `AS` serve para alterar o nome do campo. Caso o nome tenha espaços em branco é preciso utilizar as aspas duplas "".

### WHERE

Com o *WHERE* podemos selecionar linhas especificas que atendam à uma condição.

Podemos utilizar os operadores lógicos visto anteriormente para criar uma condição, alguns exemplos são:

Selecionando todos os campos das linhas que tenham na coluna *idade* um valor maior ou igual a 25.

```sql
SELECT * FROM aluno WHERE idade >= 25;
```

Seleciona todos os campos das linhas que não tenham na coluna *cpf* um valor nulo.

```sql
SELECT * FROM aluno WHERE cpf IS NOT NULL;
```

Selecionando múltiplos campos das linhas que tenham na coluna *nome*  qualquer nome que termine com *da Silva* por exemplo.

```sql
SELECT nome AS "Nome do aluno",
  data_nascimento AS "Data de nascimento",
  ativo
  FROM aluno
  WHERE nome LIKE '% da _ilva';
```

## PRIMARY KEY

O PRIMARY KEY é um campo (ou conjunto de campos) que possuem um identificador único para cada registro em uma tabela, permitindo que eles sejam identificados de forma precisa e inequívoca.

Podemos criar um campo semelhante utilizando os comando `NOT NULL UNIQUE` como no código abaixo:

```sql
CREATE TABLE curso(
  id INTEGER NOT NULL UNIQUE,
  nome VARCHAR(255) NOT NULL
);
```

Porem o correto é utilizar o *primary key*:

```sql
CREATE TABLE curso(
  id INTEGER PRIMARY KEY,
  nome VARCHAR(255) NOT NULL
);
```

Podemos também criar um conjunto de campos utilizando o comando abaixo:

```sql
CREATE TABLE aluno_curso(
  aluno_id INTEGER,
  curso_id INTEGER,
  PRIMARY KEY (aluno_id, curso_id)
)
```

## FOREIGN KEY

Quando criamos referencias entre tabelas é possível que ocorra algumas inconsistências, por exemplo, cadastrar na tabela filha um ID que não existe na tabela pai. Então utilizamos uma chave estrangeira para garantir integridade da referencia de dados. Além disso, não é possível excluir o valor da tabela pai sem antes excluir os registros que o referenciam na tabela filha. A FOREIGN KEY pode ser um campo ou conjunto de campos.

A sintaxe básica dessa chave é:

```sql
FOREIGN KEY (campo_tabela_filha) REFERENCES tabela_pai (campo_tabela_pai);
```

E abaixo temos um exemplo:

```sql
CREATE TABLE aluno_curso(
  aluno_id INTEGER,
  curso_id INTEGER,
  PRIMARY KEY (aluno_id, curso_id),

  FOREIGN KEY (aluno_id)
  REFERENCES aluno (id),
  FOREIGN KEY (curso_id)
  REFERENCES curso (id)
);
```

Criamos uma referencia do campo *id* da tabela *aluno* para o campo *aluno_id* da tabela *aluno_curso*, e o mesmo para o *curso_id*.

## JOIN ON

O JOIN permite juntar dados de duas ou mais tabelas relacionadas em uma unica consulta.

A sintaxe básica é:

```sql
JOIN tabela_relacionada ON campo_tabela_relacionada = campo_tabela_referencia;
```

> A ordem do campo da tabela relacionada ou da tabela referencia não importa, ou seja, quem vem antes ou depois do sinal de igual não difere na consulta.

Suponhamos que temos 3 tabelas, a *aluno*, *curso* e *aluno_curso* que relaciona o aluno com o curso, e, precisamos resgatar o campo do nome do aluno e o nome do curso. Para realizar esta consulta precisamos passar obrigatoriamente pela tabela *aluno_curso*, temos o código abaixo:

```sql
SELECT * 
  FROM aluno
  JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  JOIN curso ON curso.id = aluno_curso.curso_id;
```

A consulta realizada acima trará todos os campos das 3 tabelas, porem precisamos apenas dos 2 campos mencionados anteriormente, então podemos resolver da seguinte forma:

```sql
SELECT aluno.nome AS "Nome do aluno",
       curso.nome AS "Nome do Curso"
  FROM aluno
  JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  JOIN curso       ON curso.id             = aluno_curso.curso_id;
```

