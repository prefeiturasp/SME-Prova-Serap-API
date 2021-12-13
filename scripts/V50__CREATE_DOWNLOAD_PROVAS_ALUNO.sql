create table if not exists public.downloads_prova_aluno
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_id int8 NOT NULL,
	aluno_ra int8 NOT NULL,
	situacao int NOT NULL,
	dispositivo_id varchar (200),
	modelo_dispositivo varchar(200),
	tipo_dispositivo int not null,
	versao varchar (200),
	criado_em timestamptz not null,
	alterado_em timestamptz default null,
	CONSTRAINT downloads_prova_aluno_id_pk PRIMARY KEY (id),
	CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);

create index if not exists pa_prova_idx ON public.downloads_prova_aluno using btree (prova_id);
create index if not exists pa_aluno_idx ON public.downloads_prova_aluno   USING btree (aluno_ra);