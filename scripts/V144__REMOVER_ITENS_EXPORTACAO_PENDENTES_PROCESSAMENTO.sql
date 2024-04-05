UPDATE exportacao_resultado 
SET status = 5
FROM (select distinct eri.exportacao_resultado_id  from exportacao_resultado_item eri) AS item
WHERE exportacao_resultado.id = item.exportacao_resultado_id;

delete from exportacao_resultado_item;