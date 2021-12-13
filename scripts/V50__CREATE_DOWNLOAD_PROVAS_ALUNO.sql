create table if not exists public.downloads_prova_aluno
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_id int8 NOT NULL,
	aluno_id int8 NOT NULL,
	situacao int NOT NULL,
	modelo_dispositivo varchar(200),
	versao varchar (200),
	criado_em timestamptz not null,
	alterado_em timestamptz,
	CONSTRAINT downloads_prova_aluno_id_pk PRIMARY KEY (id),
	CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id),
	CONSTRAINT aluno_id_fk FOREIGN KEY (aluno_id) REFERENCES public.aluno (id)
);

create index if not exists pa_prova_idx ON public.downloads_prova_aluno(prova_id);
create index if not exists pa_aluno_idx ON public.downloads_prova_aluno(aluno_id);