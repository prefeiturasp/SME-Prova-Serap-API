ALTER TABLE caderno_aluno DROP column if exists caderno_tai;
ALTER TABLE questao DROP column if exists caderno_tai;

drop view v_alunos_status_iniciada;
drop view v_alunos_status_finalizado;
drop view v_prova_bib_detalhes;

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
            WHEN t.tipo_turno = 1 THEN 'Manhã'::text
            WHEN t.tipo_turno = 2 THEN 'Intermediário'::text
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
            ELSE 'Não Iniciada'::text
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
            WHEN t.tipo_turno = 1 THEN 'Manhã'::text
            WHEN t.tipo_turno = 2 THEN 'Intermediário'::text
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
            ELSE 'Não Iniciada'::text
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