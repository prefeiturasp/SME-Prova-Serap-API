CREATE OR REPLACE PROCEDURE public.p_consolidar_dados_prova(p_prova_serap_id bigint, p_dre_codigo_eol character varying, p_ue_codigo_eol character varying)
 LANGUAGE sql
AS $procedure$

insert into resultado_prova_consolidado 
(prova_serap_id,prova_serap_estudantes_id,dre_codigo_eol,dre_sigla,dre_nome,
ue_codigo_eol,ue_nome,turma_ano_escolar,turma_ano_escolar_descricao,
turma_codigo,turma_descricao,aluno_codigo_eol,aluno_nome,aluno_sexo,
aluno_data_nascimento,prova_componente,prova_caderno,prova_quantidade_questoes,
aluno_frequencia,questao_id,questao_ordem,resposta,prova_data_inicio,prova_data_entregue) 
select distinct 
vape.prova_serap_id,vape.prova_serap_estudantes_id,vape.dre_codigo_eol,vape.dre_sigla,vape.dre_nome,
vape.ue_codigo_eol,vape.ue_nome,vape.turma_ano_escolar,vape.turma_ano_escolar_descricao,
vape.turma_codigo,vape.turma_descricao,vape.aluno_codigo_eol,vape.aluno_nome,vape.aluno_sexo,
vape.aluno_data_nascimento,vape.prova_componente,vape.prova_caderno,vape.prova_quantidade_questoes,
vape.aluno_frequencia,q.id as questao_id,q.ordem + 1 as questao_ordem,
case
	when qar.alternativa_id is not null then a.numeracao
	else qar.resposta
end as resposta
,prova_data_inicio,prova_data_entregue
from v_aluno_prova_extracao vape
inner join prova p on vape.prova_serap_estudantes_id = p.id
inner join questao q on vape.prova_serap_estudantes_id = q.prova_id 
and (not p.possui_bib or (p.possui_bib and vape.prova_caderno = q.caderno)) 
left join questao_aluno_resposta qar on q.id = qar.questao_id and vape.aluno_codigo_eol = qar.aluno_ra
left join alternativa a on qar.alternativa_id = a.id
where vape.prova_serap_id = p_prova_serap_id and vape.dre_codigo_eol = p_dre_codigo_eol and vape.ue_codigo_eol = p_ue_codigo_eol;


$procedure$
;