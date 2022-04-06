CREATE table if not exists public.grupo_serap_coresso (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	id_coresso uuid not null,	
	nome varchar(200) NULL,		
	criado_em timestamp NOT NULL DEFAULT now(),
	CONSTRAINT grupo_serap_coresso_pk PRIMARY KEY (id)
);
CREATE index if not exists id_coresso_idx ON public.grupo_serap_coresso (id_coresso);