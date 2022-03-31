drop view IF EXISTS v_abrangencia_usuario_grupo;
create view v_abrangencia_usuario_grupo as
select a.id, a.usuario_id, usc.login, usc.nome as usuario, a.grupo_id, gsc.id_coresso, gsc.nome as grupo, a.dre_id, a.ue_id, a.turma_id 
from abrangencia a
join usuario_serap_coresso usc on usc.id = a.usuario_id
join grupo_serap_coresso gsc on gsc.id = a.grupo_id;

ALTER TABLE public.abrangencia DROP CONSTRAINT IF EXISTS abrangencia_grupo_fk;
ALTER TABLE public.abrangencia add constraint  abrangencia_grupo_fk FOREIGN KEY (grupo_id) REFERENCES grupo_serap_coresso(id);