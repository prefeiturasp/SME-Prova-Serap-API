create table if not exists public.prova
(
	id bigint not null ,
	descricao varchar(60),
	total_itens int4,
	datainicio timestamp without time zone not null,
	datafim timestamp without time zone not null,
	CONSTRAINT prova_pk PRIMARY KEY (id)
);
create index if not exists prova_id_idx ON public.prova (id);
create index if not exists prova_descricao_idx ON public.prova (descricao);
create index if not exists prova_datainicio_idx ON public.prova (datainicio);
create index if not exists prova_datafim_idx ON public.prova (datafim);
create index if not exists prova_total_itens_idx ON public.prova (total_itens);