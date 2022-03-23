CREATE table if not exists public.abrangencia (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NOT NULL,
	grupo_id int8 NOT NULL,
	dre_id int8 NULL,
	ue_id int8 NULL,
	turma_id int8 NULL,
	CONSTRAINT abrangencia_pk PRIMARY KEY (id)
);

CREATE index if not exists abrangencia_dre_id_idx ON public.abrangencia (dre_id);
CREATE index if not exists abrangencia_turma_idx ON public.abrangencia (turma_id);
CREATE index if not exists abrangencia_ue_idx ON public.abrangencia (ue_id);
CREATE index if not exists abrangencia_usuario_idx ON public.abrangencia (usuario_id);
CREATE index if not exists abrangencia_grupo_idx ON public.abrangencia (grupo_id);

ALTER TABLE public.abrangencia DROP CONSTRAINT IF EXISTS abrangencia_usario_fk;
ALTER TABLE public.abrangencia ADD CONSTRAINT abrangencia_usario_fk FOREIGN KEY (usuario_id) REFERENCES public.usuario_serap_coresso(id);