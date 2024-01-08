CREATE TABLE public.questao_aluno_administrado (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	questao_id int8 NOT NULL,
	aluno_id int8 NOT NULL,
	ordem int4 NOT NULL,
	criado_em timestamptz NOT NULL,
	CONSTRAINT questao_aluno_administrado_pk PRIMARY KEY (id),
	CONSTRAINT questao_id_fk FOREIGN KEY (questao_id) REFERENCES public.questao(id),
	CONSTRAINT aluno_id_fk FOREIGN KEY (aluno_id) REFERENCES public.aluno(id)
);
CREATE INDEX idx_questao_aluno_administrado_f1 ON public.questao_aluno_administrado USING btree (aluno_id) INCLUDE (questao_id, ordem);