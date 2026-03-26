Feature: Consultar configuração de data e hora
  Como um cliente da API
  Quero consultar a configuração de data e hora
  Para obter os valores retornados corretamente

  Background:
    Given que possuo um token de autenticação válido

  Scenario: Consulta bem-sucedida da configuração de data e hora
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Scenario: Validar que os campos obrigatórios estão presentes
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Scenario: Validar que os valores retornados não são nulos
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Scenario: Validar consistência dos dados de data e hora
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Scenario: Validar formato do campo dataHora
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Scenario: Validar resposta em múltiplas requisições consecutivas
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Scenario: Validar estabilidade da resposta ao longo do tempo
    When eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter os campos "dataHora" e "tolerancia"