alter table public.prova add column if not exists disciplina_id int8;

alter table public.aluno_prova_proficiencia add column if not exists ultima_atualizacao timestamp;