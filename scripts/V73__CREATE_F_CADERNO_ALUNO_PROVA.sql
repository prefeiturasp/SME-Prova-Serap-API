create or replace function f_caderno_aluno_prova (
  prova_serap_id int8
) 
	returns table (
		id int8,
		aluno_id int8,
		caderno varchar,
		prova_id int8
	) 
	language plpgsql
AS $function$
begin
	
	return query 
		select max(ca.id) id, ca.aluno_id,ca.caderno, ca.prova_id 
		from caderno_aluno ca
inner join prova p
on ca.prova_id = p.id
where p.prova_legado_id = prova_serap_id
group by ca.aluno_id,ca.caderno,ca.prova_id;

end
$function$
;