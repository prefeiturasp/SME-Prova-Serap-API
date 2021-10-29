create table if not exists public.aluno
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	nome varchar(200) null,
    ra int8 not null,
    ultimo_login timestamp without time zone not null,
	CONSTRAINT aluno_pk PRIMARY KEY (id)
);