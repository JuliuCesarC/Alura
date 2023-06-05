CREATE TABLE aluno(
	id SERIAL PRIMARY KEY,
	primeiro_nome VARCHAR(100) NOT NULL,
	sobrenome VARCHAR(155) NOT NULL,
	matricula VARCHAR(5)
);

CREATE TABLE categoria(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL
);

DROP TABLE curso CASCADE;
CREATE TABLE curso(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	categoria_id INTEGER NOT NULL REFERENCES categoria(id)
);
SELECT * FROM curso;

DROP TABLE aluno_curso;
CREATE TABLE aluno_curso(
	aluno_id INTEGER NOT NULL REFERENCES aluno(id)
	ON DELETE CASCADE,
	curso_id INTEGER NOT NULL REFERENCES curso(id)
	ON DELETE CASCADE,
	PRIMARY KEY (aluno_id, curso_id)
);
SELECT * FROM aluno_curso;

INSERT INTO aluno(primeiro_nome, sobrenome, matricula) 
  VALUES ('Jão', 'Silva', 'S5548'),('Jenfiner', 'Olivara', 'S5533'),
  		 ('Marco', 'Lima', 'S5543'),('Lusca', 'Bravo', 'S5572'),
		 ('Masteu', 'Rocha', 'S5528'),('Ana Maria', 'Braga', 'S5751'),
		 ('Flavia', 'Pedra', 'S5767'),('Lusca', 'Irritado', 'S5572'),
		 ('Jão', 'Silva', 'S5548');
		 
INSERT INTO aluno(primeiro_nome, sobrenome, matricula) 
	VALUES ('Jenfiner', 'Bianccini', 'S5509')

SELECT * FROM aluno

INSERT INTO categoria(nome) 
	VALUES('Front-end'), ('Back-end'), ('DevOps');

INSERT INTO curso(nome, categoria_id) 
	VALUES	('Javascript', 1),('HTML', 1),('CSS', 1),
			('Java', 2),('CSharp', 2),
			('Azure Cloud', 3),('Linux', 3);
INSERT INTO curso(nome, categoria_id) VALUES('teste', 5);

INSERT INTO aluno_curso(aluno_id, curso_id) 
	VALUES	(1,1),(1,2),(1,3),(2,1),(2,4),(3,5),(3,4),(3,6),
			(4,1),(4,2),(4,3),(5,6),(5,7),(6,2),(6,3),(7,4),
			(7,7),(8,1),(8,4),(8,7),(9,1),(9,2),(9,3),(9,4);

-- Seleciona quantos alunos por curso
SELECT 	curso.nome AS nome_curso,
		COUNT(aluno_curso.aluno_id) numero_de_alunos
	FROM curso
	JOIN aluno_curso ON aluno_curso.curso_id = curso.id
	GROUP BY 1
	ORDER BY numero_de_alunos DESC;

-- Seleciona quantos cursos por aluno
SELECT 	aluno.primeiro_nome AS nome_aluno,
		COUNT(aluno_curso.curso_id) numero_de_cursos
	FROM aluno
	JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
	GROUP BY 1
	ORDER BY numero_de_cursos DESC;

-- Seleciona quais cursos possui cada categoria
SELECT  categoria.nome AS "Nome da categoria",
        curso.nome AS "Cursos cadastrado na categoria"
  FROM categoria
  JOIN curso ON curso.categoria_id= categoria.id;
 
SELECT * FROM aluno;

-- Seleciona quantos nomes estão repetidos
Select primeiro_nome, COUNT(id) FROM aluno GROUP BY primeiro_nome;

Select primeiro_nome, COUNT(id) FROM aluno GROUP BY primeiro_nome;

SELECT 	aluno.primeiro_nome AS nome_aluno,
		COUNT(aluno_curso.curso_id) numero_de_cursos
	FROM aluno
	JOIN aluno_curso ON aluno_curso.aluno_id = aluno.id
	GROUP BY 1
	HAVING COUNT(aluno_curso.curso_id) > 5
	ORDER BY numero_de_cursos DESC
	

	
Select * FROM curso WHERE categoria_id IN (1,2);

SELECT * FROM aluno WHERE primeiro_nome IN('Jão', 'Flavia');

SELECT * FROM aluno WHERE sobrenome LIKE 'B%';

/* -------------------- SUBQUERY -------------------- */
-- Subquery é quando utilizamos uma query como parametro de outra query.
SELECT * FROM curso WHERE categoria_id IN (
	SELECT id FROM categoria WHERE nome LIKE '%-%'
);
-- Seleciona todos os cursos das categorias que possuem um hífen no nome.

SELECT categoria.nome as Categoria,
		COUNT(curso.categoria_id) as Quantidade_cursos
	FROM categoria
	JOIN curso ON curso.categoria_id = categoria.id
	GROUP BY categoria
	ORDER BY 1;

SELECT categoria, Quantidade_cursos
	FROM(
		SELECT 	categoria.nome as Categoria,
				COUNT(curso.categoria_id) as Quantidade_cursos
			FROM categoria
			JOIN curso ON curso.categoria_id = categoria.id
			GROUP BY categoria
	) AS categoria_curso
	WHERE Quantidade_cursos > 2;
-- Tambem é possivel utilizar a tabela retornada de uma query, 
-- para efetuar uma outra query em cima desta nova tabela.

/* -------------------- CREATE VIEW -------------------- */

SELECT * FROM vw_cursos_por_categoria
	WHERE numero_cursos > 3;

CREATE VIEW vw_cursos_por_categoria 
	AS SELECT categoria.nome AS Categoria,
		COUNT(curso.id) AS numero_cursos
	FROM categoria
	JOIN curso ON curso.categoria_id = categoria.id
	GROUP BY categoria;
	
SELECT * FROM vw_cursos_frontEnd
	WHERE "Nome dos cursos" LIKE 'J%';

CREATE VIEW vw_cursos_frontEnd
	AS SELECT curso.nome AS Cursos
	FROM curso
	WHERE categoria_id = 1;

-- É possivel juntar outras tabelas com o VIEW utilizando o JOIN da mesma 
-- forma como uma consulta normal. Em contra ponto é a perda de performance,
-- por exemplo abaixo, o VIEW ja havia feito uma busca em 'categoria' e ao final
-- é novamente efetuado uma busca nesta tabela, o que resulta em gasto
-- desnecessario de dados.
SELECT 	categoria.id AS Categoria_id,
		vw_cursos_por_categoria.*
	FROM vw_cursos_por_categoria
	JOIN categoria ON categoria.nome = vw_cursos_por_categoria.categoria;
-- Uma busca por nome é mais custosa do que por ID por exemplo.

ALTER VIEW vw_cursos_frontEnd
RENAME Cursos TO "Nome dos cursos";

SELECT * FROM testando;
DROP TABLE testando
CREATE TABLE testando(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255)
)

INSERT INTO testando(nome) 
	VALUES('qualquer coisa1'),
		('qualquer coisa2'), ('qualquer coisa3')
DELETE FROM testando;
