# language: pt

Funcionalidade: API - Contextos da prova

  Cenário: Retorna contexto da prova com sucesso
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: ID do contexto é obrigatório
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Não retorna contexto sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Não retorna contexto com token inválido
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Garante consistência ao consultar múltiplas vezes
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Garante que ID continua obrigatório após sucesso
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Garante que chamadas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Validar integridade dos dados retornados do contexto
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Validar estabilidade da API em chamadas consecutivas válidas
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Validar tempo de resposta da consulta de contexto
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Validar que a API não retorna erro inesperado com token válido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Validar padronização da resposta para ausência de ID
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Validar consistência da resposta para contexto sem ID
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Validar que a API não retorna sucesso sem ID do contexto
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Validar estabilidade da API para chamadas sem ID
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Validar que usuários não autenticados não acessam contexto da prova
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Validar que a API mantém padrão de erro para token inválido
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401