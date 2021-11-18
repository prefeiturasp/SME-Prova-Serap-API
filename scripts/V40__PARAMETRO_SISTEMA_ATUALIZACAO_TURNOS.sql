delete from parametro_sistema where tipo in (1,2,3,6,7,8);


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoManha','Início da prova no turno da manhã','06','2021',now(),1
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
	'InicioProvaTurnoIntermediario','Início da prova no turno intermediário','9','2021',now(),2
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
	'InicioProvaTurnoTarde','Início da prova no turno da Tarde','12','2021',now(),3
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 3 and ano = '2021' );

insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoManha','Fim da prova no turno da manhã','14','2021',now(),6
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
	'FimProvaTurnoIntermediario','Fim da prova no turno intermediario','17','2021',now(),7
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
	'FimProvaTurnoTarde','Fim da prova no turno tarde','20','2021',now(),8
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 8 and ano = '2021' );



----------------------------

insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoVespertino','Início da prova no turno vespertino','15','2021',now(),9
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 9 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoNoite','Início da prova no turno noite','18','2021',now(),10
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 10 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'InicioProvaTurnoIntegral','Início da prova no turno integral','6','2021',now(),11
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 11 and ano = '2021' );

insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoVespertino','Fim da prova no turno vespertino','22','2021',now(),12
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 12 and ano = '2021' );


insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoNoite','Fim da prova no turno noite','23','2021',now(),13
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 13 and ano = '2021' );



insert 
    into 
    public.parametro_sistema (nome,descricao,valor,ano,criado_em,tipo)
select
	'FimProvaTurnoIntegral','Fim da prova no turno integral','23','2021',now(),14
where
	not exists(
	select
		1
	from
		public.parametro_sistema
	where
		tipo = 14 and ano = '2021' );