create or replace function f_questao_aluno_resposta_prova (
  prova_serap_id int8
) 
	returns table (
		id int8,
		questao_id int8,
		aluno_ra int8,
		alternativa_id int8,
		resposta varchar
	) 
	language plpgsql
as $function$
begin
	
	return query 
		select distinct max(qar.id) AS id,
    qar.questao_id,
    qar.aluno_ra,
    qar.alternativa_id,
    qar.resposta
   FROM prova p
   inner join questao q on p.id = q.prova_id
   inner join questao_aluno_resposta qar on qar.questao_id = q.id
   where p.prova_legado_id = prova_serap_id
  GROUP BY qar.questao_id, qar.aluno_ra,qar.alternativa_id,qar.resposta;

end
$function$
;