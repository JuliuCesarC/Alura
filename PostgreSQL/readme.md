# Formação em SQL com PostgreSQL

Durante os cursos utilizaremos as ferramentas **SQL Shell** e **pgAdmin 4**, sendo a segunda muito mais utilizada devido a ser mais semelhante a um editor de código.

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

Para esta aula veremos apenas as sintaxes mais básicas para criar um database, mas vale lembrar que existe diversos parâmetros que podemos informar ao criar o novo database. Acesse o <a href="https://www.postgresql.org/docs/current/sql-createdatabase.html">Link</a> para ver a lista completa. No *SQL Shell* primeiro é preciso selecionar um servidor com o comando `SELECT NOW();`. Já no *pgAdmin*, basta clicar com o botão direito do mouse em cima do *database* e selecionar a opção *create*.

Abaixo temos a sintaxe mais básica, e em seguida outra informando alguns parâmetros:

```sql
CREATE DATABASE nome_do_database;

CREATE DATABASE nome_do_database
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;
```

Para utilizar estes comandos no *SQL Shell*, primeiro precisamos remover o ponto e virgula do final da primeira linha de código, para então podermos apertar o *ENTER* e ir para proxima linha, assim sendo possíveis digitar todos os parâmetros sucessivamente. Na ultima linha de código basta adicionar novamente o ponto e virgula para finalizar o comando.

### Removendo um database

```sql
DROP DATABASE nome_do_database;
```

### Visualizando os databases

Para visualizar todos os bancos de dados no *SQL Shell*, podemos utilizar o:

```sql
\l
```

## Criando um tabela

Existe uma enormidade de parâmetros que podem ser definidos ao criar uma tabela, e a sintaxe completa pode até assustar em uma primeira impressão, porém neste curso começaremos com o básico. Para ver a documentação completa acesse o <a href="https://www.postgresql.org/docs/current/sql-createtable.html">Link</a>.

Para criar uma tabela temos a sintaxe básica abaixo:

```sql
CREATE TABLE nome_tabela( colunas )

CREATE TABLE Squema.nome_tabela( colunas )
```

Toda tabela precisa ser associada a um *Schema*, porém quando omitimos esta informação, a tabela é criada dentro do schema padrão que se chama *Public*. Neste documento, utilizaremos apenas o schema padrão para executar os exercícios propostos.

Criaremos uma tabela simulando as informações de um aluno com o código abaixo:

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

### Inserindo dados na tabela

Para inserir dados em uma tabela, temos a sintaxe seguinte:

```sql
INSERT INTO nome_tabela(nome_campo1, nome_campo2, ...nome_campoN) 
  VALUES('info_campo1', 'info_campo2', ..., 'info_campoN');
```

É possível omitir todos os nomes dos campos após o `nome_tabela`, se todos eles forem preenchidos no *VALUES*, caso algum campo fique vazio ou que seja gerado automaticamente, então é preciso informar o nome dos campos que serão preenchidos.

Além disso, também podemos adicionar múltiplas linhas em um único *INSERT INTO*, e a sintaxe para isto ficaria:

```sql
INSERT INTO nome_tabela(nome_campo1, nome_campo2) 
  VALUES  ('info_campo1', 'info_campo2'), 
          ('info_campo1', 'info_campo2'),    
          ('info_campo1', 'info_campo2');
```

Agora um exemplo onde inserimos dados na tabela *aluno*:

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

### Atualizando os campos

Para atualizar os dados, utilizaremos o comando `UPDATE`. Com ele podemos alterar os campos de apenas uma linha, ou de toda a tabela. Ficando a sintaxe:

```sql
UPDATE nome_tabela
  SET nome_campo1 = 'Novo valor campo1', nome_campo2 = 'Novo valor campo2'
  WHERE condição;

UPDATE nome_tabela
  SET nome_campo = 'Todos terão esta informação.';
```

No primeiro trecho de código, é alterado apenas os campos das linhas que atendem à condição. Já no segundo trecho, omitimos o *WHERE*, dessa forma o campo selecionado sera alterado em todas as linhas da tabela.

> Lembrando que não é muito indicado alterar toda a tabela, pois isso pode acarretar em algumas inconsistências caso ocorra algum engano.

