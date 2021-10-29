create table if not exists public.ue
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	ue_id varchar(15) NOT NULL,
    dre_id int8 NOT NULL,	
	nome varchar(200) NOT NULL,
    tipo_escola int2 NOT NULL,
	data_atualizacao timestamp not NULL,
	CONSTRAINT ue_pk PRIMARY KEY (id)
);