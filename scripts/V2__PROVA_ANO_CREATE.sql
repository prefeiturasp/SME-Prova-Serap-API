create table if not exists public.prova_ano
(
	id bigint not null ,
	prova_id bigint not null ,
	ano varchar(10),
	CONSTRAINT prova_ano_pk PRIMARY KEY (id),
	CONSTRAINT prova_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);
create index if not exists prova_ano_idx ON public.prova_ano (ano);
create index if not exists prova_prova_id_idx ON public.prova_ano (prova_id);