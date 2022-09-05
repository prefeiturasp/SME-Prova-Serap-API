create table if not exists public.prova_aluno_reabertura
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	prova_id bigint not null,
	login_serap varchar(60) not null,
	grupo_serap varchar(500) not null,
	aluno_ra  int8 not null,
	criado_em timestamp without time zone not null,
	alterado_em timestamp without time zone, 
	CONSTRAINT reabertura_pk PRIMARY KEY (id)
);

ALTER TABLE public.prova_aluno_reabertura ADD CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES prova(id);

