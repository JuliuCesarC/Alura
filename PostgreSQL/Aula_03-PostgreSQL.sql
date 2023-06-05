CREATE SCHEMA academico;
DROP SCHEMA academico CASCADE;

CREATE TABLE academico.aluno(
	id SERIAL PRIMARY KEY,
	primeiro_nome VARCHAR(100) NOT NULL,
	sobrenome VARCHAR(155) NOT NULL,
	matricula VARCHAR(5)
);

DROP TABLE academico.categoria;
CREATE TABLE academico.categoria(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL
);

DROP TABLE academico.curso CASCADE;
CREATE TABLE academico.curso(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	categoria_id INTEGER NOT NULL REFERENCES academico.categoria(id)
);

DROP TABLE academico.aluno_curso;
CREATE TABLE academico.aluno_curso(
	aluno_id INTEGER NOT NULL REFERENCES academico.aluno(id)
	ON DELETE CASCADE,
	curso_id INTEGER NOT NULL REFERENCES academico.curso(id)
	ON DELETE CASCADE,
	PRIMARY KEY (aluno_id, curso_id)
);

INSERT INTO academico.aluno(primeiro_nome, sobrenome, matricula) 
  VALUES ('Jão', 'Silva', 'S5548'),('Jenfiner', 'Olivara', 'S5533'),
  		 ('Marco', 'Lima', 'S5543'),('Lusca', 'Bravo', 'S5572'),
		 ('Masteu', 'Rocha', 'S5528'),('Ana Maria', 'Braga', 'S5751'),
		 ('Flavia', 'Pedra', 'S5767'),('Lusca', 'Irritado', 'S5572'),
		 ('Jão', 'Silva', 'S5548');		 
INSERT INTO academico.aluno(primeiro_nome, sobrenome, matricula) 
	VALUES ('Jenfiner', 'Bianccini', 'S5509')

INSERT INTO academico.categoria(nome) 
	VALUES('Front-end'), ('Back-end'), ('DevOps');
SELECT * FROM academico.categoria

INSERT INTO academico.curso(nome, categoria_id) 
	VALUES	('Javascript', 1),('HTML', 1),('CSS', 1),
			('Java', 2),('CSharp', 2),
			('Azure Cloud', 3),('Linux', 3);
SELECT * FROM academico.curso

INSERT INTO academico.aluno_curso(aluno_id, curso_id) 
	VALUES	(1,1),(1,2),(1,3),(2,1),(2,4),(3,5),(3,4),(3,6),
			(4,1),(4,2),(4,3),(5,6),(5,7),(6,2),(6,3),(7,4),
			(7,7),(8,1),(8,4),(8,7),(9,1),(9,2),(9,3),(9,4);

DROP TABLE academico.pessoa;
CREATE TABLE academico.pessoa(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	data_nascimento DATE NOT NULL
);

INSERT INTO academico.pessoa(nome, data_nascimento) 
	VALUES('Jão Paulo', '1995-08-07'), ('Jenfiner Malbec', '1997-11-21'),
			('Lusca Calvo', '1983-02-17');


CREATE SCHEMA formado;

CREATE TABLE academico.formado(
	id SERIAL PRIMARY KEY,
	matricula VARCHAR(5) NOT NULL
);
INSERT INTO academico.formado(matricula) VALUES('s4865'), ('s8775'), ('s6588');

DROP TABLE formado.aluno_formado;
DROP TABLE academico.nova_tabela;
CREATE TABLE academico.nova_tabela(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	data_formacao DATE NOT NULL,
	cpf VARCHAR(11) NOT NULL UNIQUE
);
INSERT INTO formado.aluno_formado(nome, data_formacao, cpf, matricula) 
	VALUES	('Jão Paulo', '2022-11-07', '55448652311',1), 
			('Jenfiner Malbec', '2020-11-21', '45888775963',2),
			('Lusca Calvo', '2019-12-17', '21224465788',3);


ALTER TABLE academico.nova_tabela RENAME TO aluno_formado;
ALTER TABLE academico.aluno_formado SET SCHEMA formado;
ALTER TABLE formado.aluno_formado RENAME nome TO nome_completo;

ALTER TABLE formado.aluno_formado ALTER COLUMN nome TYPE VARCHAR(315);

ALTER TABLE formado.aluno_formado ALTER COLUMN cpf SET NOT NULL;
ALTER TABLE formado.aluno_formado ALTER COLUMN cpf DROP NOT NULL;

ALTER TABLE formado.aluno_formado ADD COLUMN teste INTEGER;
ALTER TABLE formado.aluno_formado DROP COLUMN teste;

ALTER TABLE formado.aluno_formado 
	ADD COLUMN matricula INTEGER,
	ALTER COLUMN matricula SET NOT NULL;
ALTER TABLE formado.aluno_formado ALTER COLUMN matricula SET NOT NULL;

ALTER TABLE formado.aluno_formado 
	ADD CONSTRAINT restricao_matricula 
	FOREIGN KEY (matricula) REFERENCES academico.formado (id);

SELECT nome, academico.formado.matricula
	FROM formado.aluno_formado
	JOIN academico.formado 
	ON academico.formado.id = formado.aluno_formado.matricula;

UPDATE formado.aluno_formado
  SET matricula = 3
  WHERE id = 3;


CREATE TEMPORARY TABLE cursos_programacao(
	id_curso INTEGER PRIMARY KEY,
	nome_curso VARCHAR(255) NOT NULL
);

INSERT INTO cursos_programacao
SELECT curso.id, curso.nome FROM academico.curso
	JOIN academico.categoria ON categoria.id = curso.categoria_id
	WHERE curso.categoria_id = 2

SELECt * FROM cursos_programacao

DROP TABLE formado.cursos;
CREATE TABLE formado.cursos(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL
);
DROP TABLE formado.cursos_basicos;
CREATE TABLE formado.cursos_basicos(
	id SERIAL PRIMARY KEY,
	nome_cursos VARCHAR(255) NOT NULL
);

INSERT INTO formado.cursos_basicos(nome_cursos) 
	VALUES	('Javascript básico'),('HTML básico'),('CSS básico'),
			('TypeScipt'),('Java'),('CSharp'),('Linux'), ('C++'),
			('Nodejs'),('React');

UPDATE formado.cursos SET nome = nome_cursos
	FROM formado.cursos_basicos WHERE cursos.id = cursos_basicos.id;

SELECT * FROM formado.cursos;
SELECT * FROM formado.cursos_basicos;

BEGIN;
DELETE FROM formado.cursos_basicos WHERE id = 8;
COMMIT;

BEGIN;
UPDATE formado.cursos SET nome = 'TypeScript intermediário'
	WHERE id = 4;
ROLLBACK;

/* -------------------- SEQUENCE -------------------- */
DROP TABLE auto;
CREATE TABLE auto(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL
);

INSERT INTO auto(nome) VALUES('qualquer');
INSERT INTO auto(id, nome) VALUES(2, 'novo texto');

INSERT INTO auto(nome) VALUES('qualquer 2');


CREATE SEQUENCE sequencia;

DROP TABLE auto_s;
CREATE TABLE auto_s(
	id INTEGER PRIMARY KEY DEFAULT NEXTVAL('sequencia'),
	nome VARCHAR(255) NOT NULL
);
SELECT * FROM auto_s;

INSERT INTO auto_s(nome) VALUES('qualquer');
INSERT INTO auto_s(id, nome) VALUES(2, 'novo texto');

INSERT INTO auto_s(nome) VALUES('qualquer 2');




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






