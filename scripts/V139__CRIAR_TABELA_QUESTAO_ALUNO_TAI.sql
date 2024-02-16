CREATE TABLE IF NOT EXISTS public.questao_aluno_tai (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	questao_id int8 NOT NULL,
	aluno_id int8 NOT NULL,
	ordem int4 NOT NULL,
	criado_em timestamptz NOT NULL,
	CONSTRAINT questao_aluno_tai_pk PRIMARY KEY (id),
	CONSTRAINT questao_id_fk FOREIGN KEY (questao_id) REFERENCES public.questao(id),
	CONSTRAINT aluno_id_fk FOREIGN KEY (aluno_id) REFERENCES public.aluno(id)
);
CREATE INDEX IF NOT EXISTS idx_questao_aluno_tai_f1 ON public.questao_aluno_tai USING btree (aluno_id) INCLUDE (questao_id, ordem);