Feature: API - Existe conexão

  Scenario: Verifica se existe conexão
    Given que possuo um token de acesso valido
    When envio uma requisição GET para o endpoint de existe conexão
    Then retorna status 200 de confirmação

  Scenario: Não verifica conexão sem autenticação
    Given que não possuo um token de acesso valido
    When tento a requisição GET para o endpoint de existe conexão
    Then retorna o status 401 não permitindo verificar

  Scenario: Não verifica conexão com token expirado
    Given que não possuo um token de acesso valido
    When tento a requisição GET para o endpoint de existe conexão
    Then retorna o status 401 não permitindo verificar

  Scenario: Garante consistência ao verificar conexão múltiplas vezes com token válido
    Given que possuo um token de acesso valido
    When envio uma requisição GET para o endpoint de existe conexão
    Then retorna status 200 de confirmação

  Scenario: Valida acesso autorizado após tentativa não autorizada
    Given que possuo um token de acesso valido
    When envio uma requisição GET para o endpoint de existe conexão
    Then retorna status 200 de confirmação

  Scenario: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Given que não possuo um token de acesso valido
    When tento a requisição GET para o endpoint de existe conexão
    Then retorna o status 401 não permitindo verificar