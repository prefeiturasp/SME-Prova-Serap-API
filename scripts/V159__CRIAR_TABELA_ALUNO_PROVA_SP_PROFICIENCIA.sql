create table if not exists aluno_prova_sp_proficiencia (
    id BIGSERIAL primary key,
    aluno_ra int8 not null,
	ano_letivo int4 not null,
    ano_escolar int4 not null,
	disciplina_id int8 not null,
	proficiencia numeric not null,
    data_atualizacao timestamp default now() not null
);