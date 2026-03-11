--INSERT Supervisão Escolar (66c70452-1a1e-e811-b259-782bcb3d2d76) na grupo_serap_coresso--

INSERT INTO public.grupo_serap_coresso
(
    id_coresso,
    nome,
    criado_em
)
SELECT
    '66c70452-1a1e-e811-b259-782bcb3d2d76'::uuid,
    'Supervisão Escolar',
    now()
WHERE NOT EXISTS (
    SELECT 1
    FROM public.grupo_serap_coresso
    WHERE id_coresso = '66c70452-1a1e-e811-b259-782bcb3d2d76'::uuid
);