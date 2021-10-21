create table if not exists public.questao_aluno_resposta
(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY ,
	questao_id int8 not null,
	aluno_ra int8 NOT NULL,
	alternativa_id int8 null,
	resposta varchar null,
	criado_em timestamptz not null,
	CONSTRAINT questao_aluno_resposta_pk PRIMARY KEY (id),
	CONSTRAINT questao_fk FOREIGN KEY (questao_id) REFERENCES public.questao (id)
);

create index if not exists qar_questao_idx ON public.questao_aluno_resposta(questao_id);
create index if not exists qar_aluno_idx ON public.questao_aluno_resposta(aluno_ra);


