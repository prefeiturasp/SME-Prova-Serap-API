insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)
select 2021 ano, 15 tipo, 'Tipos de escolas' descricao, 
'TipoEscolaSerap' nome, '1,2,3,4,10,11,12,13,14,15,16,17,18,19,22,23,25,26,27,28,29,30,31' valor, now()::timestamp criado_em
where not exists (select 1 from parametro_sistema where ano = 2021 and tipo = 15);

insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)
select 2022 ano, 15 tipo, 'Tipos de escolas' descricao, 
'TipoEscolaSerap' nome, '1,2,3,4,10,11,12,13,14,15,16,17,18,19,22,23,25,26,27,28,29,30,31' valor, now()::timestamp criado_em
where not exists (select 1 from parametro_sistema where ano = 2022 and tipo = 15);

insert into parametro_sistema (ano, tipo, descricao, nome, valor, criado_em)
select 2023 ano, 15 tipo, 'Tipos de escolas' descricao, 
'TipoEscolaSerap' nome, '1,2,3,4,10,11,12,13,14,15,16,17,18,19,22,23,25,26,27,28,29,30,31' valor, now()::timestamp criado_em
where not exists (select 1 from parametro_sistema where ano = 2023 and tipo = 15);