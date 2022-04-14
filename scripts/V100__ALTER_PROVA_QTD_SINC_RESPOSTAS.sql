ALTER TABLE prova
ADD COLUMN IF NOT EXISTS qtd_itens_sincronizacao_respostas int4;

update prova set qtd_itens_sincronizacao_respostas = 2;