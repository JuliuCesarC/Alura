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

O comando `INSERT INTO` junto com o `VALUES` servem para adicionar dados na tabela, e a sintaxe é:

```sql
INSERT INTO nome_tabela(nome_campo1, nome_campo2) 
  VALUES('info_campo1', 'info_campo2');
```

É possível omitir os nomes dos campos se todos eles forem preenchidos no *VALUES*, caso algum campo fique vazio ou que seja gerado automaticamente, então é preciso informar o nome dos campos que serão preenchidos.

Além disso, também podemos adicionar múltiplas linhas em um único *INSERT INTO*, e a sintaxe para isto ficaria:

```sql
INSERT INTO nome_tabela(nome_campo1, nome_campo2) 
  VALUES  ('info_campo1', 'info_campo2'), 
          ('info_campo1', 'info_campo2'),    
          ('info_campo1', 'info_campo2');
```

Agora um exemplo descrevendo os campos e adicionando uma linha na tabela *aluno*:

```sql
INSERT INTO aluno(nome, data_nascimento, idade, cpf, altura, observacao, notas_acumuladas, ativo, horario_aulas, matriculado_em) 
  VALUES (
  'Jão da Silva',
  '1999-04-08',
  24,
  '11111111111',
  1.68,
  'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
  1785,
  TRUE,
  '7:10:00',
  '2022-01-15 15:35:37'
);
```

## Atualizando os campos

Para atualizar os dados, utilizaremos o comando `UPDATE`. Com ele podemos alterar os campos de apenas uma linha, ou de toda a tabela.

