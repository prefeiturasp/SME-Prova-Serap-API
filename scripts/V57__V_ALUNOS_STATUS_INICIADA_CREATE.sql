drop view if exists public.v_alunos_status_iniciada;

CREATE VIEW public.v_alunos_status_iniciada
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