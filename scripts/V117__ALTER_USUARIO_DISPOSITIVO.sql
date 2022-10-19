alter table usuario_dispositivo drop column IF EXISTS ano;
alter table usuario_dispositivo ADD COLUMN IF NOT EXISTS turma_id int8;
CREATE index IF NOT EXISTS usuario_dispositivo_turma_idx ON public.usuario_dispositivo USING btree (turma_id);
