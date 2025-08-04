-- Remove a função existente, se houver, para recriá-la com a nova estrutura.
DROP FUNCTION IF EXISTS obter_proficiencia_dre(integer, bigint);

-- Cria ou substitui a função 'obter_proficiencia_dre'.
CREATE OR REPLACE FUNCTION obter_proficiencia_dre(p_ano_escolar integer, p_lote_id bigint)
RETURNS TABLE (
    -- Adicionando a nova coluna DreId ao tipo de retorno
    DreId bigint,
    DreNome text,
    AnoEscolar integer,
    TotalUes bigint,
    TotalAlunos bigint,
    TotalRealizaramProva bigint,
    PercentualParticipacao numeric,
    Disciplina text,
    MediaProficiencia numeric,
    NivelProficiencia text
) AS $$
BEGIN
    RETURN QUERY
    WITH ues_dres AS (
        SELECT
            d.id AS dre_id,
            d.nome AS dre_nome,
            blu.ano_escolar,
            blu.lote_id,
            blu.ue_id,
            blu.total_alunos,
            blu.realizaram_prova
        FROM boletim_lote_ue blu
        INNER JOIN dre d ON d.id = blu.dre_id
        -- A cláusula WHERE permanece com os filtros originais
        WHERE blu.lote_id = p_lote_id
          AND blu.ano_escolar = p_ano_escolar
    ),
    provas AS (
        SELECT
            blp.lote_id,
            blp.prova_id,
            pao.ano
        FROM boletim_lote_prova blp
        INNER JOIN prova_ano_original pao ON pao.prova_id = blp.prova_id
        WHERE blp.lote_id = p_lote_id
          AND pao.ano = p_ano_escolar::varchar
    ),
    proficiencias AS (
        SELECT
            bpa.dre_id,
            bpa.ue_codigo,
            bpa.prova_id,
            bpa.disciplina_id,
            bpa.disciplina,
            bpa.ano_escolar,
            bpa.proficiencia
        FROM boletim_prova_aluno bpa
        WHERE bpa.ano_escolar = p_ano_escolar
    ),
    resumo_dre AS (
        SELECT
            ud.dre_id,
            ud.dre_nome::text,
            ud.ano_escolar,
            COUNT(DISTINCT ud.ue_id) AS total_ues,
            SUM(ud.total_alunos) AS total_alunos,
            SUM(ud.realizaram_prova) AS total_realizaram_prova
        FROM ues_dres ud
        GROUP BY ud.dre_id, ud.dre_nome, ud.ano_escolar
    ),
    media_proficiencia AS (
        SELECT
            d.id AS dre_id,
            bpa.ano_escolar,
            bpa.disciplina_id,
            bpa.disciplina,
            ROUND(AVG(bpa.proficiencia), 2) AS media_proficiencia
        FROM proficiencias bpa
        INNER JOIN dre d ON d.id = bpa.dre_id
        GROUP BY d.id, bpa.ano_escolar, bpa.disciplina_id, bpa.disciplina
    ),
    proficiency_levels_with_bounds AS (
        SELECT
            np.disciplina_id,
            np.ano,
            np.descricao,
            COALESCE(LAG(np.valor_referencia) OVER (PARTITION BY np.disciplina_id, np.ano ORDER BY np.valor_referencia ASC NULLS FIRST), 0) + 1 AS lower_bound,
            np.valor_referencia AS upper_bound
        FROM nivel_proficiencia np
        WHERE np.valor_referencia IS NOT NULL
        UNION ALL
        SELECT
            np.disciplina_id,
            np.ano,
            np.descricao,
            (SELECT MAX(valor_referencia) FROM nivel_proficiencia WHERE disciplina_id = np.disciplina_id AND ano = np.ano AND valor_referencia IS NOT NULL) + 1 AS lower_bound,
            NULL AS upper_bound
        FROM nivel_proficiencia np
        WHERE np.descricao = 'Avançado' AND np.valor_referencia IS NULL
    ),
    nivel_proficiencia_match AS (
        SELECT
            mp.dre_id,
            mp.ano_escolar,
            mp.disciplina_id,
            mp.disciplina,
            mp.media_proficiencia,
            plwb.descricao AS nivel_proficiencia
        FROM media_proficiencia mp
        LEFT JOIN proficiency_levels_with_bounds plwb
            ON mp.disciplina_id = plwb.disciplina_id
            AND mp.ano_escolar = plwb.ano
            AND mp.media_proficiencia >= plwb.lower_bound
            AND (plwb.upper_bound IS NULL OR mp.media_proficiencia <= plwb.upper_bound)
    )
    SELECT
        r.dre_id AS DreId,
        r.dre_nome AS DreNome,
        r.ano_escolar AS AnoEscolar,
        r.total_ues AS TotalUes,
        r.total_alunos AS TotalAlunos,
        r.total_realizaram_prova AS TotalRealizaramProva,
        ROUND(100.0 * r.total_realizaram_prova / NULLIF(r.total_alunos, 0), 2) AS PercentualParticipacao,
        nmp.disciplina AS Disciplina,
        nmp.media_proficiencia AS MediaProficiencia,
        nmp.nivel_proficiencia AS NivelProficiencia
    FROM resumo_dre r
    LEFT JOIN nivel_proficiencia_match nmp ON nmp.dre_id = r.dre_id AND nmp.ano_escolar = r.ano_escolar
    ORDER BY r.dre_nome, nmp.disciplina;
END;
$$ LANGUAGE plpgsql;