```sql
UPDATE aluno
  SET nome = 'Jão Abreu da Silva',
  cpf = '44455226756',
  observacao = 'Phasellus sollicitudin interdum quam et vestibulum.',
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

## Criando relações entre tabelas

Podemos criar alguns tipos de relações entre tabelas, neste curso iremos abordar principalmente a "1 para muitos", "muitos para 1" e "muitos para muitos".

Para criar uma relação, primeiro precisamos garantir que o campo a ser relacionado seja único, e após isso precisamos garantir que seja possível somente relacionar dados que existam em uma tabela, e que estes dados não possam ser duplicados. Para resolver estes problemas, temos as restrições *PRIMARY KEY* e a *FOREIGN KEY* que veremos posteriormente.

Quando trabalhamos com "1 para muitos" e "muitos para 1", podemos simplesmente criar a relação entre as tabelas. Porem, quando trabalhamos com relacionamento de "muitos para muitos", precisamos de uma **tabela de junção**, que sera responsável por representar o relacionamento entre as tabelas. Ela nada mais faz do que indicar quais campos da *tabela_1* estão relacionados com a *tabela_n* e vice e versa.

### Chave primaria

A *PRIMARY KEY*  é uma restrição que pode ser adicionada a um campo (ou conjunto de campos) para que possuam um identificador único para cada registro em uma tabela, permitindo que eles sejam identificados de forma precisa e inequívoca.

A sintaxe para esta restrição é:

```sql
CREATE TABLE nome_tabela(
  nome_campo SERIAL PRIMARY KEY
);
```

Podemos criar um campo semelhante utilizando o `NOT NULL UNIQUE` no lugar do *PRIMARY KEY*, porem o correto é utilizar a chave primaria.

Podemos também criar um conjunto de campos utilizando a sintaxe abaixo:

```sql
CREATE TABLE nome_tabela(
  campo_id INTEGER,
  campo2_id INTEGER,
  PRIMARY KEY (campo_id, campo2_id)
)
```

### Chave estrangeira

A *FOREIGN KEY* é uma restrição que pode ser aplicada a um campo (ou conjunto de campos) para garantir a integridade referencial com um chave primaria de outra tabela.

A chave estrangeira garante que o dado a ser referenciado de outra tabela exista, e que não possa ser duplicado na tabela em que foi aplicada. Além disso, não é possível excluir o valor da tabela pai sem antes excluir os registros que o referenciam na tabela filha.

A sintaxe desta restrição é:

```sql
FOREIGN KEY (campo_tabela) REFERENCES tabela_referencia (campo_tabela_referencia);
```

> Exista a sintaxe simplificada da restrição, omitindo o *FOREIGN KEY* e adicionando o *REFERENCES* na coluna desejada.

Criando um exemplo de relação de "muitos para 1":

```sql
CREATE TABLE curso(
  id SERIAL PRIMARY KEY,
  nome VARCHAR(255) NOT NULL,
  categoria_id INTEGER NOT NULL REFERENCES categoria(id)
);
```

A relação entre *curso* e *categoria* é de "muitos para 1", pois muitos cursos podem estar em uma categoria, porem cada curso possui apenas uma.

E para um exemplo de "muitos para muitos", temos abaixo uma tabela de junção:

```sql
CREATE TABLE aluno_curso(
  aluno_id INTEGER,
  curso_id INTEGER,
  PRIMARY KEY (aluno_id, curso_id),

  FOREIGN KEY (aluno_id) REFERENCES aluno (id),
  FOREIGN KEY (curso_id)
  REFERENCES curso (id)
);
```

Criamos uma referencia do campo *id* da tabela *aluno* para o campo *aluno_id* da tabela *aluno_curso*, e o mesmo para o *curso_id*.

### DELETE/UPDATE CASCADE

Como visto anteriormente ao criar uma chave estrangeira, não seria possível excluir uma linha da tabela_pai que tenha algum campo relacionado na tabela_filha, ao qual possua a restrição *FOREIGN KEY*. Caso seja necessario uma maior liberdade para atualizar e excluir os dados, utilizaremos o **CASCADE**.

A sintaxe para o update e o delete ficaria:

```sql
ON DELETE CASCADE
ON UPDATE CASCADE
```

Ao atualizar ou excluir os dados da tabela/linha referencia, automaticamente esses dados serão atualizados nas tabelas que possuam relação.

> Quando omitimos a restrição, por padrão ela esta configurada como `ON DELETE RESTRICT`, e o mesmo vale para o UPDATE.

Exemplo em uma tabela de junção:

```sql
CREATE TABLE aluno_curso(
  aluno_id INTEGER,
  curso_id INTEGER,
  PRIMARY KEY (aluno_id, curso_id),

  FOREIGN KEY (aluno_id) REFERENCES aluno (id)
  ON DELETE CASCADE
  ON UPDATE CASCADE,
  FOREIGN KEY (curso_id) REFERENCES curso (id)
  ON UPDATE CASCADE  
);
```

Da forma como a tabela foi criada, poderemos atualizar ambos os campos, mas apenas o campo do aluno poderá ser excluído na tabela pai sem nenhuma restrição.

### DROP CASCADE

Ao tentar excluir a tabela pai ocorrera um erro, pois mesmo que a restrição da chave estrangeira esteja como *CASCADE*, o comando de *DROP* também precisa estar. Exemplo da sintaxe:

```SQL
DROP TABLE tabela_pai CASCADE;
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

### JOIN ON

O JOIN permite juntar dados de duas ou mais tabelas relacionadas em uma unica consulta.

A sintaxe básica é:

```sql
FROM tabela_original
  JOIN tabela_relacionada ON campo_tabela_relacionada = campo_tabela_original;
```

> A ordem do campo da tabela relacionada ou da tabela original não importa, ou seja, quem vem antes ou depois do sinal de igual não difere na consulta.

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

### LEFT JOIN

O *LEFT* seleciona todos os dados da tabela original independente se ha algum dado correlacionado na tabela relacionada. Caso o dado não exista, o campo sera preenchido com *NULL*.

```sql
SELECT *
     FROM aluno
LEFT JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
LEFT JOIN curso ON curso.id = aluno_curso.curso_id;
```

### RIGHT JOIN

O *RIGHT* é igual ao *LEFT*, porém traz o resultado inverso, selecionando todos os dados da tabela relacionada. Caso o dado não exista na tabela original, o campo sera preenchido com *NULL*.

