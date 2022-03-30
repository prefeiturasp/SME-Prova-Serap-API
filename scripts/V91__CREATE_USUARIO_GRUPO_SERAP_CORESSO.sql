CREATE table if not exists public.usuario_grupo_serap_coresso (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	id_usuario_serap int8 NOT NULL,
	id_grupo_serap int8 NOT NULL,	
	criado_em timestamp NOT NULL DEFAULT now(),
	CONSTRAINT usuario_grupo_serap_coresso_pk PRIMARY KEY (id)
);
CREATE index if not exists id_usuario_serap_idx ON public.usuario_grupo_serap_coresso (id_usuario_serap);
CREATE index if not exists id_grupo_serap_idx ON public.usuario_grupo_serap_coresso (id_grupo_serap);

ALTER TABLE public.usuario_grupo_serap_coresso DROP CONSTRAINT IF EXISTS usuario_serap_coresso_id_fk;
ALTER TABLE public.usuario_grupo_serap_coresso ADD constraint usuario_serap_coresso_id_fk FOREIGN KEY (id_usuario_serap) REFERENCES public.usuario_serap_coresso(id) ON DELETE CASCADE;

ALTER TABLE public.usuario_grupo_serap_coresso DROP CONSTRAINT IF EXISTS grupo_serap_coresso_id_fk;
ALTER TABLE public.usuario_grupo_serap_coresso ADD constraint grupo_serap_coresso_id_fk FOREIGN KEY (id_grupo_serap) REFERENCES public.grupo_serap_coresso(id) ON DELETE CASCADE;