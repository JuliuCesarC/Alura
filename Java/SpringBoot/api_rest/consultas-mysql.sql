SELECT * from flyway_schema_history;

DELETE FROM flyway_schema_history WHERE success = 0;

delete from flyway_schema_history WHERE success = 1;

SELECT * FROM pacientes;

SELECT * FROM medicos;

DESC medicos;

Update medicos set ativo = 1 where id > 0;

select * from usuarios;

Insert into usuarios values(3, 'jao@voll.med', '$2a$10$Y50UaMFOxteibQEYLrwuHeehHYfcoafCopUazP12.rqB41bsolF5.', 'USER');

Insert into usuarios values(1, 'admin@ad.min', '$2a$10$Y50UaMFOxteibQEYLrwuHeehHYfcoafCopUazP12.rqB41bsolF5.', 'ADMIN');

Insert into usuarios values(2, 'jenifer@voll.med', '$2a$10$Y50UaMFOxteibQEYLrwuHeehHYfcoafCopUazP12.rqB41bsolF5.', 'MANAGER');

delete from usuarios where id >0;

ALTER TABLE usuarios
DROP COLUMN cargo;

SELECT motivo_cancelamento FROM consultas;

SELECT * FROM consultas;

select id from medicos
        where
        ativo = 1
        and
        especialidade = 'CARDIOLOGIA'
        and
        id not in(
            select medicos.id from consultas
            where
            data = '2023-06-17 08:00'
            and
            motivo_cancelamento is null
        )
        order by rand()
        limit 1;


