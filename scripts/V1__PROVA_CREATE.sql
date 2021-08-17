create table if not exists public.prova
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	prova_legado_id bigint not null,
	descricao varchar(60),
	total_itens int4,
	inicio timestamp without time zone not null,
	fim timestamp without time zone not null,
	inclusao timestamp without time zone not null,
	CONSTRAINT prova_pk PRIMARY KEY (id)
);
create index if not exists prova_legado_id_idx ON public.prova (prova_legado_id);
create index if not exists prova_inicio_idx ON public.prova (inicio);
create index if not exists prova_fim_idx ON public.prova (fim);