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
	p.disciplina as prova_componente,
	case 
		when p.possui_bib then ca.caderno 
		else ''
	end as prova_caderno,
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