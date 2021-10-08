ALTER TABLE  if exists public.questao_aluno_resposta ADD COLUMN IF NOT EXISTS visualizacoes int NULL;
UPDATE public.questao_aluno_resposta set visualizacoes = 1;