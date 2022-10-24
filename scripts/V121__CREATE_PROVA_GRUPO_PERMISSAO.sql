CREATE TABLE  if not exists  public.prova_grupo_permissao (
    id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
    prova_id int8 NOT NULL,
    prova_legado_id int8 NOT NULL,
    grupo_id int8 NOT NULL,
    ocultar_prova bool NOT NULL DEFAULT false,
    criado_em timestamp NULL,
    alterado_em timestamp NULL,
    CONSTRAINT prova_grupo_permissao_pk PRIMARY KEY (id)
);
CREATE INDEX  if not exists prova_id_idx ON public.prova_grupo_permissao USING btree (prova_id);