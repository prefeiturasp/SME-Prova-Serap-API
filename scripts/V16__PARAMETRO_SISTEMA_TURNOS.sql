insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoManhaIntegral','Início da prova no turno da manhã/integral','7','2021',now(),1
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 1 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoTarde','Início da prova no turno da tarde','13','2021',now(),2
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 2 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoNoite','Início da prova no turno da noite','19','2021',now(),3
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 3 and ano = '2021' );