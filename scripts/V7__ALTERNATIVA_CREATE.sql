create table if not exists public.alternativa
(
	id bigint not null ,
	descricao varchar,
	ordem int,
	numeracao varchar,
	questao_id bigint not null,
	CONSTRAINT alternativa_pk PRIMARY KEY (id),
	CONSTRAINT questao_fk FOREIGN KEY (questao_id) REFERENCES public.questao (id)
);
