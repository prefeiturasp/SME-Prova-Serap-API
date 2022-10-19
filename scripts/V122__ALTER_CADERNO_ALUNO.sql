

ALTER TABLE caderno_aluno DROP column if exists caderno_tai;
ALTER TABLE questao DROP column if exists caderno_tai;

drop view v_alunos_status_iniciada;
drop view v_alunos_status_finalizado;
drop view v_prova_bib_detalhes;
drop view v_prova_aluno_dados_extracao; 

ALTER TABLE caderno_aluno ALTER COLUMN caderno TYPE varchar(10) USING caderno::varchar;
ALTER TABLE questao ALTER COLUMN caderno TYPE varchar(10) USING caderno::varchar;

CREATE OR REPLACE VIEW v_alunos_status_iniciada
AS SELECT dre.id AS dreid,
    ue.id AS ueid,
    a.ra AS alunora,
    a.nome,
    t.ano,
    t.tipo_turno AS tipoturno,
        CASE
            WHEN t.tipo_turno = 1 THEN 'Manh�'::text
            WHEN t.tipo_turno = 2 THEN 'Intermedi�rio'::text
            WHEN t.tipo_turno = 3 THEN 'Tarde'::text
            WHEN t.tipo_turno = 4 THEN 'Vespertino'::text
            WHEN t.tipo_turno = 5 THEN 'Noite'::text
            WHEN t.tipo_turno = 6 THEN 'Integral'::text
            ELSE NULL::text
        END AS turno,
    p.id AS provaid,
    p.prova_legado_id AS provaserapid,
    p.descricao,
        CASE
            WHEN pa.status = 1 THEN 'Iniciada'::text
            WHEN pa.status = 2 THEN 'Finalizada'::text
            ELSE 'N�o Iniciada'::text
        END AS status,
    ca.caderno,
    pa.criado_em,
    pa.finalizado_em,
    count(q.*) AS quantidadequestoes,
    count(qar.*) AS respostasregistradas
   FROM aluno a
     JOIN turma t ON a.turma_id = t.id
     JOIN ue ON t.ue_id = ue.id
     JOIN dre ON ue.dre_id = dre.id
     JOIN caderno_aluno ca ON a.id = ca.aluno_id
     JOIN prova p ON ca.prova_id = p.id
     JOIN questao q ON ca.prova_id = q.prova_id AND ca.caderno::text = q.caderno::text
     LEFT JOIN questao_aluno_resposta qar ON q.id = qar.questao_id AND a.ra = qar.aluno_ra AND qar.alternativa_id IS NOT NULL
     JOIN prova_aluno pa ON p.id = pa.prova_id AND a.ra = pa.aluno_ra
  WHERE pa.status = 1
  GROUP BY dre.id, ue.id, a.ra, t.ano, t.tipo_turno, a.nome, p.id, p.prova_legado_id, pa.status, p.descricao, ca.caderno, pa.criado_em, pa.finalizado_em
  ORDER BY pa.finalizado_em DESC;
  
CREATE OR REPLACE VIEW v_alunos_status_finalizado
AS SELECT dre.id AS dreid,
    ue.id AS ueid,
    a.ra AS alunora,
    a.nome,
    t.ano,
    t.tipo_turno AS tipoturno,
        CASE
            WHEN t.tipo_turno = 1 THEN 'Manh�'::text
            WHEN t.tipo_turno = 2 THEN 'Intermedi�rio'::text
            WHEN t.tipo_turno = 3 THEN 'Tarde'::text
            WHEN t.tipo_turno = 4 THEN 'Vespertino'::text
            WHEN t.tipo_turno = 5 THEN 'Noite'::text
            WHEN t.tipo_turno = 6 THEN 'Integral'::text
            ELSE NULL::text
        END AS turno,
    p.id AS provaid,
    p.prova_legado_id AS provaserapid,
    p.descricao,
        CASE
            WHEN pa.status = 1 THEN 'Iniciada'::text
            WHEN pa.status = 2 THEN 'Finalizada'::text
            ELSE 'N�o Iniciada'::text
        END AS status,
    ca.caderno,
    pa.criado_em,
    pa.finalizado_em,
    count(q.*) AS quantidadequestoes,
    count(qar.*) AS respostasregistradas
   FROM aluno a
     JOIN turma t ON a.turma_id = t.id
     JOIN ue ON t.ue_id = ue.id
     JOIN dre ON ue.dre_id = dre.id
     JOIN caderno_aluno ca ON a.id = ca.aluno_id
     JOIN prova p ON ca.prova_id = p.id
     JOIN questao q ON ca.prova_id = q.prova_id AND ca.caderno::text = q.caderno::text
     LEFT JOIN questao_aluno_resposta qar ON q.id = qar.questao_id AND a.ra = qar.aluno_ra AND qar.alternativa_id IS NOT NULL
     JOIN prova_aluno pa ON p.id = pa.prova_id AND a.ra = pa.aluno_ra
  WHERE pa.status = 2
  GROUP BY dre.id, ue.id, a.ra, t.ano, t.tipo_turno, a.nome, p.id, p.prova_legado_id, pa.status, p.descricao, ca.caderno, pa.criado_em, pa.finalizado_em
  ORDER BY pa.finalizado_em DESC;
  
CREATE OR REPLACE VIEW v_prova_detalhes
AS SELECT p.id AS provaid,
    q.id AS questaoid,
    alt.id AS alternativaid,
    arqq.legado_id AS questaoarquivoid,
    arqq.tamanho_bytes AS questaoarquivotamanho,
    arqa.legado_id AS alternativaarquivoid,
    arqa.tamanho_bytes AS alternativaarquivotamanho
   FROM prova p
     JOIN questao q ON q.prova_id = p.id
     LEFT JOIN alternativa alt ON alt.questao_id = q.id
     LEFT JOIN questao_arquivo qa ON qa.questao_id = q.id
     LEFT JOIN arquivo arqq ON qa.arquivo_id = arqq.id
     LEFT JOIN alternativa_arquivo aa ON aa.alternativa_id = alt.id
     LEFT JOIN arquivo arqa ON aa.arquivo_id = arqa.id
  ORDER BY p.id, q.id;
  
 -- public.v_prova_aluno_dados_extracao source

CREATE OR REPLACE VIEW public.v_prova_aluno_dados_extracao
AS SELECT p.prova_legado_id AS prova_serap_id,
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
            WHEN t.ano::text <> 'S'::text THEN (t.ano::text || '� ano'::text)::character varying
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
     JOIN turma t ON a.turma_id = t.id
     JOIN ue ON t.ue_id = ue.id
     JOIN dre ON ue.dre_id = dre.id
     JOIN prova_aluno palu ON a.ra = palu.aluno_ra AND (palu.status = ANY (ARRAY[2, 5])) AND palu.finalizado_em IS NOT NULL
     JOIN prova p ON p.id = palu.prova_id
     LEFT JOIN caderno_aluno ca ON p.id = ca.prova_id AND a.id = ca.aluno_id;