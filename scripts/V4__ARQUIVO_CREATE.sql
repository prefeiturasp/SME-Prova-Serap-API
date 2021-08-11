create table if not exists public.arquivo
(
	id bigint not null,
	nome varchar(100),
	nome_original varchar(100),
	caminho varchar(100),
	arquivo_tipo varchar(100),
	CONSTRAINT arquivo_pk PRIMARY KEY (id)
);
