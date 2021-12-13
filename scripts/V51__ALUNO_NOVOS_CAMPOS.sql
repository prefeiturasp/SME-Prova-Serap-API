ALTER TABLE  if exists public.aluno ADD COLUMN IF NOT EXISTS nome_social varchar(200) null;
ALTER TABLE  if exists public.aluno ADD COLUMN IF NOT EXISTS data_nascimento timestamptz null;
ALTER TABLE  if exists public.aluno ADD COLUMN IF NOT EXISTS sexo varchar(2) null;