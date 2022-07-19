ALTER TABLE questao_completa ADD questao_legado_id int8 NULL;
update questao_completa set ultima_atualizacao = null where ultima_atualizacao is not null;