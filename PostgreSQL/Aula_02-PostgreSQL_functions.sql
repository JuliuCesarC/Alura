CREATE TABLE pessoa(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(255) NOT NULL,
	data_nascimento DATE NOT NULL
)
INSERT INTO pessoa(nome, data_nascimento) 
	VALUES('Jão Paulo', '1995-08-07'), ('Jenfiner Malbec', '1997-11-21'),
			('Lusca Calvo', '1983-02-17');

/* Concatenando strings */
SELECT (primeiro_nome || ' ' || sobrenome) AS "Nome completo" From aluno;
-- Caso algum campo tenha um valor nulo, o retorno sera nulo tambem.
-- Para resolver este proble, podemos utilizar o CONCAT, pois ele 
-- ignora os valores nulos.

SELECT CONCAT('Jão', null, ' ', 'silva');

SELECT UPPER(CONCAT('este texto esta todo em maiusculo'));
SELECT UPPER('substring');

SELECT TRIM('  Este texto não possui espaços no começo ou final    ')

SELECT ('Comprimento total deste texto = ' || 
		char_length('Comprimento total deste texto') ||
	   ' caracteres.')

SELECT ('Espaço ocupado por este texto = ' || 
		bit_length('Espaço ocupado por este texto') ||
	   ' bytes.')

SELECT ('A palavra GMAIL começa na posição: ' || 
		position ('GMAIL' IN 'A palavra GMAIL começa na posição'))

SELECT substring ('Lorem ipsum dolor sit amet.' FROM 4 FOR 12);
SELECT substring ('Lorem ipsum dolor sit amet.' FROM 15);
SELECT substring ('Lorem ipsum dolor sit amet.' FOR 9);



SELECT nome, data_nascimento, NOW() AS "Data atual" FROM pessoa;
SELECT NOW()::DATE AS "Data atual" FROM pessoa;
SELECT EXTRACT(year FROM NOW()) AS "Data atual" FROM pessoa;
SELECT EXTRACT(week FROM NOW()) AS "Data atual";

SELECT TO_CHAR(NOW(), 'DD/MM/YYYY') AS "Data atual";
SELECT to_char(NOW(), 'HH12:MI Month') AS "Data atual";

SELECT nome,
		AGE(data_nascimento) AS Idade
	FROM pessoa;

SELECT nome,
		EXTRACT(year FROM AGE(data_nascimento)) AS Idade
	FROM pessoa;

SELECT power(2, 4);

SELECT round(32.499999999999999999)

SELECT trunc(35.418896185, 3)

SELECT log(100)

SELECT random()
