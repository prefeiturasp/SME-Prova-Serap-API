ALTER TABLE  if exists public.questao ADD COLUMN IF NOT EXISTS quantidade_alternativas int not NULL default 0;

update questao set quantidade_alternativas = 4 where tipo = 1;
update questao set quantidade_alternativas = 5 where tipo = 2;

update questao set tipo = 1 where tipo = 2;
update questao set tipo = 2 where tipo = 3;