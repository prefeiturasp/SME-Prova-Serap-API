# language: pt

Funcionalidade: API - Questão completa do ID da prova e legado
  Como um cliente autenticado da API
  Quero consultar a questão completa utilizando o ID da prova e o ID legado da questão
  Para validar o retorno correto das informações da prova

  Contexto:
    Dado que possuo um token de acesso válido

  Cenário: Retorna a questão completa com ID da prova e legado
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: ID da prova inválido
    Quando envio uma requisição GET para questão com ID da prova inválido
    Então retorna status 204 que não contém prova com ID

  Cenário: ID da questão legado inválido
    Quando envio uma requisição GET com ID da questão legado inválido
    Então retorna status 204 que não contém questão com ID

  Cenário: ID da prova é obrigatório
    Quando envio uma requisição GET para questão sem ID da prova
    Então retorna status 404 que ID prova não foi enviado

  Cenário: ID da questão legado é obrigatório
    Quando envio uma requisição GET sem ID da questão legado
    Então retorna status 404 que ID da questão não foi enviado

  Cenário: Não retorna questão completa sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET para a questão completa
    Então retorna o status 401 sem acesso aos dados legado da questão

  Cenário: Validar consistência do retorno da questão completa
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: Validar integridade dos dados retornados da questão
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: Validar estabilidade da API em consultas consecutivas válidas
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: Validar tempo de resposta da consulta da questão completa
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: Validar que o endpoint retorna content-type corretamente
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: Validar que a API não retorna erro inesperado para IDs válidos
    Quando envio uma requisição GET para questão com ID da prova
    E ID questão legado
    Então retorna status 200 ou 204 com dados da questão completa

  Cenário: Validar padronização da resposta para ID da prova inválido
    Quando envio uma requisição GET para questão com ID da prova inválido
    Então retorna status 204 que não contém prova com ID

  Cenário: Validar consistência da resposta para ID legado inválido
    Quando envio uma requisição GET com ID da questão legado inválido
    Então retorna status 204 que não contém questão com ID

  Cenário: Validar que a API não retorna sucesso sem ID da prova
    Quando envio uma requisição GET para questão sem ID da prova
    Então retorna status 404 que ID prova não foi enviado

  Cenário: Validar que a API não retorna sucesso sem ID da questão legado
    Quando envio uma requisição GET sem ID da questão legado
    Então retorna status 404 que ID da questão não foi enviado

  Cenário: Validar estabilidade da API para consultas com ID inválido
    Quando envio uma requisição GET para questão com ID da prova inválido
    Então retorna status 204 que não contém prova com ID

  Cenário: Validar estabilidade da API para ausência do ID legado
    Quando envio uma requisição GET sem ID da questão legado
    Então retorna status 404 que ID da questão não foi enviado

  Cenário: Validar que usuários não autenticados não acessam dados da questão
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET para a questão completa
    Então retorna o status 401 sem acesso aos dados legado da questão

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET para a questão completa
    Então retorna o status 401 sem acesso aos dados legado da questão

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET para a questão completa
    Então retorna o status 401 sem acesso aos dados legado da questão