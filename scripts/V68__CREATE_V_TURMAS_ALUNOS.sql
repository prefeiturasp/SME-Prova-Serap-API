CREATE OR REPLACE VIEW public.v_turmas_alunos
AS SELECT DISTINCT t.id AS turma_id,
    a.id AS aluno_id,
    t.ano,
    t.ano_letivo,
    t.modalidade_codigo
   FROM aluno a
     JOIN turma t ON a.turma_id = t.id
UNION
 SELECT DISTINCT max(t.id) AS turma_id,
    a.id AS aluno_id,
    t.ano,
    t.ano_letivo,
    t.modalidade_codigo
   FROM aluno a
     JOIN turma_aluno_historico tah ON tah.aluno_id = a.id
     JOIN turma t ON tah.turma_id = t.id AND tah.turma_id <> a.turma_id
  GROUP BY a.id, t.ano, t.ano_letivo, t.modalidade_codigo;