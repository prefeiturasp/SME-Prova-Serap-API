-- public.boletim_resultado_probabilidade definição
CREATE TABLE IF NOT EXISTS public.boletim_resultado_probabilidade (
	id int8 GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	habilidade_id int8 NOT NULL,	
	codigo_habilidade varchar NOT NULL,
	habilidade_descricao varchar NOT NULL,
	turma_descricao varchar NOT NULL,
	turma_id int8 NOT NULL,
	prova_id int8 NOT NULL,
	ue_id int8 NOT NULL,
	disciplina_id int8 NULL,
	ano_escolar int8 NULL,
	abaixo_do_basico numeric NULL,
	basico numeric NULL,
	adequado numeric NULL,
	avancado numeric NULL,
	data_consolidacao timestamp NULL,
	CONSTRAINT boletim_resultado_probabilidade_unq UNIQUE (habilidade_id, turma_id, prova_id, ue_id)
);

-- public.boletim_resultado_probabilidade chaves estrangeiras
ALTER TABLE public.boletim_resultado_probabilidade 
	ADD CONSTRAINT boletim_resultado_probabilidade_fk_prova FOREIGN KEY (prova_id) REFERENCES public.prova(id);

ALTER TABLE public.boletim_resultado_probabilidade 
	ADD CONSTRAINT boletim_resultado_probabilidade_fk_turma FOREIGN KEY (turma_id) REFERENCES public.turma(id);

ALTER TABLE public.boletim_resultado_probabilidade 
	ADD CONSTRAINT boletim_resultado_probabilidade_fk_ue FOREIGN KEY (ue_id) REFERENCES public.ue(id);