alter table turma add if not exists semestre int4 null;
alter table turma add if not exists etapa_eja int4 null;
alter table turma add if not exists serie_ensino varchar(40) null;