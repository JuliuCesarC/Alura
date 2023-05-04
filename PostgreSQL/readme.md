# Formação em SQL com PostgreSQL

## Tipos de dados

O PostgreSQL possui diversos tipos de dados que serão armazenados, tipos numéricos, tipos de caracteres, datas, entre outros. Para ver com detalhe todos os tipos de dados acessar o link <a href="https://www.postgresql.org/docs/current/datatype.html">PostgreSQL data types</a>.

Para este documento veremos apenas os mais comuns.

### Tipos numéricos

- **integer**: armazena números inteiros de `-2.147.483.648` até `+2.147.483.647`.
- **real**: armazena números com casas decimais com até 6 dígitos de precisão.
- **serial**: utilizado para criar uma coluna autoincrementável, somando +1 toda vez que é incluído, não sendo necessario passar nenhum numero. Armazena do numero `1` ao `2.147.483.647`.

> Pode ser utilizado para criar uma coluna de *id*.

- **numeric(precision, scale)**: armazena números com alta precisão. O primeiro parâmetro é a quantidade de dígitos do campo, e o segundo é a quantidade de dígitos após a virgula (ou ponto no padrão USA).

Um exemplo para o numeric é o saldo de uma conta bancaria, podemos criar o campo:

```sql
saldo NUMERIC(10, 2)
```

É possível armazenar valores com 8 dígitos antes e 2 dígitos após a virgula.

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

Ao remover o ponto e virgula do final da primeira linha de código, podemos apertar o *ENTER* para ir para proxima linha, assim sucessivamente para cada parâmetro, e bastando no ultimo adicionar novamente o ponto e virgula para finalizar o comando.

### Removendo um database

```sql
DROP DATABASE nome_do_database;
```

### Visualizando os databases

Para visualizar todos os bancos de dados, podemos utilizar o:

```sql
\l
```

