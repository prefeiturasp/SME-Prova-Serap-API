-- Adicionar novos campos na tabela "boletim_escolar"
ALTER TABLE public.boletim_escolar
ADD COLUMN nivel_ue_codigo INTEGER;

ALTER TABLE public.boletim_escolar
ADD COLUMN nivel_ue_descricao TEXT;