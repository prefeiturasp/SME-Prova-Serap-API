

--Script que gera inserts com base no ano anterior
--select 'Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (' ||2024||','|| tipo ||',' || ''''|| descricao || '''' ||',' || ''''|| nome|| '''' ||',' || ''''|| valor|| ''''||',' || 'now()' ||')'||';' 
 --from parametro_sistema ps   where ano = 2023
 
 
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,15,'Tipos de escolas','TipoEscolaSerap','1,2,3,4,10,11,12,13,14,15,16,17,18,19,22,23,25,26,27,28,29,30,31',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,16,'tolerancia de diferença de horario do dispositivo para o servidor em minutos','ToleranciaDataHoraServidor','10',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,1,'Início da prova no turno da manhã','InicioProvaTurnoManha','07',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,2,'Início da prova no turno intermediário','InicioProvaTurnoIntermediario','9',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,3,'Início da prova no turno da Tarde','InicioProvaTurnoTarde','12',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,4,'Tempo extra para a prova, em segundos','TempoExtraProva','600',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,5,'Tempo de alerta que a prova está finalizando, em segundos','TempoAlertaProva','300',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,6,'Fim da prova no turno da manhã','FimProvaTurnoManha','13',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,7,'Fim da prova no turno intermediario','FimProvaTurnoIntermediario','17',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,8,'Fim da prova no turno tarde','FimProvaTurnoTarde','19',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,9,'Início da prova no turno vespertino','InicioProvaTurnoVespertino','12',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,10,'Início da prova no turno noite','InicioProvaTurnoNoite','18',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,11,'Início da prova no turno integral','InicioProvaTurnoIntegral','07',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,12,'Fim da prova no turno vespertino','FimProvaTurnoVespertino','19',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,13,'Fim da prova no turno noite','FimProvaTurnoNoite','23',now());
Insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)  VALUES (2024,14,'Fim da prova no turno integral','FimProvaTurnoIntegral','19',now());