insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select 'AAD9D772-41A3-E411-922D-782BCB3D218E',	'Administrador',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = 'AAD9D772-41A3-E411-922D-782BCB3D218E');

insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select '104F0759-87E8-E611-9541-782BCB3D218E',	'Administrador Serap DRE',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = '104F0759-87E8-E611-9541-782BCB3D218E');

insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select '22366A3E-9E4C-E711-9541-782BCB3D218E',	'Administrador - NTA',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = '22366A3E-9E4C-E711-9541-782BCB3D218E');

insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select 'ECF7A20D-1A1E-E811-B259-782BCB3D2D76',	'Assistente de Diretor na UE',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = 'ECF7A20D-1A1E-E811-B259-782BCB3D2D76');

insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select 'D4026F2C-1A1E-E811-B259-782BCB3D2D76',	'Coordenador Pedagógico',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = 'D4026F2C-1A1E-E811-B259-782BCB3D2D76');

insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select '75DCAB30-2C1E-E811-B259-782BCB3D2D76',	'Diretor Escolar',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = '75DCAB30-2C1E-E811-B259-782BCB3D2D76');

insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select '4318D329-17DC-4C48-8E59-7D80557F7E77',	'Administrador Serap na UE',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = '4318D329-17DC-4C48-8E59-7D80557F7E77');