```sql
UPDATE aluno
  SET nome = 'Jão Abreu da Silva',
  cpf = '44455226756',
  observacao = 'Phasellus sollicitudin interdum quam et vestibulum.',
  notas_acumuladas = 1821
  WHERE id = 1;
```

O código acima atualiza apenas as colunas desejadas do aluno cujo o *id* é igual a 1.

### Deletando uma linha da tabela

Utilizaremos o comando `DELETE` para excluir uma linha da tabela. Sendo a sintaxe:

```sql
DELETE FROM nome_tabela
  WHERE condição;
```

Agora um exemplo onde excluimos da tabela *aluno* a linha cujo o valor no campo *nome* é *Roberto*:

```sql
DELETE FROM aluno
  WHERE nome = 'Roberto';
```

Lembrar sempre de executar o comando com o *WHERE*, pois ao executar apenas a primeira parte do código, todos os dados da tabela serão excluídos.

```sql
DELETE FROM aluno
-- Remove todos os dados da tabela.
```

### Excluindo uma tabela

Para excluir uma tabela, utilizaremos o mesmo `DROP` que foi utilizado no database, ficando a seguinte sintaxe:

```sql
DROP TABLE nome_tabela;
```

## Criando relações entre tabelas

Podemos criar alguns tipos de relações entre tabelas, neste curso iremos abordar principalmente a "1 para muitos", "muitos para 1" e "muitos para muitos".

Para criar uma relação, primeiro precisamos garantir que o campo a ser relacionado seja único e que exista em uma tabela, além de não poder ter um valor duplicado. Para resolver estes problemas, temos as restrições *PRIMARY KEY* e a *FOREIGN KEY* que veremos posteriormente.

Quando trabalhamos com "1 para muitos" e "muitos para 1", podemos simplesmente criar a relação entre as tabelas. Porem, quando trabalhamos com relacionamento de "muitos para muitos", precisamos de uma **tabela de junção**, que sera responsável por representar o relacionamento entre as tabelas. Ela nada mais faz do que indicar quais campos da *tabela_1* estão relacionados com a *tabela_n* e vice e versa.

### Chave primaria

A *PRIMARY KEY*  é uma restrição que pode ser adicionada a um campo (ou conjunto de campos) para que possuam um identificador único para cada registro em uma tabela, permitindo que eles sejam identificados de forma precisa e inequívoca.

A sintaxe para esta restrição é:

```sql
CREATE TABLE nome_tabela(
  nome_campo SERIAL PRIMARY KEY
);
```

Podemos criar um campo semelhante utilizando o `NOT NULL UNIQUE` no lugar do *PRIMARY KEY*, porem para trabalhar com relações o mais indicado é utilizar a chave primaria.

Também temos a sintaxe para criar um conjunto de campos:

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
campo_tabela INTEGER,
FOREIGN KEY (campo_tabela) REFERENCES tabela_referencia (campo_tabela_referencia);
```

> Exista a sintaxe simplificada da restrição, omitindo o *FOREIGN KEY* e adicionando apenas o *REFERENCES* na declaração do campo desejado. Com isso não é necessario primeiro criar o campo e depois declarar a restrição.

Criando um exemplo de relação de "muitos para 1", utilizando a sintaxe simplificada da restrição:

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

Para efetuar uma Query, utilizaremos os comandos `SELECT` e `FROM`. O *SELECT* sera responsável por selecionar os campos e o *FROM* por selecionar a tabela.

A sintaxe fica:

```sql
SELECT nome_campo FROM nome_tabela;
```

Também é possível utilizar o resultado de uma query como tabela para uma outra query, e para fazer isso, no local do nome da tabela é adicionado uma query entre parenteses **( )**. Porem na maioria dos casos, é mais simples obter o resultado utilizando mais um *JOIN* ou buscando com o *HAVING*.

Para selecionar todos os campos de uma tabela, existe um caractere especial responsável por isso, que é o asterisco __*__.

Abaixo temos alguns exemplos de query's:

```sql
SELECT * FROM aluno;

SELECT nome FROM aluno;

SELECT  nome AS Nome_aluno,
        data_nascimento AS "Data de nascimento",
        matriculado
  FROM aluno
