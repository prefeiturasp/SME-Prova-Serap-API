drop function if exists f_questao_aluno_resposta_prova_turma;
CREATE OR REPLACE FUNCTION public.f_questao_aluno_resposta_prova_turma(prova_serap_id bigint, turma_codigo_eol character varying)
 RETURNS TABLE(id bigint, questao_id bigint, aluno_ra bigint, alternativa_id bigint, resposta character varying, criado_em timestamp with time zone, tempo_resposta_aluno integer, visualizacoes integer)
 LANGUAGE plpgsql
AS $function$
begin
	
	return query 
	WITH RECURSIVE respostas AS(
    	select 
			max(qar.id) id,
    		qar.questao_id,
    		qar.aluno_ra
   		from f_alunos_turma(turma_codigo_eol) fat
   			inner join turma t on t.codigo = turma_codigo_eol 
   		    inner join prova p on p.prova_legado_id = prova_serap_id and t.ano_letivo::double precision = date_part('year'::text, p.inicio)
   			inner join questao q on p.id = q.prova_id   			
   			inner join prova_aluno palu on palu.aluno_ra = fat.aluno_ra and p.id = palu.prova_id
   				and palu.status in(2,5) and palu.finalizado_em is not null   			
   			inner join questao_aluno_resposta qar on qar.questao_id = q.id 
   			and qar.aluno_ra = fat.aluno_ra
   		where t.codigo = turma_codigo_eol
   		group by qar.questao_id,
    		qar.aluno_ra
) 
select distinct
qar.id, qar.questao_id, qar.aluno_ra, qar.alternativa_id, qar.resposta, qar.criado_em, qar.tempo_resposta_aluno, qar.visualizacoes 
FROM questao_aluno_resposta qar
inner join respostas r on qar.id = r.id;

end
$function$
;