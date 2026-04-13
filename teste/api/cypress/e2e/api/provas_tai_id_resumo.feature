Feature: API - Resumo prova TAI

  Scenario: Retorna o resumo prova TAI
    Given que possuo um token de acesso válido
    When envio uma requisição GET de resumo prova TAI
    Then retorna status 200 

  Scenario: ID da prova TAI é obrigatório
    Given que possuo um token de acesso válido
    When envio uma requisição GET sem o ID da prova
    Then retorna status 404 

  Scenario: Não retorna resumo sem autenticação
    Given que não possuo um token de acesso valido
    When tento a requisição GET de resumo da prova TAI
    Then não verifica o status 401

  Scenario: Não retorna resumo com token expirado
    Given que não possuo um token de acesso valido
    When tento a requisição GET de resumo da prova TAI
    Then não verifica o status 401

  Scenario: Garante consistência ao consultar resumo múltiplas vezes com token válido
    Given que possuo um token de acesso válido
    When envio uma requisição GET de resumo prova TAI
    Then retorna status 200 

  Scenario: Garante que ID continua obrigatório mesmo após sucesso anterior
    Given que possuo um token de acesso válido
    When envio uma requisição GET sem o ID da prova
    Then retorna status 404 

  Scenario: Valida acesso autorizado após tentativa não autorizada
    Given que possuo um token de acesso válido
    When envio uma requisição GET de resumo prova TAI
    Then retorna status 200 

  Scenario: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Given que não possuo um token de acesso valido
    When tento a requisição GET de resumo da prova TAI
    Then não verifica o status 401

  Scenario: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Given que possuo um token de acesso válido
    When envio uma requisição GET sem o ID da prova
    Then retorna status 404 