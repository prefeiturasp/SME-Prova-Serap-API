alter table prova add if not exists prova_com_proficiencia bool default false;
alter table prova add if not exists apresentar_resultados bool default false;
alter table prova add if not exists apresentar_resultados_por_item bool default false;