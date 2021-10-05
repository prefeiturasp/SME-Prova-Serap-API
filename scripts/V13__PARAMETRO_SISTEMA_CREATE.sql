create table if not exists public.parametro_sistema
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	ano int NOT NULL,
	tipo int NOT NULL,
	descricao varchar(256) NOT NULL,
    nome varchar(100) NOT NULL,
    valor varchar(100) NOT NULL,
	criado_em timestamptz not null,
	CONSTRAINT parametro_sistema_pk PRIMARY KEY (id)
);
