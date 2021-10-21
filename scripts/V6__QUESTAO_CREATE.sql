create table if not exists public.questao
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	titulo varchar,
	questao_legado_id int8 NOT NULL,
	descricao varchar,
	ordem varchar,
	CONSTRAINT questao_pk PRIMARY KEY (id)
);
