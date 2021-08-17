create table if not exists public.prova_componente_curricular
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	prova_id bigint not null ,
	componente_curricular_id bigint null ,
	CONSTRAINT prova_componente_curricular_pk PRIMARY KEY (id),
	CONSTRAINT prova_fk FOREIGN KEY (prova_id) REFERENCES public.prova (id)
);
create index if not exists prova_componente_curricular_id_idx ON public.prova_componente_curricular (id);
create index if not exists prova_componente_curricular_prova_id_idx ON public.prova_componente_curricular (prova_id);
create index if not exists prova_componente_curricular_componente_curricular_id_idx ON public.prova_componente_curricular (componente_curricular_id);
