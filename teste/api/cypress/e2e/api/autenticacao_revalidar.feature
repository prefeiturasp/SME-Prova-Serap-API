Feature: API - Revalidar a autenticação

  Scenario: Revalidar a autenticação com sucesso
    Given que acesso o endpoint de autenticação
    When envio os dados de acesso
    Then retorna status 200 com o token válido

  Scenario: Token deve ser obrigatório
    Given que acesso o endpoint de autenticação
    When envio os dados sem o login
    Then retorna status 422 que acesso foi inválido

  Scenario: Não revalidar autenticação com dados inválidos
    Given que acesso o endpoint de autenticação
    When envio os dados sem o login
    Then retorna status 422 que acesso foi inválido

  Scenario: Não revalidar autenticação sem credenciais
    Given que acesso o endpoint de autenticação
    When envio os dados sem o login
    Then retorna status 422 que acesso foi inválido

  Scenario: Garantir revalidação com credenciais válidas
    Given que acesso o endpoint de autenticação
    When envio os dados de acesso
    Then retorna status 200 com o token válido

  Scenario: Validar múltiplas revalidações consecutivas
    Given que acesso o endpoint de autenticação
    When envio os dados de acesso
    Then retorna status 200 com o token válido