```sql
SELECT aluno.nome AS "Nome do aluno",
     curso.nome AS "Nome do Curso"
      FROM aluno
RIGHT JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
RIGHT JOIN curso ON curso.id = aluno_curso.curso_id;
```

### FULL JOIN

O *FULL* é a junção do *LEFT* com o *RIGHT*, seleciona todos os dados das duas tabelas relacionadas. Caso algum dado não exista em uma das tabelas, o campo sera preenchido com *NULL*.

```sql
SELECT *
     FROM aluno
FULL JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
FULL JOIN curso ON curso.id = aluno_curso.curso_id;
```

### CROSS JOIN

O *CROSS* tem um funcionamento bem diferente dos anteriores, ele ira relacionar todas as linhas da tabela original com a relacionada, e o resultado sera o produto do total de linhas de cada tabela. Por exemplo, a tabela_1 possui 3 linhas e a tabela_2 possui 4 linhas, o resultado da pesquisa será 12 linhas relacionadas.

Como este método não precisa que as tabelas sejam relacionadas, a sintaxe é fica diferente, não sendo necessario o `JOIN ON`. Vejamos abaixo:

```sql
SELECT *
  FROM aluno
  CROSS JOIN curso;
```

> Como vemos,não foi necessario passar primeiro pela tabela *aluno_curso*, que relacionava a tabela *aluno* com a tabela *curso*.

### ORDER BY

A ordenação na tabela ao fazer uma busca por exemplo, é a de inserção, ou seja, as linhas vem na ordem que foram inseridas. Para ordenar de outra maneira, utilizaremos o **ORDER BY**. Vejamos a sintaxe abaixo:

```sql
SELECT * FROM nome_tabela
  ORDER BY nome_campo;
```

Podemos ordenar passando o nome do campo ou o *índice* do campo, por exemplo, o quarto campo de uma tabela é a matricula, podemos ordenar por ela informando o numero "4". Por padrão a ordem é crescente `ASC`, mas podemos informar `DESC` para decrescente.

```sql
SELECT * FROM aluno
  ORDER BY nome, sobrenome DESC, matricula;
```

Ao efetuar uma busca em duas ou mais tabelas que tenham um nome igual para algum campo, ocorrera um erro de ambiguidade, que pode ser resolvido ao chamar o nome do campo através do nome da tabela `nome_tabela.nome_campo`.

```sql
SELECT  aluno.id AS ID,
        aluno.matricula AS Matricula,
        aluno.nome AS Nome,
        aluno.sobrenome AS Sobrenome,
        curso.nome AS Curso
  FROM aluno
  JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  JOIN curso ON curso.id = aluno_curso.curso_id
  ORDER BY curso.nome DESC, aluno.nome;
```

### LIMIT OFFSET

O *LIMIT* como o nome sugere, serve para limitar a quantidade de registros que são retornados em uma consulta, e, o *OFFSET* serve para informar a partir de qual linha deve começar a busca.

```sql
SELECT * FROM aluno ORDER BY id
  LIMIT 4
  OFFSET 2;
```

Suponhamos uma tabela com 16 linhas, se informado um limite de 20 linhas, o que sera exibido são apenas as 16 linhas. Agora se for informado um offset de 20, sera retornado vazio, pois não existe nenhum item a partir da linha 20.

Temos algumas vantagens ao utiliza-los, como evitar trabalhar com uma lista muito grande, efetuar uma busca mais rápida e principalmente para economizar dados do servidor.

### Funções de agregação

As funções agregadoras realizam cálculos em conjuntos de valores em uma coluna ou em um grupo de registros e retornam um único valor resultante. Existem diversas funções, porem veremos somente as mais comuns. Para ver a tabela completa acesse o link <a href="https://www.postgresql.org/docs/current/functions-aggregate.html">PostgreSQL funções agregadoras</a>.

- `COUNT`: Retorna o número de linhas ou valores não nulos em uma coluna. Como parâmetro aceita o nome do campo ou o coringa __*__.

- `SUM`: Calcula a soma dos valores em uma coluna numérica.

