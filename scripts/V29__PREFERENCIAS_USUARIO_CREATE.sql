create table if not exists public.preferencias_usuario
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
    tamanho_fonte int not null,
	familia_fonte int not null,
	usuario_id int8 not null,
	CONSTRAINT preferencias_usuario_pk PRIMARY KEY (id),
	CONSTRAINT preferencias_usuario_usuario_fk FOREIGN KEY (usuario_id) REFERENCES public.usuario (id)
);

create index if not exists preferencias_usuario_id_idx ON public.preferencias_usuario (id);
create index if not exists preferencias_usuario_usuario_idx ON public.preferencias_usuario (usuario_id);
