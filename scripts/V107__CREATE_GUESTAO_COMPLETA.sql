CREATE TABLE public.questao_completa (
	id int8 NOT NULL,
	"json" text NOT NULL,
	ultima_atualizacao timestamp NOT NULL,
	CONSTRAINT questao_completa_pk PRIMARY KEY (id)
);