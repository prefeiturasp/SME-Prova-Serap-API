DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM pg_indexes
        WHERE schemaname = 'public'
          AND tablename = 'boletim_escolar'
          AND indexname = 'ux_boletim_escolar_chave_negocio'
    ) THEN
        CREATE UNIQUE INDEX ux_boletim_escolar_chave_negocio
            ON public.boletim_escolar (ue_id, prova_id, disciplina_id, componente_curricular)
            NULLS NOT DISTINCT;
        RAISE NOTICE 'Índice único ux_boletim_escolar_chave_negocio criado com sucesso.';
    ELSE
        RAISE NOTICE 'Índice único ux_boletim_escolar_chave_negocio já existe. Pulando criação.';
    END IF;
END $$;