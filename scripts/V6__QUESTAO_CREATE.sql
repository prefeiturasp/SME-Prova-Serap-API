create table if not exists public.questao
(
	id bigint not null ,
	titulo varchar,
	descricao varchar,
	ordem varchar,
	CONSTRAINT questao_pk PRIMARY KEY (id)
);
