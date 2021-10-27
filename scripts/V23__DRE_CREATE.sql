create table if not exists public.Dre
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	dre_id varchar(15) NOT NULL,
	abreviacao varchar(10) NOT NULL,
	nome varchar(100) NOT NULL,
	data_atualizacao timestamp not NULL,
	CONSTRAINT dre_pk PRIMARY KEY (id)
);