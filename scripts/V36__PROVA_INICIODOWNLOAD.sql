ALTER TABLE  if exists public.prova ADD COLUMN IF NOT EXISTS inicio_download timestamp without time zone null;
update prova set inicio_download = inicio where inicio_download is null;