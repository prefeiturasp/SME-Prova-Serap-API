ALTER TABLE public.prova
ADD COLUMN IF NOT EXISTS data_correcao_inicio TIMESTAMP,
ADD COLUMN IF NOT EXISTS data_correcao_fim TIMESTAMP;