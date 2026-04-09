--INSERT Supervisor Escolar (4FF756D4-154A-E211-9B2A-00155D02E716) na grupo_serap_coresso--

INSERT INTO public.grupo_serap_coresso
(
    id_coresso,
    nome,
    criado_em
)
SELECT
    '4FF756D4-154A-E211-9B2A-00155D02E716'::uuid,
    'Supervisor Escolar',
    now()
WHERE NOT EXISTS (
    SELECT 1
    FROM public.grupo_serap_coresso
    WHERE id_coresso = '4FF756D4-154A-E211-9B2A-00155D02E716'::uuid
);