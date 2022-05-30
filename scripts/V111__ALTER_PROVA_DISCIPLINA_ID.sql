alter table public.prova add column if not exists disciplina_id int8;

alter table public.aluno_prova_proficiencia add column if not exists ultima_atualizacao timestamp;

UPDATE public.execucao_controle SET ultima_execucao = '2020-05-29 18:31:49.009' WHERE execucao_tipo=1;