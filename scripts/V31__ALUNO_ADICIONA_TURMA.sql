ALTER TABLE  if exists public.aluno ADD COLUMN IF NOT EXISTS turma_id int8 not NULL default 0;
ALTER TABLE  if exists public.aluno ADD COLUMN IF NOT EXISTS situacao int not NULL default 0;

create index if not exists aluno_turma_idx ON public.aluno (turma_id);

ALTER TABLE public.aluno ADD CONSTRAINT aluno_turma_id_fk FOREIGN KEY (turma_id) REFERENCES turma(id) ON DELETE CASCADE;