```

O comando `AS` serve para alterar o nome do campo, e caso o nome tenha espaços em branco é preciso utilizar as aspas duplas " ".

### WHERE

O *WHERE* serve para filtrar dados na tabela. Utilizaremos ele junto com os operadores lógicos visto anteriormente para criar uma condição.

Alguns exemplos são:

```sql
SELECT * FROM aluno WHERE idade >= 25;
SELECT * FROM aluno WHERE cpf IS NOT NULL;

SELECT  nome AS "Nome do aluno",
        data_nascimento AS "Data de nascimento",
        matriculado
  FROM aluno
  WHERE nome LIKE '% da _ilva';
```

Este ultimo exemplo seleciona múltiplos campos das linhas que tenham na coluna *nome*  qualquer texto que termine com *da Silva* por exemplo.

### JOIN ON

O JOIN permite juntar dados de duas ou mais tabelas relacionadas em uma unica consulta.

A sintaxe básica é:

```sql
SELECT * FROM tabela_original
  JOIN tabela_relacionada ON campo_tabela_relacionada = campo_tabela_original;
```

> A ordem do campo da tabela relacionada ou da tabela original não importa, ou seja, quem vem antes ou depois do sinal de igual não difere na consulta.

Alguns exemplos são:

Abaixo temos uma query que retorna todos os cursos cadastrados em cada categoria.

```sql
SELECT  categoria.nome AS "Nome da categoria",
        curso.nome AS "Cursos cadastrado na categoria"
  FROM categoria
  JOIN curso ON categoria.id = curso.categoria_id;
```

Suponhamos que temos 3 tabelas, a *aluno*, *curso* e *aluno_curso*, e seja necessario buscar apenas o campo do nome do aluno e o nome do curso. Como a relação entre as 2 primeiras tabelas é de "Muitos para Muitos", então sera obrigatório passar pela tabela de junção *aluno_curso* para fazer esta consulta, temos o código abaixo:

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
SELECT * FROM tabela_original
  LEFT JOIN tabela_relacionada ON campo_relacionado = campo_original;
```

### RIGHT JOIN

O *RIGHT* é igual ao *LEFT*, porém traz o resultado inverso, selecionando todos os dados da tabela relacionada. Caso o dado não exista na tabela, o campo sera preenchido com *NULL*.

```sql
SELECT  aluno.nome AS "Nome do aluno",
        curso.nome AS "Nome do Curso"
      FROM aluno
RIGHT JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
RIGHT JOIN curso ON curso.id = aluno_curso.curso_id;
```

### FULL JOIN

O *FULL* é a junção do *LEFT* com o *RIGHT*, seleciona todos os dados das duas tabelas relacionadas. Caso algum dado não exista em uma das tabelas, o campo sera preenchido com *NULL*.

```sql
SELECT * FROM aluno
  FULL JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  FULL JOIN curso ON curso.id = aluno_curso.curso_id;
```

### CROSS JOIN

O *CROSS* tem um funcionamento bem diferente dos anteriores, ele ira relacionar todas as linhas da tabela original com a relacionada, e o resultado sera o produto do total de linhas de cada tabela. Por exemplo, a tabela_1 possui 3 linhas e a tabela_2 possui 4 linhas, o resultado da pesquisa será 12 linhas relacionadas.

Como este método **não** precisa que as tabelas sejam relacionadas, a sintaxe fica diferente, não sendo necessario o `JOIN ON`. Vejamos abaixo:

```sql
SELECT * FROM tabela_original
  CROSS JOIN tabela_referencia;
```

> O *CROSS JOIN* pode ser utiliza mesmo em tabelas relacionadas.

### ORDER BY

O *ORDER BY* é utilizado para ordenar uma tabela de acordo com o campo (ou múltiplos campos).

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

O *LIMIT* como o nome sugere, serve para limitar a quantidade de registros que são retornados em uma consulta e o *OFFSET* serve para informar a partir de qual linha deve começar a busca.

```sql
SELECT * FROM aluno ORDER BY id
  LIMIT 4
  OFFSET 2;
```

Suponhamos uma tabela com 16 linhas, se informado um limite de 20 linhas, o que sera exibido são apenas as 16 linhas. Agora se for informado um offset de 20, sera retornado vazio, pois não existe nenhum item a partir da linha 20.

