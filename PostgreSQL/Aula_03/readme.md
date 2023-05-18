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

Um schema é uma estrutura que permite organizar e agrupar objetos do banco de dados, como tabelas, views, funções e outros objetos relacionados, utilizando namespaces lógicos que facilitem a compreensão da desta estrutura. Um database pode conter diversos Schemas, e cada Schema pode conter diversas tabelas (ou objetos de banco de dados), o que permite que haja tabelas com o mesmo nome em schemas diferentes sem haver conflito.

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
