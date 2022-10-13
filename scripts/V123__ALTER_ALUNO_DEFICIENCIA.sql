CREATE index if not exists aluno_deficiencia_aluno_ra_idx ON public.aluno_deficiencia (aluno_ra);
ALTER TABLE public.tipo_deficiencia add constraint tipo_deficiencia_pk PRIMARY KEY (id);