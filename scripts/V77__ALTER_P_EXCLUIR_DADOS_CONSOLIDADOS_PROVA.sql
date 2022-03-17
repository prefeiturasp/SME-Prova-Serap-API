CREATE OR REPLACE PROCEDURE public.p_excluir_dados_consolidados_prova(p_prova_serap_id bigint, p_dre_codigo_eol character varying, p_ue_codigo_eol character varying)
 LANGUAGE sql
AS $procedure$

delete from resultado_prova_consolidado 
                                where prova_serap_id = p_prova_serap_id
                                and dre_codigo_eol = p_dre_codigo_eol
                                and ue_codigo_eol = p_ue_codigo_eol;

$procedure$
;
