create table if not exists public.configuracao_tela_boas_vindas
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	titulo varchar(120) null,
	descricao varchar null,
    imagem varchar null,
    ordem int null,
    ativo bool default false,
	CONSTRAINT configuracao_tela_boas_vindas_pk PRIMARY KEY (id)
);

insert into configuracao_tela_boas_vindas(titulo, descricao, imagem, ordem, ativo) values ('primeira tela', 
    'descricao da primeira tela', 
    'https://www.vacaria.rs.gov.br/fotos/20190321_163419_escola-duque.jpg', 1, true);