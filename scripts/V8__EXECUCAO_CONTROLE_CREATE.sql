
CREATE TABLE public.execucao_controle (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	execucao_tipo int4 NOT NULL,
	ultima_execucao timestamp NOT NULL,
	CONSTRAINT execucao_controle_pk PRIMARY KEY (id)
);