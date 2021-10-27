create table if not exists public.caderno_aluno
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_id int8 NOT NULL,
	aluno_id int8 NOT NULL,
	caderno varchar(2) NOT NULL,
	CONSTRAINT caderno_aluno_pk PRIMARY KEY (id),
	CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id),
    CONSTRAINT aluno_id_fk FOREIGN KEY (aluno_id) REFERENCES public.aluno (id)
);

create index if not exists ca_prova_idx ON public.caderno_aluno(prova_id);
create index if not exists ca_aluno_idx ON public.caderno_aluno(aluno_id);