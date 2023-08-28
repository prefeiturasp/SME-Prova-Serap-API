ALTER TABLE aluno_prova_proficiencia ADD COLUMN IF NOT exists erro_medida numeric NULL;

UPDATE aluno_prova_proficiencia
SET erro_medida = 0;

ALTER TABLE aluno_prova_proficiencia ALTER COLUMN erro_medida SET NOT NULL;