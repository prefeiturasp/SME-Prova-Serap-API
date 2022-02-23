alter table resultado_prova_consolidado add column if not exists prova_data_inicio timestamptz null;
alter table resultado_prova_consolidado add column if not exists prova_data_entregue timestamptz null;
alter table prova add column if not exists multidisciplinar bool null;

drop view if exists v_aluno_prova_extracao;
create view v_aluno_prova_extracao as 
select 
	 p.prova_legado_id as prova_serap_id,
   p.id as prova_serap_estudantes_id,
	 dre.dre_id dre_codigo_eol, 
	 dre.abreviacao dre_sigla,
	 dre.nome dre_nome,
	 ue.ue_id as ue_codigo_eol,
	 case 
	 	when tipo_escola = 1 then 'EMEF'
	 	when tipo_escola = 2 then 'EMEI'
	 	when tipo_escola = 3 then 'EMEFM'
	 	when tipo_escola = 4 then 'EMEBS'
	 	when tipo_escola = 10 then 'CEI DIRET'
	 	when tipo_escola = 11 then 'CEI INDIR'
	 	when tipo_escola = 12 then 'CR.P.CONV'
	 	when tipo_escola = 13 then 'CIEJA'
	 	when tipo_escola = 14 then 'CCI/CIPS'
	 	when tipo_escola = 15 then 'ESC.PART.'
	 	when tipo_escola = 16 then 'CEU EMEF'
	 	when tipo_escola = 17 then 'CEU EMEI'
	 	when tipo_escola = 18 then 'CEU CEI'
	 	when tipo_escola = 19 then 'CEU'
	 	when tipo_escola = 22 then 'MOVA'
	 	when tipo_escola = 23 then 'CMCT'
	 	when tipo_escola = 25 then 'E TEC'
	 	when tipo_escola = 26 then 'ESP CONV'
	 	when tipo_escola = 27 then 'CEU AT COMPL'
	 	when tipo_escola = 29 then 'CCA'
	 	when tipo_escola = 28 then 'CEMEI'
	 	when tipo_escola = 30 then 'CECI'
	 	when tipo_escola = 31 then 'CEU CEMEI'
	end || ' ' || ue.nome as ue_nome,
	t.ano as turma_ano_escolar,
	case 
		when t.ano <> 'S' then t.ano || '° ano' 
		else t.ano 
	end as turma_ano_escolar_descricao,
	t.codigo as turma_codigo,
	t.nome as turma_descricao,
	a.ra as aluno_codigo_eol,
	case 
		when a.nome_social is not null then a.nome_social
		else a.nome 
	end as aluno_nome,
	a.sexo as aluno_sexo,
	a.data_nascimento as aluno_data_nascimento,
	case 
		when p.disciplina is null or p.multidisciplinar then 'Multidisciplinar'
		else p.disciplina 
	end as prova_componente,
	case 
		when p.possui_bib then ca.caderno 
		else ''
	end as prova_caderno,
	p.total_itens as prova_quantidade_questoes,
	palu.criado_em as prova_data_inicio,
	palu.finalizado_em as prova_data_entregue,
		case 
			when palu.frequencia = 0 then 'N'
			when palu.frequencia = 1 then 'P'
			when palu.frequencia = 2 then 'A'
			when palu.frequencia = 3 then 'R'
			else 'N'
		end as aluno_frequencia
from aluno a
inner join turma t 
	on a.turma_id = t.id
inner join ue 
	on t.ue_id = ue.id 
inner join dre 
	on ue.dre_id = dre.id 
inner join prova_ano pa on t.ano = pa.ano
inner join prova p on pa.prova_id = p.id 
left join prova_aluno palu on p.id = palu.prova_id and a.ra = palu.aluno_ra
left join caderno_aluno ca on p.id = ca.prova_id and a.id = ca.aluno_id ;

CREATE OR REPLACE PROCEDURE public.p_consolidar_dados_prova(p_prova_serap_id bigint, p_dre_codigo_eol varchar(15), p_ue_codigo_eol varchar(15))
 LANGUAGE sql
AS $procedure$

insert into resultado_prova_consolidado 
(prova_serap_id,prova_serap_estudantes_id,dre_codigo_eol,dre_sigla,dre_nome,
ue_codigo_eol,ue_nome,turma_ano_escolar,turma_ano_escolar_descricao,
turma_codigo,turma_descricao,aluno_codigo_eol,aluno_nome,aluno_sexo,
aluno_data_nascimento,prova_componente,prova_caderno,prova_quantidade_questoes,
aluno_frequencia,questao_id,questao_ordem,resposta,prova_data_inicio,prova_data_entregue) 
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
,prova_data_inicio,prova_data_entregue
from v_aluno_prova_extracao vape 
inner join questao q on vape.prova_serap_estudantes_id = q.prova_id and vape.prova_caderno = q.caderno 
left join questao_aluno_resposta qar on q.id = qar.questao_id and vape.aluno_codigo_eol = qar.aluno_ra
left join alternativa a on qar.alternativa_id = a.id
where vape.prova_serap_id = p_prova_serap_id and vape.dre_codigo_eol = p_dre_codigo_eol and vape.ue_codigo_eol = p_ue_codigo_eol;


$procedure$
;














