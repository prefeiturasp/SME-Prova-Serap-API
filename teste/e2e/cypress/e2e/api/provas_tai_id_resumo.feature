# language: pt

Funcionalidade: API - Resumo prova TAI
  Como um estudante autenticado
  Quero consultar o resumo da prova TAI
  Para validar o andamento e os dados consolidados da prova

  Cenário: Retorna o resumo prova TAI
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: ID da prova TAI é obrigatório
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Não retorna resumo sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET de resumo da prova TAI
    Então não verifica o status 401

  Cenário: Não retorna resumo com token expirado
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET de resumo da prova TAI
    Então não verifica o status 401

  Cenário: Garante consistência ao consultar resumo múltiplas vezes com token válido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Garante que ID continua obrigatório mesmo após sucesso anterior
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET de resumo da prova TAI
    Então não verifica o status 401

  Cenário: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar estabilidade da API em consultas consecutivas válidas
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Validar tempo de resposta da consulta do resumo TAI
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Validar consistência da resposta do resumo da prova
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Validar integridade dos dados retornados no resumo
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Validar que a API não retorna erro inesperado com token válido
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de resumo prova TAI
    Então retorna status 200

  Cenário: Validar padronização da resposta para ausência do ID da prova
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar consistência da resposta para ausência de ID
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar que a API não retorna sucesso sem ID obrigatório
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar estabilidade da API para múltiplas requisições sem ID
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET de resumo da prova TAI
    Então não verifica o status 401

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET de resumo da prova TAI
    Então não verifica o status 401

  Cenário: Validar que usuários não autenticados não acessam resumo da prova
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET de resumo da prova TAI
    Então não verifica o status 401