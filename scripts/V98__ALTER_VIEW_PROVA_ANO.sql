CREATE OR REPLACE VIEW public.prova_ano
AS SELECT prova_ano_original.id,
    prova_ano_original.prova_id,
    prova_ano_original.ano,
    prova_ano_original.modalidade,
    prova_ano_original.etapa_eja
   FROM prova_ano_original;