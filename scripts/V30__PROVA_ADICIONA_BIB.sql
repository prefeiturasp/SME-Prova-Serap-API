ALTER TABLE  if exists public.prova ADD COLUMN IF NOT EXISTS possui_bib bool not NULL default false;

ALTER TABLE  if exists public.prova ADD COLUMN IF NOT EXISTS total_cadernos int not NULL default 0;