CREATE TABLE if not exists public.turma_aluno_historico (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	turma_id int8 NOT NULL,
	ano_letivo int4 NOT NULL,
	aluno_id int8 NOT NULL,
	criado_em timestamptz NOT NULL,
	atualizado_em timestamptz NOT NULL,
	data_matricula timestamp NULL,
	data_situacao timestamp NULL,
	CONSTRAINT turma_aluno_historico_pk PRIMARY KEY (id)
	CONSTRAINT turma_aluno_historico_aluno_id_fk FOREIGN KEY (aluno_id) REFERENCES public.aluno(id),
	CONSTRAINT turma_aluno_historico_turma_id_fk FOREIGN KEY (turma_id) REFERENCES public.turma (id)
);