CREATE OR REPLACE PROCEDURE public.p_consolidar_dados_prova_adesao_manual(IN p_prova_serap_id bigint)
 LANGUAGE sql
AS $procedure$
 with TempHistAlunos as (

SELECT tah.turma_id , tah.ano_letivo , tah.aluno_id  
FROM  prova_adesao   pa 
inner join prova p on pa.prova_id  = p.id 
inner join aluno a  on a.ra = pa.aluno_ra  
inner join turma_aluno_historico tah on tah.ano_letivo  = extract(YEAR FROM p.inicio) 
and a.id  = tah.aluno_id  
JOIN turma t ON t.id = tah.turma_id  AND t.ue_id = pa.ue_id    
    JOIN prova_ano pra on pra.prova_id = p.id
     and (     		   (p.modalidade not in (3,4) and p.modalidade = t.modalidade_codigo and t.ano = pra.ano)
     		or (t.ano = pra.ano and t.modalidade_codigo = pra.modalidade and t.etapa_eja = pra.etapa_eja)
     	 )
     and (case when t.modalidade_codigo::text in('3','4') then '3'::text else t.modalidade_codigo::text end) = p.modalidade::text

where pa.prova_id = p_prova_serap_id )



insert into resultado_prova_consolidado 
(prova_serap_id,prova_serap_estudantes_id,dre_codigo_eol,dre_sigla,dre_nome,
ue_codigo_eol,ue_nome,turma_ano_escolar,turma_ano_escolar_descricao,
turma_codigo,turma_descricao,aluno_codigo_eol,aluno_nome,aluno_sexo,
aluno_data_nascimento,prova_componente,prova_caderno,prova_quantidade_questoes,
aluno_frequencia,questao_id,questao_ordem,resposta,prova_data_inicio,prova_data_entregue) 
 select 	 
   	  p.prova_legado_id AS prova_serap_id,
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
            WHEN ue.tipo_escola = 32 THEN 'EMEF'::text
            WHEN ue.tipo_escola = 33 THEN 'EMEI'::text
            
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
     ca.caderno  AS prova_caderno,
    p.total_itens AS prova_quantidade_questoes,

        CASE
            WHEN palu.frequencia = 0 THEN 'N'::text
            WHEN palu.frequencia = 1 THEN 'P'::text
            WHEN palu.frequencia = 2 THEN 'A'::text
            WHEN palu.frequencia = 3 THEN 'R'::text
            ELSE 'N'::text
        END AS aluno_frequencia,
        
       q.id as questao_id,
       q.ordem + 1 as questao_ordem,    
     CASE
	  when qar.alternativa_id is not null then alt.numeracao
    	else qar.resposta
      end as resposta, 
         palu.criado_em AS prova_data_inicio,
    palu.finalizado_em AS prova_data_entregue
  
   	 from prova_adesao pa
   	 JOIN prova p ON p.id = p_prova_serap_id
   	 inner join aluno a on pa.aluno_ra  = a.ra 
   	 JOIN TempHistAlunos tah on   tah.ano_letivo = extract(YEAR FROM p.inicio) 
     and tah.aluno_id  = a.id 
   	 JOIN turma t ON t.id = tah.turma_id  AND t.ue_id = pa.ue_id      	 
     JOIN ue ON t.ue_id = ue.id
     JOIN dre ON ue.dre_id = dre.id
        
     JOIN prova_ano pra on pra.prova_id = p.id
     and (
     		   (p.modalidade not in (3,4) and p.modalidade = t.modalidade_codigo and t.ano = pra.ano)
     		or (t.ano = pra.ano and t.modalidade_codigo = pra.modalidade and t.etapa_eja = pra.etapa_eja)
     	 )
     and (case when t.modalidade_codigo::text in('3','4') then '3'::text else t.modalidade_codigo::text end) = p.modalidade::text
   
     LEFT JOIN prova_aluno palu ON p.id = palu.prova_id AND a.ra = palu.aluno_ra AND (palu.status = ANY (ARRAY[2, 5, 6, 7])) AND palu.finalizado_em IS NOT NULL
     LEFT JOIN  caderno_aluno as ca on   ca.prova_id = p_prova_serap_id  AND a.id = ca.aluno_id 
     inner join questao  as q on  q.prova_id = p.id  and ca.caderno  is null
   left join questao_aluno_resposta qar on qar.questao_id  = q.id and  qar.aluno_ra  = pa.aluno_ra
                        left join alternativa alt on alt.id = qar.alternativa_id
                            left join alternativa alt2 on alt2.questao_id = q.id and alt2.correta 
   WHERE pa.prova_id = p_prova_serap_id 
    
   union  
   
    select 	 
   	  p.prova_legado_id AS prova_serap_id,
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
            WHEN ue.tipo_escola = 32 THEN 'EMEF'::text
            WHEN ue.tipo_escola = 33 THEN 'EMEI'::text
            
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
     ca.caderno  AS prova_caderno,
    p.total_itens AS prova_quantidade_questoes,

        CASE
            WHEN palu.frequencia = 0 THEN 'N'::text
            WHEN palu.frequencia = 1 THEN 'P'::text
            WHEN palu.frequencia = 2 THEN 'A'::text
            WHEN palu.frequencia = 3 THEN 'R'::text
            ELSE 'N'::text
        END AS aluno_frequencia,
        
       q.id as questao_id,
       q.ordem + 1 as questao_ordem,    
     CASE
	  when qar.alternativa_id is not null then alt.numeracao
    	else qar.resposta
      end as resposta, 
         palu.criado_em AS prova_data_inicio,
    palu.finalizado_em AS prova_data_entregue
  
   	 from prova_adesao pa
   	 JOIN prova p ON p.id = 44 
   	 inner join aluno a on pa.aluno_ra  = a.ra 
   	 JOIN TempHistAlunos tah on   tah.ano_letivo = extract(YEAR FROM p.inicio) 
     and tah.aluno_id  = a.id 
   	 JOIN turma t ON t.id = tah.turma_id  AND t.ue_id = pa.ue_id      	 
     JOIN ue ON t.ue_id = ue.id
     JOIN dre ON ue.dre_id = dre.id
        
     JOIN prova_ano pra on pra.prova_id = p.id
     and (
     		   (p.modalidade not in (3,4) and p.modalidade = t.modalidade_codigo and t.ano = pra.ano)
     		or (t.ano = pra.ano and t.modalidade_codigo = pra.modalidade and t.etapa_eja = pra.etapa_eja)
     	 )
     and (case when t.modalidade_codigo::text in('3','4') then '3'::text else t.modalidade_codigo::text end) = p.modalidade::text
   
     LEFT JOIN prova_aluno palu ON p.id = palu.prova_id AND a.ra = palu.aluno_ra AND (palu.status = ANY (ARRAY[2, 5, 6, 7])) AND palu.finalizado_em IS NOT NULL
     LEFT JOIN  caderno_aluno as ca on   ca.prova_id = p_prova_serap_id  AND a.id = ca.aluno_id
     inner join questao  as q on  q.prova_id = p.id   and ca.caderno  = q.caderno 
     and q.caderno  = ca.caderno 
   left join questao_aluno_resposta qar on qar.questao_id  = q.id and  qar.aluno_ra  = pa.aluno_ra
                        left join alternativa alt on alt.id = qar.alternativa_id
                            left join alternativa alt2 on alt2.questao_id = q.id and alt2.correta 
   WHERE pa.prova_id = p_prova_serap_id
   
   $procedure$
;

