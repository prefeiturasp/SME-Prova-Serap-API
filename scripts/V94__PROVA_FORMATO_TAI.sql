alter table prova add column if not exists formato_tai bool not null default false;
alter table prova add column if not exists formato_tai_item int4 null;