Temos algumas vantagens ao este limite, como evitar trabalhar com uma lista muito grande, efetuar uma busca mais rápida e principalmente para economizar dados do servidor.

### Funções de agregação

As funções agregadoras realizam cálculos nas colunas, linhas e valores de uma tabela, retornando um único valor resultante. Existem diversas funções, porem veremos somente as mais comuns. Para ver a tabela completa acesse o link <a href="https://www.postgresql.org/docs/current/functions-aggregate.html">PostgreSQL funções agregadoras</a>.

- `COUNT`: Retorna o número de total de linhas em uma tabela ou coluna. Linhas que possuírem valores nulos serão desconsiderados. Como parâmetro aceita o nome do campo ou o coringa __*__.

- `SUM`: Calcula a soma dos valores em uma coluna numérica.

- `AVG`: Calcula a média dos valores em uma coluna numérica.

- `MAX`: Retorna o maior valor em uma coluna.

- `MIN`: Retorna o menor valor em uma coluna.

```sql
SELECT  COUNT(*) AS "Numero de alunos matriculados",
        SUM(id),
        ROUND(AVG(id), 2),
        MAX(id) AS "Ultimo aluno matriculado",
        MIN(id) AS "Primeiro aluno matriculado"
  FROM escola;
```

> O *ROUND* serve para arredondar o resultado da operação, a sintaxe é `ROUND(operação, casas_decimais)`.

### DISTINCT

A clausula *DISTINCT* é utilizada em consultas para evitar o retorno de dados que sejam repetidos. Porem, não é possível fazer nenhuma função de agregação com ele.

Suponhamos uma lista com os produtos de um supermercado, e, seja necessario saber quantos produtos diferentes são vendidos, logo 5 marcas de um mesmo tipo de macarrão, não significa 5 itens diferentes a venda. Então utilizaremos a clausula no campo produto, vejamos abaixo:

```sql
SELECT DISTINCT produto AS "Nome do produto",
                marca AS Marca
  FROM estoque
  ORDER BY produto;
```

### GROUP BY

A cláusula *GROUP BY* é semelhante a anterior, também evita o retorno de dados que sejam repetidos e os trata como um grupo único. Mas o que o torna muito diferente, é a possibilidade de utilizar funções de agregação, e para casos de consultas em múltiplas tabelas com o *JOIN*, o uso é obrigatório.

A sintaxe desta clausula produzira o mesmo resultado que o *DISTINCT*:

```sql
SELECT produto AS "Nome do produto"
  FROM estoque
  GROUP BY produto
  ORDER BY produto;
```

> Assim como no *ORDER BY*, podemos informar não apenas o nome do campo mas também o índice da coluna para o *GROUP BY*.

Agora voltando com o exemplo do supermercado, suponhamos que seja necessario saber a media do preço dos produtos semelhantes de uma mesma categoria. Por exemplo, a media de preço de todos os macarrões espaguete, dos molhos de tomate, etc. Temos então o código abaixo:

```sql
SELECT  produto AS "Nome do produto",
        COUNT(marca) AS "Quantidade de marcas",
        ROUND(AVG(preco), 2) AS "Preço médio"
  FROM catalogo
  GROUP BY categoria, produto
  ORDER BY produto;
```

Adicionamos os campos *categoria* e *produto* para garantir que nenhum deles seja repetido. Além do que foi proposto acima, também contamos a quantidade de marcas que vendem aquele produto com o `COUNT(marca)`.

Outro exemplo utilizando tabelas de junção:

```sql
SELECT  curso.nome AS "Nome do curso",
        COUNT(aluno.id) AS "Quantidade de alunos matriculados"
  FROM aluno
  JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  JOIN curso ON curso.id = aluno_curso.curso_id
  GROUP BY curso.nome
  ORDER BY 1;
```

### HAVING

O *HAVING* serve para utilizar filtros em consultas agrupadas.

Não é possível trabalhar com o *WHERE* em uma consulta que possui a clausula *GROUP BY*, para ter o mesmo resultado é obrigatório o uso do *HAVING* no lugar.

A sintaxe é:

```sql
SELECT campo1 FROM tabela GROUP BY campo1
  HAVING condição;
```

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
