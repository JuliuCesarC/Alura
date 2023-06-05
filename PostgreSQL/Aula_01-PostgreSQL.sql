// -------------------- ALUNO --------------------
DROP TABLE aluno CASCADE;
CREATE TABLE aluno(
  id SERIAL PRIMARY KEY,
  nome VARCHAR(255)
);
SELECT * FROM aluno;

INSERT INTO aluno(nome)VALUES ('Marco');
INSERT INTO aluno(nome)VALUES ('Jão');
INSERT INTO aluno(nome)VALUES ('Jenfiner');

DELETE FROM aluno WHERE id = 2;
UPDATE aluno SET id = 2 WHERE id = 6;

CREATE TABLE aluno(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(100),
	sobrenome VARCHAR(155),
	matricula VARCHAR(4)
);
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Ana Maria', 'Costa', 'A006');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Marco', 'Abreu', 'A003');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Jenfiner', 'Oliveira', 'A002');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Marco', 'Lima', 'A001');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Jão', 'Silva', 'A004');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Jão', 'Castilho', 'A005');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Jão', 'Silva', 'A007');
INSERT INTO aluno(nome, sobrenome, matricula)VALUES ('Ana Maria', 'Costa', 'A006');
// -------------------- CURSO --------------------
drop table curso;
create table curso(
	id integer not null unique,
	nome varchar(255) not null
);
Select * from curso;
	
insert into curso(id, nome)
	Values (null, null);
	
insert into curso(id, nome)
	Values (1, 'html');
insert into curso(id, nome)
	Values (2, 'javascript');
insert into curso(id, nome)
	Values (3, 'css');
insert into curso(id, nome)
	Values (4, 'jquery');
insert into curso(id, nome)
	Values (5, 'Sass');
	
// -------------------- ALUNO CURSO --------------------
DROP TABLE aluno_curso;
CREATE TABLE aluno_curso(
	aluno_id INTEGER,
	curso_id INTEGER,
	PRIMARY KEY (aluno_id, curso_id)
)
Select * from aluno_curso;

DROP TABLE aluno_curso;
CREATE TABLE aluno_curso(
	aluno_id INTEGER,
	curso_id INTEGER,
	PRIMARY KEY (aluno_id, curso_id),	
	FOREIGN KEY (aluno_id)
	REFERENCES aluno (id),
	FOREIGN KEY (curso_id)
	REFERENCES curso (id)
);

INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(1, 1);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(2, 1);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(2, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(3, 1);

INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(7, 1);

// -------------------- SELECT --------------------
SELECT * 
	FROM aluno
	JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
	JOIN curso ON curso.id = aluno_curso.curso_id;

SELECT aluno.nome, curso.nome
	FROM aluno
	JOIN aluno_curso ON aluno.id = aluno_curso.aluno_id
	JOIN curso ON curso.id = aluno_curso.curso_id;
	
SELECT aluno.nome AS "Nome do aluno",
	   curso.nome AS "Nome do Curso"
	FROM aluno
	JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
	JOIN curso 		 ON curso.id 			 = aluno_curso.curso_id;

SELECT aluno.nome AS "Nome do aluno",
	   curso.nome AS "Nome do Curso"
	FROM aluno
LEFT JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
LEFT JOIN curso 	  ON curso.id 			  = aluno_curso.curso_id;

SELECT aluno.nome AS "Nome do aluno",
	   curso.nome AS "Nome do Curso"
	FROM aluno
RIGHT JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
RIGHT JOIN curso 	   ON curso.id 			   = aluno_curso.curso_id;

SELECT aluno.nome AS "Nome do aluno",
	   curso.nome AS "Nome do Curso"
	FROM aluno
FULL JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
FULL JOIN curso 	   ON curso.id 			   = aluno_curso.curso_id;

SELECT *
	FROM aluno
CROSS JOIN curso;

// -------------------- DELETE CASCADE --------------------
DROP TABLE aluno_curso;
CREATE TABLE aluno_curso(
	aluno_id INTEGER,
	curso_id INTEGER,
	PRIMARY KEY (aluno_id, curso_id),	
	FOREIGN KEY (aluno_id)
	REFERENCES aluno (id)
	ON DELETE CASCADE,
	FOREIGN KEY (curso_id)
	REFERENCES curso (id)
	ON DELETE CASCADE
);
Select * from aluno_curso;
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(1, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(2, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(2, 1);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(3, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(3, 1);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(4, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(5, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(5, 3);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(6, 1);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(6, 2);
INSERT INTO aluno_curso (aluno_id, curso_id) VALUES(7, 1);

// -------------------- UPDATE CASCADE --------------------
DROP TABLE aluno_curso;
CREATE TABLE aluno_curso(
	aluno_id INTEGER,
	curso_id INTEGER,
	PRIMARY KEY (aluno_id, curso_id),	
	
	FOREIGN KEY (aluno_id)	
	REFERENCES aluno (id)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY (curso_id)
	REFERENCES curso (id)
	ON DELETE CASCADE
);
SELECT  aluno.id AS aluno_id,
		aluno.nome AS "Nome do aluno",
		curso.id AS curso_id,
	    curso.nome AS "Nome do Curso"
	FROM aluno
	JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
	JOIN curso 		 ON curso.id 			 = aluno_curso.curso_id;

// -------------------- ORDER BY --------------------

SELECT * FROM aluno
	ORDER BY nome;
	
SELECT * FROM aluno
	ORDER BY nome, sobrenome DESC, matricula;

SELECT 	aluno.id AS ID,
		aluno.matricula AS Matricula,
		aluno.nome AS "Nome",
		aluno.sobrenome AS "Sobrenome",
		curso.nome AS "Curso"
	FROM aluno
	JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
	JOIN curso 		 ON curso.id 			 = aluno_curso.curso_id
	ORDER BY curso.nome DESC, aluno.nome ASC
	;

SELECT * FROM aluno ORDER BY id
	LIMIT 4
	OFFSET 9;

// -------------------- FUNÇÕES AGREGADORAS --------------------
SELECT 	COUNT(*),
		SUM(id),
		ROUND(AVG(id), 2),
		MAX(id),
		MIN(id)
	FROM aluno;

// -------------------- DISTINCT --------------------
SELECT DISTINCT nome, id
	FROM aluno
	ORDER BY nome;
	
// -------------------- GROUP BY --------------------
SELECT * FROM aluno;
SELECT 	nome,
		sobrenome,
		COUNT(id)
	FROM aluno
	GROUP BY nome, sobrenome
	ORDER BY nome;

SELECT  curso.nome AS "Nome do curso",
        COUNT(aluno.id) AS "Quantidade de alunos matriculados"
  FROM aluno
  JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
  JOIN curso ON curso.id = aluno_curso.curso_id
  GROUP BY curso.nome
  ORDER BY 1;

DROP TABLE catalogo;
CREATE TABLE catalogo(
	id SERIAL PRIMARY KEY,
	categoria VARCHAR(110),
	produto VARCHAR(110),
	marca VARCHAR(110),
	preco NUMERIC(6,2)
);
SELECT * FROM catalogo;
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('massa','macarrão', 'broto', 5.22);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('massa','macarrão', 'folha', 5.37);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('massa','macarrão', 'tronco', 6.09);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('massa','macarrão', 'raiz', 6.45);

INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('molho','massa de tomate', 'broto', 2.35);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('molho','massa de tomate', 'raiz', 4.89);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('molho','massa de tomate', 'tronco', 2.44);

INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('molho','molho barbecue', 'raiz', 7.68);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('molho','molho barbecue', 'galho', 9.74);

INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('laticínio','queijo', 'folha', 8.75);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('laticínio','queijo', 'raiz', 12.19);
INSERT INTO catalogo(categoria, produto, marca, preco) 
  VALUES('laticínio','queijo', 'tronco', 9.00);

SELECT 	produto AS "Nome do produto",
		COUNT(marca) AS "Quantidade de marcas",
		ROUND(AVG(preco), 2) AS "Preço medio"
	FROM catalogo
	GROUP BY categoria, produto
	ORDER BY produto;

// -------------------- FILTRO DE CONSULTAS AGRUPADAS --------------------
SELECT  curso.nome AS "Nome do curso",
        COUNT(aluno.id) AS "Alunos matriculados"
  FROM curso
  LEFT JOIN aluno_curso ON aluno_curso.curso_id = curso.id
  LEFT JOIN aluno ON aluno.id = aluno_curso.aluno_id
  GROUP BY curso.nome
  HAVING COUNT(aluno.id) = 0
  ORDER BY 1 DESC;

