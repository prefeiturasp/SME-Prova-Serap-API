CREATE TABLE IF NOT EXISTS public.nivel_proficiencia (
 id serial4 NOT NULL,
 codigo int4 NOT NULL,
 descricao text NOT NULL,
 valor_referencia int8 NULL,
 disciplina_id int8 NULL,
 ano int8 NULL,
 CONSTRAINT nivel_proficiencia_pkey PRIMARY KEY (id),
 CONSTRAINT nivel_proficiencia_unique UNIQUE (codigo, disciplina_id, ano)
);