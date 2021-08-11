create table if not exists public.alternativa
(
	id bigint not null ,
	descricao varchar,
	ordem varchar,
	numeracao varchar,
	questao_id bigint not null,
	CONSTRAINT alternativa_pk PRIMARY KEY (id),
	CONSTRAINT questao_fk FOREIGN KEY (questao_id) REFERENCES public.questao (id)
);
create index if not exists alternativa_id_idx ON public.alternativa (id);
create index if not exists alternativa_descricao_idx ON public.alternativa (descricao);
create index if not exists alternativa_numercao_idx ON public.alternativa (numeracao);