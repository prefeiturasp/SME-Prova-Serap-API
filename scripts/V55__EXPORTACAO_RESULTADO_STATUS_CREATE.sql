create table if not exists public.exportacao_resultado
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	nome_arquivo varchar(100) not null,
	prova_serap_id bigint not null,
	status int not null,
	criado_em timestamptz not null,
	atualizado_em timestamptz not null,
	CONSTRAINT exportacao_resultado_pk PRIMARY KEY (id)
);


CREATE TABLE if not exists public.resultado_prova_consolidado (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_serap_id int8 NULL,
	prova_serap_estudantes_id int8 NULL,
	dre_codigo_eol varchar(15) NULL,
	dre_sigla varchar(10) NULL,
	dre_nome varchar(100) NULL,
	ue_codigo_eol varchar(15) NULL,
	ue_nome text NULL,
	turma_ano_escolar varchar(1) NULL,
	turma_ano_escolar_descricao varchar NULL,
	turma_codigo varchar(15) NULL,
	turma_descricao varchar(20) NULL,
	aluno_codigo_eol int8 NULL,
	aluno_nome varchar(200) NULL,
	aluno_sexo varchar(2) NULL,
	aluno_data_nascimento timestamptz NULL,
	prova_componente varchar(50) NULL,
	prova_caderno varchar NULL,
	prova_quantidade_questoes int4 NULL,
	aluno_frequencia text NULL,
	questao_id int8 NULL,
	questao_ordem int4 NULL,
	resposta varchar NULL
);