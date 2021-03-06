CREATE OR REPLACE VIEW public.v_questao_aluno_resposta_max_id
AS SELECT max(questao_aluno_resposta.id) AS id,
    questao_aluno_resposta.questao_id,
    questao_aluno_resposta.aluno_ra
   FROM questao_aluno_resposta
  GROUP BY questao_aluno_resposta.questao_id, questao_aluno_resposta.aluno_ra
  ORDER BY (max(questao_aluno_resposta.id)) DESC;