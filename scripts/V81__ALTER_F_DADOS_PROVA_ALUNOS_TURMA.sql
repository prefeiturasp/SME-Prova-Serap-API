CREATE OR REPLACE FUNCTION public.f_dados_prova_alunos_turma(prova_serap_id bigint, dre_codigo_eol character varying, ue_codigo_eol character varying, turma_codigo_eol character varying)
 RETURNS TABLE(provaserapid bigint, provaserapestudantesid bigint, drecodigoeol character varying, dresigla character varying, drenome character varying, uecodigoeol character varying, uenome text, turmaanoescolar character varying, turmaanoescolardescricao character varying, turmacodigo character varying, turmadescricao character varying, alunocodigoeol bigint, alunonome character varying, alunosexo character varying, alunodatanascimento timestamp with time zone, provacomponente character varying, provacaderno character varying, provaquantidadequestoes integer, provadatainicio timestamp without time zone, provadataentregue timestamp without time zone, alunofrequencia text)
 LANGUAGE plpgsql
AS $function$
begin
	return query
SELECT p.prova_legado_id AS prova_serap_id,
    p.id AS prova_serap_estudantes_id,
    dre.dre_id AS dre_codigo_eol,
    dre.abreviacao AS dre_sigla,
    dre.nome AS dre_nome,
    ue.ue_id AS ue_codigo_eol,
    (
        CASE
            WHEN ue.tipo_escola = 1 THEN 'EMEF'::text
            WHEN ue.tipo_escola = 2 THEN 'EMEI'::text
            WHEN ue.tipo_escola = 3 THEN 'EMEFM'::text
            WHEN ue.tipo_escola = 4 THEN 'EMEBS'::text
            WHEN ue.tipo_escola = 10 THEN 'CEI DIRET'::text
            WHEN ue.tipo_escola = 11 THEN 'CEI INDIR'::text
            WHEN ue.tipo_escola = 12 THEN 'CR.P.CONV'::text
            WHEN ue.tipo_escola = 13 THEN 'CIEJA'::text
            WHEN ue.tipo_escola = 14 THEN 'CCI/CIPS'::text
            WHEN ue.tipo_escola = 15 THEN 'ESC.PART.'::text
            WHEN ue.tipo_escola = 16 THEN 'CEU EMEF'::text
            WHEN ue.tipo_escola = 17 THEN 'CEU EMEI'::text
            WHEN ue.tipo_escola = 18 THEN 'CEU CEI'::text
            WHEN ue.tipo_escola = 19 THEN 'CEU'::text
            WHEN ue.tipo_escola = 22 THEN 'MOVA'::text
            WHEN ue.tipo_escola = 23 THEN 'CMCT'::text
            WHEN ue.tipo_escola = 25 THEN 'E TEC'::text
            WHEN ue.tipo_escola = 26 THEN 'ESP CONV'::text
            WHEN ue.tipo_escola = 27 THEN 'CEU AT COMPL'::text
            WHEN ue.tipo_escola = 29 THEN 'CCA'::text
            WHEN ue.tipo_escola = 28 THEN 'CEMEI'::text
            WHEN ue.tipo_escola = 30 THEN 'CECI'::text
            WHEN ue.tipo_escola = 31 THEN 'CEU CEMEI'::text
            ELSE NULL::text
        END || ' '::text) || ue.nome::text AS ue_nome,
    t.ano AS turma_ano_escolar,
        CASE
            WHEN t.ano::text <> 'S'::text THEN (t.ano::text || 'ano'::text)::character varying
            ELSE t.ano
        END AS turma_ano_escolar_descricao,
    t.codigo AS turma_codigo,
    t.nome AS turma_descricao,
    a.ra AS aluno_codigo_eol,
        CASE
            WHEN a.nome_social IS NOT NULL THEN a.nome_social
            ELSE a.nome
        END AS aluno_nome,
    a.sexo AS aluno_sexo,
    a.data_nascimento AS aluno_data_nascimento,
        CASE
            WHEN p.disciplina IS NULL OR p.multidisciplinar THEN 'Multidisciplinar'::character varying
            ELSE p.disciplina
        END AS prova_componente,
        CASE
            WHEN p.possui_bib THEN ca.caderno
            ELSE ''::character varying
        END AS prova_caderno,
    p.total_itens AS prova_quantidade_questoes,
    palu.criado_em AS prova_data_inicio,
    palu.finalizado_em AS prova_data_entregue,
        CASE
            WHEN palu.frequencia = 0 THEN 'N'::text
            WHEN palu.frequencia = 1 THEN 'P'::text
            WHEN palu.frequencia = 2 THEN 'A'::text
            WHEN palu.frequencia = 3 THEN 'R'::text
            ELSE 'N'::text
        END AS aluno_frequencia
   FROM aluno a
     JOIN v_turmas_alunos vta ON a.id = vta.aluno_id
     JOIN turma t ON t.modalidade_codigo = vta.modalidade_codigo AND t.ano::text = vta.ano::text AND t.ano_letivo = vta.ano_letivo AND t.id = vta.turma_id
     JOIN ue ON t.ue_id = ue.id
     JOIN dre ON ue.dre_id = dre.id
     JOIN prova_ano pa ON t.ano::text = pa.ano::text
     JOIN prova p ON pa.prova_id = p.id 
     and (case when t.modalidade_codigo::text in('3','4') then '3'::text else t.modalidade_codigo::text end) = p.modalidade::text 
     AND t.ano_letivo::double precision = date_part('year'::text, p.inicio)
     LEFT JOIN prova_aluno palu ON p.id = palu.prova_id AND a.ra = palu.aluno_ra AND (palu.status = ANY (ARRAY[2, 5])) AND palu.finalizado_em IS NOT NULL
     LEFT JOIN f_caderno_aluno_prova(prova_serap_id) ca ON p.id = ca.prova_id AND a.id = ca.aluno_id
     where p.prova_legado_id = prova_serap_id
		and dre.dre_id = dre_codigo_eol
		and ue.ue_id = ue_codigo_eol
		and t.codigo = turma_codigo_eol;
end
$function$
;
