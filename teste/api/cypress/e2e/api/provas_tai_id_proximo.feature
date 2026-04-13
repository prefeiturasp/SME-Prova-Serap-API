Feature: API - Próxima questão prova TAI

  Scenario: ID da prova TAI é obrigatório na próxima questão
    Given que possuo um token de acesso valido
    When envio uma requisição POST da próxima sem o ID
    Then retorna status 404 sem a questão

  Scenario: Não obtem a próxima questão sem autenticação
    Given que não possuo um token de acesso valido
    When tento a requisição POST da próxima
    Then não retorna a questão somente 401

  Scenario: Não obtem a próxima questão com token expirado
    Given que não possuo um token de acesso valido
    When tento a requisição POST da próxima
    Then não retorna a questão somente 401

  Scenario: Garante que ID continua obrigatório mesmo após tentativa anterior
    Given que possuo um token de acesso valido
    When envio uma requisição POST da próxima sem o ID
    Then retorna status 404 sem a questão

  Scenario: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Given que não possuo um token de acesso valido
    When tento a requisição POST da próxima
    Then não retorna a questão somente 401

  Scenario: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Given que possuo um token de acesso valido
    When envio uma requisição POST da próxima sem o ID
    Then retorna status 404 sem a questão