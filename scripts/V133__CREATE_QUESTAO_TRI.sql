CREATE table  if not exists public.questao_tri (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	questao_id int8 NOT NULL,
	discriminacao numeric NOT NULL,
	dificuldade numeric NOT NULL,
	acerto_casual numeric NOT NULL,
	CONSTRAINT questao_tri_pk PRIMARY KEY (id)
);
CREATE INDEX   if not exists questao_tri_questao_id_idx ON public.questao_tri (questao_id);