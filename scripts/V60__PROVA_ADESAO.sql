create table if not exists public.prova_adesao
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	prova_id int8 not null,
	ue_id int8 not null,
	aluno_ra int8 not null,
	ano_turma varchar(5) not null,
	tipo_turma int8 not null,
	modalidade_codigo int8 not null,
	tipo_turno int8 not null,
	criado_em timestamptz not null,
	atualizado_em timestamptz not null,
	CONSTRAINT prova_adesao_pk PRIMARY KEY (id)
);