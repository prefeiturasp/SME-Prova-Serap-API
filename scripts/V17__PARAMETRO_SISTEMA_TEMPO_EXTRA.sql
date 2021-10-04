insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'TempoExtraProva','Tempo extra para a prova, em segundos','600','2021',now(),4
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 4 and ano = '2021' );