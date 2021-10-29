create table if not exists public.usuario
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	nome varchar(200) null,
    login int8 not null,
    ultimo_login timestamp without time zone not null,
	criado_em timestamp without time zone not null,
	CONSTRAINT usuario_pk PRIMARY KEY (id)
);

ALTER TABLE  if exists public.aluno DROP COLUMN IF EXISTS ultimo_login;