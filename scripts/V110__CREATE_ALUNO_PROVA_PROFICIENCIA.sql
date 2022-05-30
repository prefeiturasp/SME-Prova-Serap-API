CREATE TABLE if not exists public.aluno_prova_proficiencia (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	prova_id int8 NOT NULL,
	aluno_id int8 NOT NULL,
	disciplina_id int8 NULL,
	proficiencia numeric NOT NULL,
	ra int8 NOT NULL,
	origem int4 NOT NULL,
	tipo int4 NOT NULL,
	CONSTRAINT aluno_prova_proficiencia_pk PRIMARY KEY (id)
);

ALTER TABLE public.aluno_prova_proficiencia ADD CONSTRAINT aluno_prova_proficiencia_aluno_fk FOREIGN KEY (aluno_id) REFERENCES public.aluno(id);
ALTER TABLE public.aluno_prova_proficiencia ADD CONSTRAINT aluno_prova_proficiencia_prova_fk FOREIGN KEY (prova_id) REFERENCES public.prova(id);