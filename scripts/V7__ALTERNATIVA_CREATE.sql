create table if not exists public.alternativa
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	descricao varchar,
	ordem int,
	numeracao varchar,
	questao_id bigint not null,
	CONSTRAINT alternativa_pk PRIMARY KEY (id),
	CONSTRAINT questao_fk FOREIGN KEY (questao_id) REFERENCES public.questao (id)
);
