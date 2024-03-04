CREATE OR REPLACE PROCEDURE public.p_excluir_dados_consolidados_prova(IN p_prova_serap_id bigint)
 LANGUAGE sql
AS $procedure$

delete from resultado_prova_consolidado 
                                where prova_serap_id = p_prova_serap_id;

$procedure$
;
