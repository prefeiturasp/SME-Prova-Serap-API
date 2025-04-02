CREATE TABLE IF NOT EXISTS lote_prova (
    id BIGSERIAL PRIMARY KEY,
    nome VARCHAR NOT NULL,
    tipo_tai BOOLEAN,
    exibir_no_boletim BOOLEAN,
    data_correcao_fim TIMESTAMP,
    data_inicio_lote TIMESTAMP,
    data_criacao TIMESTAMP NOT NULL,
    data_alteracao TIMESTAMP
);

ALTER TABLE boletim_lote_prova 
    DROP CONSTRAINT IF EXISTS fk_boletim_lote;

ALTER TABLE boletim_lote_prova 
    ADD CONSTRAINT fk_boletim_lote 
    FOREIGN KEY (lote_id) REFERENCES lote_prova(id);

ALTER TABLE boletim_lote_prova DROP COLUMN IF EXISTS exibir_no_boletim;