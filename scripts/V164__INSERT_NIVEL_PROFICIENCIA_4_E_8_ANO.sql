-- Inserir níveis de proficiência para 4º ano

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 1, 'Abaixo do Básico', 150, 4, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 1 AND disciplina_id = 4 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 2, 'Básico', 200, 4, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 2 AND disciplina_id = 4 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 3, 'Adequado', 250, 4, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 3 AND disciplina_id = 4 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 4, 'Avançado', NULL, 4, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 4 AND disciplina_id = 4 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 1, 'Abaixo do Básico', 135, 5, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 1 AND disciplina_id = 5 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 2, 'Básico', 175, 5, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 2 AND disciplina_id = 5 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 3, 'Adequado', 225, 5, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 3 AND disciplina_id = 5 AND ano = 4
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 4, 'Avançado', NULL, 5, 4
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 4 AND disciplina_id = 5 AND ano = 4
);

-- Inserir níveis de proficiência para 8º ano

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 1, 'Abaixo do Básico', 210, 4, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 1 AND disciplina_id = 4 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 2, 'Básico', 275, 4, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 2 AND disciplina_id = 4 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 3, 'Adequado', 325, 4, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 3 AND disciplina_id = 4 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 4, 'Avançado', NULL, 4, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 4 AND disciplina_id = 4 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 1, 'Abaixo do Básico', 185, 5, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 1 AND disciplina_id = 5 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 2, 'Básico', 250, 5, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 2 AND disciplina_id = 5 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 3, 'Adequado', 300, 5, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 3 AND disciplina_id = 5 AND ano = 8
);

INSERT INTO public.nivel_proficiencia (codigo, descricao, valor_referencia, disciplina_id, ano)
SELECT 4, 'Avançado', NULL, 5, 8
WHERE NOT EXISTS (
    SELECT 1 FROM public.nivel_proficiencia
    WHERE codigo = 4 AND disciplina_id = 5 AND ano = 8
);