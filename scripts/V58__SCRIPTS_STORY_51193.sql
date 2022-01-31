create table if not exists public.exportacao_resultado_item
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	exportacao_resultado_id bigint not null,
	dre_codigo_eol varchar(15) not null,
	ue_codigo_eol text not null,
	criado_em timestamptz not null
);

CREATE OR REPLACE PROCEDURE public.p_consolidar_dados_prova(p_prova_serap_id bigint, p_dre_codigo_eol varchar(15), p_ue_codigo_eol varchar(15))
 LANGUAGE sql
AS $procedure$

insert into resultado_prova_consolidado 
(prova_serap_id,prova_serap_estudantes_id,dre_codigo_eol,dre_sigla,dre_nome,
ue_codigo_eol,ue_nome,turma_ano_escolar,turma_ano_escolar_descricao,
turma_codigo,turma_descricao,aluno_codigo_eol,aluno_nome,aluno_sexo,
aluno_data_nascimento,prova_componente,prova_caderno,prova_quantidade_questoes,
aluno_frequencia,questao_id,questao_ordem,resposta) 
select 
vape.prova_serap_id,vape.prova_serap_estudantes_id,vape.dre_codigo_eol,vape.dre_sigla,vape.dre_nome,
vape.ue_codigo_eol,vape.ue_nome,vape.turma_ano_escolar,vape.turma_ano_escolar_descricao,
vape.turma_codigo,vape.turma_descricao,vape.aluno_codigo_eol,vape.aluno_nome,vape.aluno_sexo,
vape.aluno_data_nascimento,vape.prova_componente,vape.prova_caderno,vape.prova_quantidade_questoes,
vape.aluno_frequencia,q.id as questao_id,q.ordem + 1 as questao_ordem,
case
	when qar.alternativa_id is not null then a.numeracao
	else qar.resposta
end as resposta
from v_aluno_prova_extracao vape 
inner join questao q on vape.prova_serap_estudantes_id = q.prova_id and vape.prova_caderno = q.caderno 
left join questao_aluno_resposta qar on q.id = qar.questao_id and vape.aluno_codigo_eol = qar.aluno_ra
left join alternativa a on qar.alternativa_id = a.id
where vape.prova_serap_id = p_prova_serap_id and vape.dre_codigo_eol = p_dre_codigo_eol and vape.ue_codigo_eol = p_ue_codigo_eol;


$procedure$
;

CREATE OR REPLACE PROCEDURE public.p_excluir_dados_consolidados_prova(p_prova_serap_id bigint, p_dre_codigo_eol varchar(15), p_ue_codigo_eol varchar(15))
 LANGUAGE sql
AS $procedure$

delete from resultado_prova_consolidado 
                                where prova_serap_id = p_prova_serap_id
                                and dre_codigo_eol = p_dre_codigo_eol
                                and ue_codigo_eol = p_ue_codigo_eol;

$procedure$
;


CREATE OR REPLACE FUNCTION public.f_extracao_prova_resposta(p_prova_serap_id bigint, p_dre_codigo_eol varchar(15))
returns table (
	ProvaSerapId int8,
	ProvaSerapEstudantesId int8,
	DreCodigoEol varchar(15), 
	DreSigla varchar(10),
	DreNome varchar(100),
	UeCodigoEol varchar(15),
	UeNome text,
	TurmaAnoEscolar varchar(1),
	TurmaAnoEscolarDescricao varchar,
	TurmaCodigo varchar(15),
	TurmaDescricao varchar(20),
	AlunoCodigoEol int8,
	AlunoNome varchar(200),
	AlunoSexo varchar(2),
	AlunoDataNascimento timestamptz,
	ProvaComponente varchar(50),
	ProvaCaderno varchar,
	ProvaQuantidadeQuestoes int4,
	AlunoFrequencia text,  
	QuestaoId int8, 
	QuestaoOrdem int4,
	resposta varchar
) 
language plpgsql
AS $$
begin
	return query
	select
	rpc.prova_serap_id ProvaSerapId,
    rpc.prova_serap_estudantes_id ProvaSerapEstudantesId,
	rpc.dre_codigo_eol DreCodigoEol, 
	rpc.dre_sigla DreSigla,
	rpc.dre_nome DreNome,
	rpc.ue_codigo_eol UeCodigoEol,
	rpc.ue_nome UeNome,
	rpc.turma_ano_escolar TurmaAnoEscolar,
	rpc.turma_ano_escolar_descricao TurmaAnoEscolarDescricao,
	rpc.turma_codigo TurmaCodigo,
	rpc.turma_descricao TurmaDescricao,
	rpc.aluno_codigo_eol AlunoCodigoEol,
	rpc.aluno_nome AlunoNome,
	rpc.aluno_sexo AlunoSexo,
	rpc.aluno_data_nascimento AlunoDataNascimento,
	rpc.prova_componente ProvaComponente,
	rpc.prova_caderno ProvaCaderno,
    rpc.prova_quantidade_questoes as ProvaQuantidadeQuestoes,
	rpc.aluno_frequencia AlunoFrequencia,  
	rpc.questao_id as QuestaoId, 
	rpc.questao_ordem as QuestaoOrdem,
	rpc.resposta
from resultado_prova_consolidado rpc 
where rpc.prova_serap_id = p_prova_serap_id
    and rpc.dre_codigo_eol = p_dre_codigo_eol;

end
$$;