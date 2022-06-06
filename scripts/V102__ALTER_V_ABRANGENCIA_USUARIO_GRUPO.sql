CREATE OR REPLACE VIEW public.v_abrangencia_usuario_grupo
AS SELECT a.id,
    a.usuario_id,
    usc.login,
    usc.nome AS usuario,
    a.grupo_id,
    gsc.id_coresso,
    gsc.nome AS grupo,
    a.dre_id,
    a.ue_id,
    a.turma_id,
    a.inicio,
    a.fim 
FROM abrangencia a
LEFT JOIN usuario_serap_coresso usc ON usc.id = a.usuario_id
LEFT JOIN grupo_serap_coresso gsc ON gsc.id = a.grupo_id;