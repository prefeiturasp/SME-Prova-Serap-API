CREATE TABLE public.usuario_dispositivo (
	id bigint NOT null generated always as identity,
	ra bigint NOT NULL,
	dispositivo_id varchar NOT NULL,
	criado_em varchar NOT null,
	ano int4 NOT NULL,
	CONSTRAINT usuario_dispositivo_pk PRIMARY KEY (id)
);

CREATE INDEX usuario_dispositivo_ra_idx ON public.usuario_dispositivo (ra);
CREATE INDEX usuario_dispositivo_ano_idx ON public.usuario_dispositivo  (ano);

