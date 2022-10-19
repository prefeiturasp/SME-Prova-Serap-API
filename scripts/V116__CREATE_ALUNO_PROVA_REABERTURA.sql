CREATE TABLE IF NOT EXISTS public.prova_aluno_reabertura (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	prova_id int8 NOT NULL,
	login_coresso varchar(60) NOT NULL,
	usuario_id_coresso uuid NOT NULL,
	grupo_coresso uuid NOT NULL,
	aluno_ra int8 NOT NULL,
	criado_em timestamp NOT NULL,
	alterado_em timestamp NULL,
	CONSTRAINT reabertura_pk PRIMARY KEY (id)
);

ALTER TABLE public.prova_aluno_reabertura ADD CONSTRAINT prova_id_fk FOREIGN KEY (prova_id) REFERENCES public.prova(id);
