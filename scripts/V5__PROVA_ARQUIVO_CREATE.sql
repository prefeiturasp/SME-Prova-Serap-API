create table if not exists public.prova_arquivo
(
	id bigint not null ,
	prova_id bigint not null ,
	arquivo_id bigint not null ,
	status int4,
	CONSTRAINT prova_arquivo_pk PRIMARY KEY (id),
	CONSTRAINT arquivo_fk FOREIGN KEY (arquivo_id) REFERENCES public.arquivo (id),
	CONSTRAINT prova_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);
create index if not exists prova_arquivo_id_idx ON public.prova_arquivo (id);
create index if not exists prova_arquivo_status_idx ON public.prova_arquivo (status);
create index if not exists prova_arquivo_prova_id_idx ON public.prova_arquivo (prova_id);
create index if not exists prova_arquivo_arquivo_id_idx ON public.prova_arquivo (arquivo_id);