insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'TempoAlertaProva','Tempo de alerta que a prova está finalizando, em segundos','300','2021',now(),5
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 5 and ano = '2021' );