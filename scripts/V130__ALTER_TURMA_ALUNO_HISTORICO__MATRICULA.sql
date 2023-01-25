ALTER TABLE turma_aluno_historico ADD IF NOT EXISTS matricula INT8;

TRUNCATE TABLE turma_aluno_historico RESTART IDENTITY;