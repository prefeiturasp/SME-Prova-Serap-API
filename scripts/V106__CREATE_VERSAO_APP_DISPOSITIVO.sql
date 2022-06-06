CREATE TABLE if not exists public.versao_app_dispositivo (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	codigo_versao int8 not null,
	descricao_versao varchar(100) not null,
	dispositivo_imei varchar(100) not null,
	atualizado_em timestamp not null,
	criado_em timestamp NOT null,
	CONSTRAINT versao_app_dispositivo_pk PRIMARY KEY (id)
);