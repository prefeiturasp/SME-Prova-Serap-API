CREATE TABLE IF NOT EXISTS boletim_lote_prova (
    id BIGSERIAL PRIMARY KEY,
    lote_id int8 NOT NULL,
    prova_id int8 NOT NULL,
    exibir_no_boletim BOOLEAN NOT NULL,
    CONSTRAINT fk_prova
        FOREIGN KEY (prova_id)
        REFERENCES prova(id)
        ON DELETE CASCADE
);