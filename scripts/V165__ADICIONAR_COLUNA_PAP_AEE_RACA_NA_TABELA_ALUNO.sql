ALTER TABLE public.aluno
    ADD COLUMN IF NOT EXISTS pap  boolean      DEFAULT false NOT NULL,
    ADD COLUMN IF NOT EXISTS aee  boolean      DEFAULT false NOT NULL,
    ADD COLUMN IF NOT EXISTS raca varchar(100) NULL;