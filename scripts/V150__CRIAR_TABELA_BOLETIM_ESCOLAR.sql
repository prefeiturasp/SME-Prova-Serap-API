CREATE TABLE IF NOT EXISTS public.boletim_escolar (
 id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
 ue_id int8 NOT NULL,
 prova_id int8 NOT NULL,
 componente_curricular varchar(60) NULL,
 abaixo_basico numeric NOT NULL,
 abaixo_basico_porcentagem numeric NOT NULL,
 basico numeric NOT NULL,
 basico_porcentagem numeric NOT NULL,
 adequado numeric NOT NULL,
 adequado_porcentagem numeric NOT NULL,
 avancado numeric NOT NULL,
 avancado_porcentagem numeric NOT NULL,
 total numeric NOT NULL,
 media_proficiencia numeric NOT NULL,
 disciplina_id int8 NULL,
 CONSTRAINT boletim_escolar_pk PRIMARY KEY (id)
);

CREATE INDEX IF NOT EXISTS idx_boletim_escolar_prova ON public.boletim_escolar USING btree (prova_id);
CREATE INDEX IF NOT EXISTS idx_boletim_escolar_ue ON public.boletim_escolar USING btree (ue_id);

ALTER TABLE IF EXISTS public.boletim_escolar ADD CONSTRAINT boletim_escolar_prova_fk FOREIGN KEY (prova_id) REFERENCES public.prova(id);
ALTER TABLE IF EXISTS public.boletim_escolar ADD CONSTRAINT boletim_escolar_ue_fk FOREIGN KEY (ue_id) REFERENCES public.ue(id);