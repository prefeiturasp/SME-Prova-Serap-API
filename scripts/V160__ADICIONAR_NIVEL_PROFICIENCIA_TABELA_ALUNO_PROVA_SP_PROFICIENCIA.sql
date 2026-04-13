ALTER TABLE IF EXISTS public.aluno_prova_sp_proficiencia
ADD COLUMN IF NOT EXISTS nivel_proficiencia INTEGER NOT NULL DEFAULT 0;