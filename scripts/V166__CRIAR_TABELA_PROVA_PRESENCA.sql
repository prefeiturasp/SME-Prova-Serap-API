DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_tables WHERE schemaname = 'public' AND tablename = 'prova_presenca') THEN
        CREATE TABLE public.prova_presenca (
            id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
            nome_prova VARCHAR(255) NOT NULL,
            ano_prova INTEGER NOT NULL,
            descricao_prova TEXT,
            data_inicial_aplicacao DATE NOT NULL,
            data_final_aplicacao DATE NOT NULL,
            data_corte DATE,
            vincula_aluno_caderno_extra BOOLEAN DEFAULT FALSE,
            data_processamento TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
            CONSTRAINT prova_presenca_pk PRIMARY KEY (id)
        );
        RAISE NOTICE 'Tabela public.prova_presenca criada com sucesso.';
    ELSE
        RAISE NOTICE 'Tabela public.prova_presenca já existe. Pulando criação.';
    END IF;

    IF NOT EXISTS (SELECT 1 FROM pg_tables WHERE schemaname = 'public' AND tablename = 'prova_presenca_turmas') THEN
        CREATE TABLE public.prova_presenca_turmas (
            prova_presenca_id int8 NOT NULL,
            turma_id int8 NOT NULL,
            CONSTRAINT prova_presenca_turmas_pk PRIMARY KEY (prova_presenca_id, turma_id)
        );
        RAISE NOTICE 'Tabela public.prova_presenca_turmas criada com sucesso.';
    ELSE
        RAISE NOTICE 'Tabela public.prova_presenca_turmas já existe. Pulando criação.';
    END IF;

    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'fk_prova_presenca' AND conrelid = 'public.prova_presenca_turmas'::regclass) THEN
        ALTER TABLE public.prova_presenca_turmas
        ADD CONSTRAINT fk_prova_presenca FOREIGN KEY (prova_presenca_id) REFERENCES public.prova_presenca(id) ON DELETE CASCADE;
        RAISE NOTICE 'Chave estrangeira fk_prova_presenca adicionada.';
    ELSE
        RAISE NOTICE 'Chave estrangeira fk_prova_presenca já existe. Pulando adição.';
    END IF;

    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'fk_turma' AND conrelid = 'public.prova_presenca_turmas'::regclass) THEN
        ALTER TABLE public.prova_presenca_turmas
        ADD CONSTRAINT fk_turma FOREIGN KEY (turma_id) REFERENCES public.turma(id) ON DELETE CASCADE;
        RAISE NOTICE 'Chave estrangeira fk_turma adicionada.';
    ELSE
        RAISE NOTICE 'Chave estrangeira fk_turma já existe. Pulando adição.';
    END IF;

    IF NOT EXISTS (
        SELECT 1 FROM pg_indexes
        WHERE schemaname = 'public'
          AND tablename = 'prova_presenca'
          AND indexname = 'ux_prova_presenca_nome_ano'
    ) THEN
        CREATE UNIQUE INDEX ux_prova_presenca_nome_ano
            ON public.prova_presenca (LOWER(TRIM(nome_prova)), ano_prova);
        RAISE NOTICE 'Índice único ux_prova_presenca_nome_ano criado com sucesso.';
    ELSE
        RAISE NOTICE 'Índice único ux_prova_presenca_nome_ano já existe. Pulando criação.';
    END IF;

END $$;