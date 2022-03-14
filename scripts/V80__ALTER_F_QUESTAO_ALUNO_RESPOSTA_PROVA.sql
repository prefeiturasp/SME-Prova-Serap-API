CREATE OR REPLACE FUNCTION public.f_questao_aluno_resposta_prova(prova_serap_id bigint)
 RETURNS TABLE(id bigint, questao_id bigint, aluno_ra bigint, alternativa_id bigint, resposta character varying, criado_em timestamp with time zone, tempo_resposta_aluno int4, visualizacoes int4)
 LANGUAGE plpgsql
AS $function$
begin
	
	return query 
		WITH RECURSIVE respostas AS(
    select distinct max(qar.id) AS id,
    qar.questao_id,
    qar.aluno_ra
   FROM prova p
   inner join questao q on p.id = q.prova_id
   inner join questao_aluno_resposta qar on qar.questao_id = q.id
   where p.prova_legado_id = prova_serap_id   
  GROUP BY qar.questao_id, qar.aluno_ra
) 
SELECT qar.id, qar.questao_id, qar.aluno_ra, qar.alternativa_id, qar.resposta, qar.criado_em, qar.tempo_resposta_aluno, qar.visualizacoes 
FROM questao_aluno_resposta qar
inner join respostas r on qar.id = r.id;

end
$function$
;
