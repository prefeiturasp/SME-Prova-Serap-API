CREATE table if not exists public.usuario_serap_coresso (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	id_coresso uuid not null,
	login varchar(200) NULL,	
	nome varchar(200) NULL,		
	criado_em timestamp NOT NULL DEFAULT now(),
	atualizado_em timestamp NOT NULL DEFAULT now(),
	CONSTRAINT usuario_serap_coresso_pk PRIMARY KEY (id)
);
CREATE index if not exists id_coresso_idx ON public.usuario_serap_coresso (id_coresso);