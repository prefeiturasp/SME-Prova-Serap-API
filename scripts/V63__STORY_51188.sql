
alter table prova add column if not exists tipo_prova_id int8;

CREATE table if not exists public.tipo_prova (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	legado_id int8 NOT NULL,
	descricao varchar(500) NOT NULL,
	para_estudante_com_deficiencia bool NOT NULL,
	criado_em timestamptz NOT NULL,
	atualizado_em timestamptz NOT NULL
);

CREATE table if not exists public.tipo_deficiencia (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	legado_id uuid NOT NULL,
	codigo_eol int8 NOT NULL,
	nome varchar(500) NOT NULL,
	criado_em timestamptz NOT NULL,
	atualizado_em timestamptz NOT NULL
);

CREATE table if not exists public.aluno_deficiencia (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	deficiencia_id int8 NOT NULL,
	aluno_ra int8 NOT NULL,
	criado_em timestamptz NOT NULL,
	atualizado_em timestamptz NOT NULL
);

CREATE table if not exists public.tipo_prova_deficiencia (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	deficiencia_id int8 NOT NULL,
	tipo_prova_id int8 NOT NULL,
	criado_em timestamptz NOT NULL,
	atualizado_em timestamptz NOT NULL
);

CREATE table if not exists public.questao_audio (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	questao_id int8 NOT NULL,
	arquivo_id int8 NOT NULL
);


insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'dc99b672-d288-439b-a925-07c0f89f3410',1,   'ALTAS HABILIDADES/SUPERDOTACAO',		now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 1);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '759bbf3e-f865-4059-9df6-4303c9802c5f',	2,	'AUTISMO'							,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 2);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'a991b05d-a078-41e5-aef2-a33df5192481',	5,	'SURDEZ LEVE/MODERADA'				,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 5);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'd0b500cc-34f7-4777-a399-b22584016386',	6,	'SURDEZ SEVERA/PROFUNDA'			,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 6);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'e7cc6bc6-03e0-4434-aac4-817b464da059',	8,	'DEFICIENCIA INTELECTUAL'			,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 8);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '39e6dc61-2a3b-436e-872d-abb22aa161e7',	9,	'DEFICIENCIA MULTIPLA'				,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 9);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '1311e8a3-e5d6-4fe5-98a8-584ea05d1b43',	11,	'CEGUEIRA'							,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 11);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'd41c5e1b-4c69-4301-8ba6-3a152ae975b5',	12,	'BAIXA VISAO OU VISAO SUBNORMAL'	,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 12);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'f28d3d1c-6276-4cef-bd61-11984fe91b29',	14,	'SURDOCEGUEIRA'						,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 14);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '2180a0d3-b7d3-4f1d-83c7-85674b5c963f',	15,	'NAO POSSUI'						,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 15);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '7f49a8a4-59f3-422f-9889-eeed16ab9ec2',	16,	'TRANST DESINTEGRATIVO INFANCIA'	,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 16);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '07f837f7-1dc4-4996-9bcb-c6fa6c53e2f4',	17,	'SINDROME DE ASPERGER'				,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 17);	

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'fd5d9dbe-d27a-41de-ac9c-7c2fb9d83e30',	18,	'SINDROME DE RETT'					,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 18);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select 'd723b14f-5d5c-4491-be1d-14a2ce6b7561',	19,	'DEFIC. FISICA NAO CADEIRANTE'		,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 19);

insert into tipo_deficiencia (legado_id,codigo_eol,nome,criado_em,atualizado_em)
select '052e07de-a359-4485-b2ee-06f31c2378df',	20,	'DEFICIENCIA FÍSICA CADEIRANTE'		,now(),now() where not exists(select 1 from tipo_deficiencia where codigo_eol = 20);


