drop function if exists p_consolidar_dados_prova;
CREATE OR REPLACE PROCEDURE public.p_consolidar_dados_prova(p_prova_serap_id bigint, p_dre_codigo_eol character varying, p_ue_codigo_eol character varying, p_turma_codigo_eol character varying)
 LANGUAGE sql
AS $procedure$

insert into resultado_prova_consolidado 
(prova_serap_id,prova_serap_estudantes_id,dre_codigo_eol,dre_sigla,dre_nome,
ue_codigo_eol,ue_nome,turma_ano_escolar,turma_ano_escolar_descricao,
turma_codigo,turma_descricao,aluno_codigo_eol,aluno_nome,aluno_sexo,
aluno_data_nascimento,prova_componente,prova_caderno,prova_quantidade_questoes,
aluno_frequencia,questao_id,questao_ordem,resposta,prova_data_inicio,prova_data_entregue) 
select 
vape.provaserapid,vape.provaserapestudantesid,vape.drecodigoeol,vape.dresigla,vape.drenome,
vape.uecodigoeol,vape.uenome,vape.turmaanoescolar,vape.turmaanoescolardescricao,
vape.turmacodigo,vape.turmadescricao,vape.alunocodigoeol,vape.alunonome,vape.alunosexo,
vape.alunodatanascimento,vape.provacomponente,vape.provacaderno,vape.provaquantidadequestoes,
vape.alunofrequencia,q.id as questaoid,q.ordem + 1 as questao_ordem,
case
	when qar.alternativa_id is not null then a.numeracao
	else qar.resposta
end as resposta
,vape.provadatainicio,vape.provadataentregue
from f_dados_prova_alunos_turma(p_prova_serap_id,p_dre_codigo_eol,p_ue_codigo_eol,p_turma_codigo_eol) vape
inner join prova p on vape.provaserapestudantesid = p.id
inner join questao q on vape.provaserapestudantesid = q.prova_id 
and (not p.possui_bib or (p.possui_bib and vape.provacaderno = q.caderno))
left join f_questao_aluno_resposta_prova_turma(p_prova_serap_id,p_turma_codigo_eol) qar on q.id = qar.questao_id and vape.alunocodigoeol = qar.aluno_ra
left join alternativa a on qar.alternativa_id = a.id
where vape.provaserapid = p_prova_serap_id and vape.drecodigoeol = p_dre_codigo_eol and vape.uecodigoeol = p_ue_codigo_eol;


$procedure$
;
