ALTER TABLE public.tipo_deficiencia ADD if not exists prova_normal bool NULL;
UPDATE public.tipo_deficiencia SET prova_normal = false;
UPDATE public.tipo_deficiencia SET prova_normal = true WHERE id NOT IN (3,4,7,8,9);
ALTER TABLE public.tipo_deficiencia ALTER COLUMN prova_normal SET NOT NULL;