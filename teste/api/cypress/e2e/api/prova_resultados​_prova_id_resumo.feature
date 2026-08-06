# language: pt

Funcionalidade: API - Resumo de resultados do ID da prova
  Como um cliente autenticado da API
  Quero consultar o resumo de resultados através do ID da prova
  Para validar o retorno correto das informações de resultado

  Cenário: Retorna o resumo de resultados através do ID da prova
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: ID da prova inválido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID inválido
    Então retorna status 409 sem resumo dos resultados

  Cenário: ID da prova é obrigatório
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404 sem resumo dos resultados

  Cenário: Não retorna resumo de resultados sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de resumo de resultados
    Então retorna verifica o status 401 sem acesso aos resultados

  Cenário: Não retorna dados com token expirado
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de resumo de resultados
    Então retorna verifica o status 401 sem acesso aos resultados

  Cenário: Garante consistência ao consultar múltiplas vezes com ID válido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Garante que ID inválido continua retornando erro em chamadas repetidas
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID inválido
    Então retorna status 409 sem resumo dos resultados

  Cenário: Garante que ausência de ID continua retornando erro após sucesso anterior
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404 sem resumo dos resultados

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Validar integridade dos dados retornados no resumo
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Validar estabilidade da API em chamadas consecutivas válidas
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Validar tempo de resposta da consulta de resumo
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Validar que a API não retorna erro inesperado para ID válido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID da prova
    Então retorna status 200 com resumo dos resultados

  Cenário: Validar padronização da resposta para ID inválido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID inválido
    Então retorna status 409 sem resumo dos resultados

  Cenário: Validar consistência da resposta para ausência do ID da prova
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404 sem resumo dos resultados

  Cenário: Validar que a API não retorna sucesso para ID inválido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID inválido
    Então retorna status 409 sem resumo dos resultados

  Cenário: Validar estabilidade da API para múltiplas consultas com ID inválido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET com ID inválido
    Então retorna status 409 sem resumo dos resultados

  Cenário: Validar que a API não retorna sucesso sem ID da prova
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404 sem resumo dos resultados

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de resumo de resultados
    Então retorna verifica o status 401 sem acesso aos resultados

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de resumo de resultados
    Então retorna verifica o status 401 sem acesso aos resultados

  Cenário: Validar que usuários não autenticados não acessam resultados
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de resumo de resultados
    Então retorna verifica o status 401 sem acesso aos resultados