create table  if not exists public.versao_app (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
    codigo_versao int8 NOT NULL,
    descricao_versao varchar(100),
    mensagem  varchar(100) ,
	criado_em timestamp NOT NULL,
	alterado_em timestamp,
	suporte_minimo int8,
	url varchar(1000),
	CONSTRAINT versao_app_pk PRIMARY KEY (id)
);


INSERT into  public.versao_app
(codigo_versao, descricao_versao, mensagem, criado_em, alterado_em, suporte_minimo, url)
VALUES(3, '1.0.0', 'Atualização de versão', current_date, null, 2, 'url.com.teste');