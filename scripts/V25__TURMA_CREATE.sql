create table if not exists public.turma
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	ano varchar(1) NOT NULL,
    ano_letivo int4 NOT NULL,
    codigo varchar(15) not null,
    ue_id int8 NOT NULL,
    tipo_turma int4 NOT NULL,
    modalidade_codigo int4 NOT NULL,	
	nome varchar(20) NOT NULL,  
    tipo_turno int2 NOT NULL,  
	data_atualizacao timestamp not NULL,
	CONSTRAINT turma_pk PRIMARY KEY (id)
);
create index if not exists turma_ano_idx ON public.turma (ano);
create index if not exists turma_codigo_idx ON public.turma (codigo);
create index if not exists turma_ue_idx ON public.turma (ue_id);

ALTER TABLE public.turma ADD CONSTRAINT turma_ue_id_fk FOREIGN KEY (ue_id) REFERENCES ue(id) ON DELETE CASCADE