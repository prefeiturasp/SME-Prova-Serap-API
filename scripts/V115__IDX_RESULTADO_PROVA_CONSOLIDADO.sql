
CREATE index if not exists idx_prova_serap_id ON resultado_prova_consolidado(prova_serap_id);
CREATE index if not exists idx_prova_serap_estudantes_id ON resultado_prova_consolidado(prova_serap_estudantes_id);
CREATE index if not exists idx_turma_codigo ON resultado_prova_consolidado(turma_codigo);
CREATE index if not exists idx_aluno_codigo_eol ON resultado_prova_consolidado(aluno_codigo_eol);
CREATE index if not exists idx_questao_id ON resultado_prova_consolidado(questao_id);