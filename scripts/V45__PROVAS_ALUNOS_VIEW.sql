drop view if exists v_provas_alunos;

CREATE VIEW v_provas_alunos  as
    select distinct * from prova_aluno