drop MATERIALIZED view if exists v_prova_detalhes;

create MATERIALIZED view v_prova_detalhes as
select
	p.id as provaId,
	q.id  as questaoId,
	alt.id as alternativaId,
	arq.legado_id as arquivoId,
	arq.tamanho_bytes as arquivoTamanho		
from
	prova p
inner join questao q on
	q.prova_id = p.id
left join alternativa alt on
	alt.questao_id = q.id
left join questao_arquivo qa on
	qa.questao_id = q.id
left join arquivo arq on
	qa.arquivo_id = arq.id;


drop view if exists v_prova_bib_detalhes;

create view v_prova_bib_detalhes as
select
	p.id as provaId,
    a.ra as alunoRa,
	q.id  as questaoId,
	alt.id as alternativaId,
	arq.legado_id as arquivoId,
	arq.tamanho_bytes as arquivoTamanho		
from
    prova p
inner join caderno_aluno ca on 
    p.id = ca.prova_id
inner join aluno a on 
    ca.aluno_id = a.id
inner join questao q on
    q.prova_id = p.id and ca.caderno = q.caderno
left join alternativa alt on
    alt.questao_id = q.id
left join questao_arquivo qa on
    qa.questao_id = q.id
left join arquivo arq on
    qa.arquivo_id = arq.id;