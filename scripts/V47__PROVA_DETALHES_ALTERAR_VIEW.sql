drop view if exists v_prova_detalhes;

create view v_prova_detalhes as
select
	p.id as provaId,
	q.id  as questaoId,
	alt.id as alternativaId,
	arqq.legado_id as questaoArquivoId,
	arqq.tamanho_bytes as questaoArquivoTamanho,
	arqa.legado_id as alternativaArquivoId,
	arqa.tamanho_bytes as alternativaArquivoTamanho
from
	prova p
inner join questao q on
	q.prova_id = p.id
left join alternativa alt on
	alt.questao_id = q.id
left join questao_arquivo qa on
	qa.questao_id = q.id
left join arquivo arqq on
	qa.arquivo_id = arqq.id
left join alternativa_arquivo aa on
	aa.alternativa_id = alt.id
left join arquivo arqa on
	aa.arquivo_id = arqa.id
order by 1,2;
	

drop view if exists v_prova_bib_detalhes;

create view v_prova_bib_detalhes as
select
	p.id as provaId,
    a.ra as alunoRa,
	q.id  as questaoId,
	alt.id as alternativaId,
	arqq.legado_id as questaoArquivoId,
	arqq.tamanho_bytes as questaoArquivoTamanho,
	arqa.legado_id as alternativaArquivoId,
	arqa.tamanho_bytes as alternativaArquivoTamanho
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
left join arquivo arqq on
	qa.arquivo_id = arqq.id
left join alternativa_arquivo aa on
	aa.alternativa_id = alt.id
left join arquivo arqa on
	aa.arquivo_id = arqa.id;