- `AVG`: Calcula a média dos valores em uma coluna numérica.

- `MAX`: Retorna o maior valor em uma coluna.

- `MIN`: Retorna o menor valor em uma coluna.

```sql
SELECT  COUNT(*),
        SUM(id),
        ROUND(AVG(id), 2),
        MAX(id),
        MIN(id)
  FROM aluno;
```

> O *ROUND* serve para arredondar o resultado da operação, a sintaxe é `ROUND(operação, casas_decimais)`.

### DISTINCT

A clausula *DISTINCT* é utilizada em consultas para evitar o retorno de dados que sejam repetidos. Porem, não é possível fazer nenhuma função de agregação com ele.

Suponhamos uma lista com os produtos de um supermercado, e, seja necessario saber quantos produtos diferentes são vendidos, logo 5 marcas de um mesmo tipo de macarrão, não significa 5 itens diferentes a venda.

```sql
SELECT DISTINCT produto
  FROM estoque
  ORDER BY produto;
```

### GROUP BY

A cláusula *GROUP BY* é semelhante a anterior, também combinando valores esmalhantes em determinadas colunas e os tratando como um grupo único. Mas além disso é possível agrupar os resultados de um ou mais campos e principalmente poder utilizar funções de agregação.

Podemos utilizar o código abaixo para termos o mesmo resultado do *DISTINCT*.

```sql
SELECT produto FROM estoque
  GROUP BY produto
  ORDER BY produto;
```

> Assim como o *ORDER BY*, podemos informar não apenas o nome do campo mas também o índice da coluna para o *GROUP BY*.

Agora voltando com o exemplo do supermercado, suponhamos que seja necessario saber a media do preço dos produtos semelhantes de uma mesma categoria. Por exemplo, a media de preço de todos os macarrões espaguete, dos molhos de tomate, etc. Temos então o código abaixo:

```sql
SELECT  produto AS "Nome do produto",
        COUNT(marca) AS "Quantidade de marcas",
        ROUND(AVG(preco), 2) AS "Preço médio"
  FROM catalogo
  GROUP BY categoria, produto
  ORDER BY produto;
```

Adicionamos os campos *categoria* e *produto* para garantir que nenhuma deles repita um valor semelhante. Além do que foi proposto acima, também contamos a quantidade de marcas que vendem aquele produto com o `COUNT(marca)`.

Outro exemplo utilizando tabelas relacionadas:

```sql
SELECT  curso.nome AS "Nome do curso",
        COUNT(aluno.id) AS "Quantidade de alunos matriculados"
  FROM aluno
  JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  JOIN curso ON curso.id = aluno_curso.curso_id
  GROUP BY curso.nome
  ORDER BY 1;
```

A sintaxe é muito proxima à utilizada para um *SELECT* em tabelas relacionadas, o que diferencia é a função agregadora `COUNT` e para esta função funcionar o `GROUP BY`.

### HAVING

O *HAVING* serve para utilizar filtros em consultas agrupadas.

Quando efetuamos uma consulta com uma função agregadora, não é possível utilizar o *WHERE*, pois o *GROUP BY* não permite. Para contornar este problema utilizamos o *HAVING*.

Vejamos um exemplo para selecionar todos os funcionários com o nome duplicado:

```sql
SELECT  nome AS "Nome do funcionário",
        COUNT(id)
  FROM funcionarios
  GROUP BY nome
  HAVING COUNT(id) > 1;
```

Agora um exemplo com tabelas relacionadas:

```sql
SELECT  curso.nome AS "Nome do curso",
        COUNT(aluno.id) AS "Alunos matriculados"
  FROM curso
  LEFT JOIN aluno_curso ON aluno_curso.curso_id = curso.id
  LEFT JOIN aluno ON aluno.id = aluno_curso.aluno_id
  GROUP BY curso.nome
  HAVING COUNT(aluno.id) = 0
  ORDER BY 1 DESC;
```

Com o código acima, selecionamos todos os cursos que não possuam nenhum aluno matriculado.