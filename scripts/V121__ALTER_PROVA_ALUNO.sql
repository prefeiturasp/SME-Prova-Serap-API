ALTER TABLE prova_aluno ADD COLUMN IF NOT exists criado_em_servidor timestamp NULL;
ALTER TABLE prova_aluno ADD COLUMN IF NOT exists finalizado_em_servidor timestamp NULL;

INSERT INTO parametro_sistema (ano,tipo,descricao,nome,valor, criado_em) 
VALUES (2022,16,'tolerância de diferença de horário do dispositivo para o servidor em minutos','ToleranciaDataHoraServidor','10', current_timestamp);