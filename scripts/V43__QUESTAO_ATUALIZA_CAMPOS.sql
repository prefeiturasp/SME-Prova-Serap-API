ALTER TABLE questao RENAME COLUMN titulo TO texto_base;
ALTER TABLE questao RENAME COLUMN descricao TO enunciado;

ALTER TABLE questao ALTER COLUMN texto_base DROP NOT NULL;