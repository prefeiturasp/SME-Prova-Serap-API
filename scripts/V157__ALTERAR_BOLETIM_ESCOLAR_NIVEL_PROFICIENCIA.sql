-- Adicionar novos campos na tabela "boletim_escolar"
ALTER TABLE IF EXISTS public.boletim_escolar
ADD COLUMN IF NOT EXISTS nivel_ue_codigo INTEGER;

ALTER TABLE IF EXISTS public.boletim_escolar
ADD COLUMN IF NOT EXISTS  nivel_ue_descricao TEXT;