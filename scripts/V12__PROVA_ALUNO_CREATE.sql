create table if not exists public.prova_aluno
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_id int8 NOT NULL,
	aluno_ra int8 NOT NULL,
	status int NOT NULL,
	criado_em timestamptz not null,
	CONSTRAINT prova_aluno_pk PRIMARY KEY (id),
	CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);

create index if not exists pa_prova_idx ON public.prova_aluno(prova_id);
create index if not exists pa_aluno_idx ON public.prova_aluno(aluno_ra);