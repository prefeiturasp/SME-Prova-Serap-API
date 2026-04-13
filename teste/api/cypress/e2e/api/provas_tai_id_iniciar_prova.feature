Feature: API - Iniciar prova TAI

  Scenario: Inicia a prova TAI
    Given que possuo um token de acesso valido
    When envio uma requisição POST para iniciar a TAI
    Then retorna status 200 que a prova foi iniciada

  Scenario: ID da prova TAI é obrigatório para iniciar
    Given que possuo um token de acesso valido
    When envio uma requisição POST para iniciar sem o ID
    Then retorna status 404 sem iniciar a prova

  Scenario: Não inicia prova sem autenticação
    Given que não possuo um token de acesso valido
    When tento a requisição POST de iniciar prova
    Then a prova não é iniciada retornando o status 401

  Scenario: Não inicia prova com token expirado
    Given que não possuo um token de acesso valido
    When tento a requisição POST de iniciar prova
    Then a prova não é iniciada retornando o status 401

  Scenario: Garante consistência ao iniciar prova múltiplas vezes com token válido
    Given que possuo um token de acesso valido
    When envio uma requisição POST para iniciar a TAI
    Then retorna status 200 que a prova foi iniciada

  Scenario: Garante que ID continua obrigatório mesmo após sucesso anterior
    Given que possuo um token de acesso valido
    When envio uma requisição POST para iniciar sem o ID
    Then retorna status 404 sem iniciar a prova

  Scenario: Valida acesso autorizado após tentativa não autorizada
    Given que possuo um token de acesso valido
    When envio uma requisição POST para iniciar a TAI
    Then retorna status 200 que a prova foi iniciada

  Scenario: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Given que não possuo um token de acesso valido
    When tento a requisição POST de iniciar prova
    Then a prova não é iniciada retornando o status 401

  Scenario: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Given que possuo um token de acesso valido
    When envio uma requisição POST para iniciar sem o ID
    Then retorna status 404 sem iniciar a prova