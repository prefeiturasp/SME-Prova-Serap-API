insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoManhaIntegral','Fim da prova no turno da manhã/integral','17','2021',now(),6
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 6 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoTarde','Fim da prova no turno da tarde','18','2021',now(),7
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 7 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoNoite','Fim da prova no turno da noite','0','2021',now(),8
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 8 and ano = '2021' );