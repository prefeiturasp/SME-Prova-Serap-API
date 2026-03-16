Feature: Consultar arquivo por ID
  Como cliente da API SERAp
  Quero consultar um arquivo pelo seu ID
  Para validar que os dados da prova estão corretos

  Background:
    Given que possuo um token de autenticação válido

  Scenario: Consultar arquivo existente da prova
    When eu consulto o arquivo com o ID 10
    Then o status da resposta deve ser 200
    And o corpo da resposta deve conter o arquivo com os dados esperados

  Scenario: Consultar arquivo inexistente
    When eu consulto o arquivo com o ID 1099998798
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Scenario: Consultar arquivo com ID muito alto
    When eu consulto o arquivo com o ID 999999999
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Scenario: Consultar arquivo com ID zero
    When eu consulto o arquivo com o ID 0
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Scenario: Consultar arquivo com ID negativo
    When eu consulto o arquivo com o ID -1
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"