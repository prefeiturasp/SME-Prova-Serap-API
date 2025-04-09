CREATE table if not exists public.habilidade (
	id int4 NULL,
	descricao varchar(512) NULL,
	codigo varchar(50) NULL,
	eh_pai int4 NULL,
	criado_em varchar(50) NULL,
	alterado_em varchar(50) NULL,
	estado int4 NULL,
	"EvaluationMatrix_Id" int4 NULL,
	"ModelSkillLevel_Id" int4 NULL,
	"Parent_Id" varchar(50) NULL,
	"CognitiveCompetence_Id" varchar(50) NULL,
	integracao_id varchar(50) NULL,
	"integracaoSkillItensNaoVisiveis_id" varchar(50) NULL,
	bd_itens_id varchar(50) NULL
);