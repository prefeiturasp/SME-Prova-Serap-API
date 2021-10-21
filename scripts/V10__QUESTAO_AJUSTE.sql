drop table public.questao cascade;

create table if not exists public.questao
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	titulo varchar not null,
	questao_legado_id int8 NOT NULL,
	descricao varchar null,
	ordem int4 not null,
	prova_id int8 not null,
	CONSTRAINT questao_pk PRIMARY KEY (id),
	CONSTRAINT prova_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);
create index if not exists questao_prova_idx ON public.questao(prova_id);


drop table if exists public.prova_arquivo ;
drop table if exists public.arquivo ;


create table if not exists public.arquivo
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,	
	caminho varchar(500),
	tamanho_bytes int8,
	legado_id int8,
	CONSTRAINT arquivo_pk PRIMARY KEY (id)
);

create index if not exists arquivo_id_legado_idx ON public.arquivo(legado_id);


create table if not exists public.questao_arquivo
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	questao_id bigint not null ,
	arquivo_id bigint not null ,
	CONSTRAINT questao_arquivo_pk PRIMARY KEY (id),
	CONSTRAINT arquivo_fk FOREIGN KEY (arquivo_id) REFERENCES public.arquivo(id),
	CONSTRAINT questao_fk FOREIGN KEY (questao_id) REFERENCES public.questao (id)
);

create index if not exists questao_arquivo_questao_id_idx ON public.questao_arquivo (questao_id);
create index if not exists questao_arquivo_arquivo_id_idx ON public.questao_arquivo (arquivo_id);



create table if not exists public.alternativa_arquivo
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	alternativa_id bigint not null ,
	arquivo_id bigint not null ,
	CONSTRAINT alternativa_arquivo_pk PRIMARY KEY (id),
	CONSTRAINT arquivo_fk FOREIGN KEY (arquivo_id) REFERENCES public.arquivo(id),
	CONSTRAINT alternativa_fk FOREIGN KEY (alternativa_id) REFERENCES public.alternativa (id)
);

create index if not exists alternativa_arquivo_alternativa_id_idx ON public.alternativa_arquivo (alternativa_id);
create index if not exists alternativa_arquivo_arquivo_id_idx ON public.alternativa_arquivo (arquivo_id);

