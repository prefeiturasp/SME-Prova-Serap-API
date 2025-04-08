CREATE TABLE IF NOT EXISTS public.boletim_prova_aluno (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	dre_id int4 NULL,
	ue_codigo text NULL,
	ue_nome text NULL,
	prova_id int4 NULL,
	prova_descricao text NULL,
	ano_escolar int4 NULL,
	turma text NULL,
	aluno_ra int8 NULL,
	aluno_nome text NULL,
	disciplina text NULL,
	disciplina_id int8 NULL,
	status_prova int8 NULL,
	proficiencia numeric(10, 2) NULL,
	erro_medida numeric(10, 2) NULL,
	nivel_codigo int4 NULL
);