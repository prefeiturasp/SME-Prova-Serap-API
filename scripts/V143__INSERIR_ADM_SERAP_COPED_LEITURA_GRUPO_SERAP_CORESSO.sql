insert into grupo_serap_coresso (id_coresso,nome,criado_em)
select 'A8CB8D7B-F333-E711-9541-782BCB3D218E',	'Adm Serap COPED - Leitura',now()::timestamp
where not exists (select 1 from grupo_serap_coresso where id_coresso = 'A8CB8D7B-F333-E711-9541-782BCB3D218E');