drop MATERIALIZED view if exists v_prova_detalhes;

drop view if exists v_prova_detalhes;

create view v_prova_detalhes as
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