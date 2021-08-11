create table if not exists public.questao
(
	id bigint not null ,
	titulo varchar,
	descricao varchar,
	ordem varchar,
	CONSTRAINT questao_pk PRIMARY KEY (id)
);
create index if not exists questao_id_idx ON public.questao (id);
create index if not exists questao_descricao_idx ON public.questao (descricao);
create index if not exists questao_titulo_idx ON public.questao (titulo);
create index if not exists questao_ordem_idx ON public.questao (ordem);