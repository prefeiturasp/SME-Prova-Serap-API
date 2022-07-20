CREATE OR REPLACE VIEW public.v_prova_turma_aluno
AS SELECT p.id AS prova_id,
    p.prova_legado_id,
    p.aderir_todos,
    p.possui_bib,
    p.ocultar_prova,
    p.inicio,
    p.fim,
    p.inicio_download,
    p.ultima_atualizacao,
    t.ue_id,
    t.id AS turma_id,
    t.codigo AS turma_codigo,
    t.ano AS turma_ano,
    t.modalidade_codigo AS turma_modalidade,
    t.etapa_eja AS turma_etapa_eja,
    t.ano_letivo AS turma_ano_letivo,
    a.id AS aluno_id,
    a.ra AS aluno_ra,
    a.situacao AS aluno_situacao,
    p.formato_tai
   FROM prova p
     LEFT JOIN prova_ano_original pa ON pa.prova_id = p.id
     LEFT JOIN turma t ON ((pa.modalidade = 3 OR pa.modalidade = 4) AND pa.etapa_eja = t.etapa_eja OR pa.modalidade <> 3 AND pa.modalidade <> 4) AND t.ano::text = pa.ano::text AND t.modalidade_codigo = pa.modalidade AND t.ano_letivo::double precision = date_part('year'::text, p.inicio)
     JOIN aluno a ON a.turma_id = t.id
  WHERE p.aderir_todos IS NULL OR p.aderir_todos
UNION ALL
 SELECT p.id AS prova_id,
    p.prova_legado_id,
    p.aderir_todos,
    p.possui_bib,
    p.ocultar_prova,
    p.inicio,
    p.fim,
    p.inicio_download,
    p.ultima_atualizacao,
    t.ue_id,
    t.id AS turma_id,
    t.codigo AS turma_codigo,
    t.ano AS turma_ano,
    t.modalidade_codigo AS turma_modalidade,
    t.etapa_eja AS turma_etapa_eja,
    t.ano_letivo AS turma_ano_letivo,
    a.id AS aluno_id,
    a.ra AS aluno_ra,
    a.situacao AS aluno_situacao,
    p.formato_tai
   FROM prova p
     LEFT JOIN prova_adesao pa ON pa.prova_id = p.id
     JOIN aluno a ON a.ra = pa.aluno_ra
     JOIN turma t ON t.id = a.turma_id
  WHERE p.aderir_todos = false;
