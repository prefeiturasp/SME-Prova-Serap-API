CREATE table if not exists public.questao_video (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	questao_id int8 NOT NULL,
	arquivo_video_id int8 NOT NULL,
	arquivo_thumbnail_id int8 NULL,
	arquivo_video_convertido_id int8 NULL,
	criado_em timestamptz NOT NULL,
	atualizado_em timestamptz NOT NULL
);