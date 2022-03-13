CREATE index if not exists tah_id_idx ON turma_aluno_historico (id);
CREATE index if not exists tah_turma_id_idx ON turma_aluno_historico (turma_id);
CREATE index if not exists tah_ano_letivo_idx ON turma_aluno_historico (ano_letivo);
CREATE index if not exists tah_aluno_id_idx ON turma_aluno_historico (aluno_id);