Feature: API - Obter questão prova TAI

  Scenario: Retorna questão da prova TAI
    Given que possuo um token de acesso valido
    When envio uma requisição POST de obter questão
    Then retorna status 200 de sucesso

  Scenario: ID da prova TAI é obrigatório ao obter questão
    Given que possuo um token de acesso valido
    When envio uma requisição POST de obter questão sem o ID
    Then retorna status 404

  Scenario: Não obtem a questão sem autenticação
    Given que não possuo um token de acesso valido
    When tento a requisição POST de obter questão
    Then não retorna a questão com status 401


  Scenario: Não obtem a questão com token expirado
    Given que não possuo um token de acesso valido
    When tento a requisição POST de obter questão
    Then não retorna a questão com status 401

  Scenario: Garante consistência ao obter questão múltiplas vezes com token válido
    Given que possuo um token de acesso valido
    When envio uma requisição POST de obter questão
    Then retorna status 200 de sucesso

  Scenario: Garante que ID continua obrigatório mesmo após sucesso anterior
    Given que possuo um token de acesso valido
    When envio uma requisição POST de obter questão sem o ID
    Then retorna status 404

  Scenario: Valida acesso autorizado após tentativa não autorizada
    Given que possuo um token de acesso valido
    When envio uma requisição POST de obter questão
    Then retorna status 200 de sucesso

  Scenario: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Given que não possuo um token de acesso valido
    When tento a requisição POST de obter questão
    Then não retorna a questão com status 401

  Scenario: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Given que possuo um token de acesso valido
    When envio uma requisição POST de obter questão sem o ID
    Then retorna status 404