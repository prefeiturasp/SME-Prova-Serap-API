drop function if exists f_alunos_turma;
CREATE OR REPLACE FUNCTION public.f_alunos_turma(turma_codigo_eol character varying)
 RETURNS TABLE(id bigint, aluno_ra bigint)
 LANGUAGE plpgsql
AS $function$
begin

return query
select a.id, a.ra 
from turma t
inner join v_turmas_alunos vta on vta.turma_id = t.id
inner join aluno a on a.id = vta.aluno_id
where t.codigo = turma_codigo_eol;
	
end
$function$
;