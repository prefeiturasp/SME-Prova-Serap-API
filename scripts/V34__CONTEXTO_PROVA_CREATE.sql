create table if not exists public.contexto_prova
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_id int8 NOT NULL,
	imagem varchar(250) NULL,
	posicionamento int null,
	ordem int not null,
	titulo varchar(100) not NULL,
	texto varchar(500) not NULL,
	CONSTRAINT contexto_prova_pk PRIMARY KEY (id),
	CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);

create index if not exists cp_prova_idx ON public.contexto_prova(prova_id);