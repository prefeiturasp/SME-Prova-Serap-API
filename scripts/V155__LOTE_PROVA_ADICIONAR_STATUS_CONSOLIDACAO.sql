ALTER TABLE IF EXISTS lote_prova ADD COLUMN IF NOT EXISTS status_consolidacao SMALLINT DEFAULT 0;
UPDATE lote_prova SET status_consolidacao = 2;