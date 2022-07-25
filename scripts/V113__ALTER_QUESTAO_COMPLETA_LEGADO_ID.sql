ALTER TABLE questao_completa ADD if not exists questao_legado_id int8 NULL;
update questao_completa set ultima_atualizacao = '2019-01-01 00:00:00' where ultima_atualizacao is not null;