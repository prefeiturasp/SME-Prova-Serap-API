CREATE TABLE IF NOT EXISTS boletim_lote_ue (
    id BIGSERIAL PRIMARY KEY,
    dre_id int8 NOT NULL,
		ue_id int8 NOT NULL,
		lote_id int8 NOT NULL,
    ano_escolar int4 NULL,
		total_alunos int4 NOT NULL,
		realizaram_prova int4 NOT NULL,
    CONSTRAINT fk_lote
        FOREIGN KEY (lote_id)
        REFERENCES lote_prova(id)
        ON DELETE CASCADE
);