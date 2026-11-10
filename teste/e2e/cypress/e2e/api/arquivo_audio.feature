Feature: Consultar arquivo de áudio da prova
  Como cliente da API SERAp
  Quero consultar o áudio da prova
  Para validar que o arquivo está correto

  Background:
    Given que possuo um token de autenticação válido

  Scenario: Consultar vídeo inexistente
    When eu consulto o vídeo com o ID 999999
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Consultar vídeo com ID inválido
    When eu consulto o vídeo com o ID -1
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Consultar vídeo com ID zero
    When eu consulto o vídeo com o ID 0
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Consultar vídeo com ID muito alto
    When eu consulto o vídeo com o ID 88888888
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar consistência da resposta para vídeo inexistente
    When eu consulto o vídeo com o ID 999999
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar estabilidade da API em consultas inválidas consecutivas
    When eu consulto o vídeo com o ID -1
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar padronização da mensagem de erro para ID zero
    When eu consulto o vídeo com o ID 0
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar retorno da API para IDs inexistentes extremos
    When eu consulto o vídeo com o ID 88888888
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar que a API não retorna status 200 para vídeo inexistente
    When eu consulto o vídeo com o ID 999999
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar integridade da resposta de erro para ID inválido
    When eu consulto o vídeo com o ID -1
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar comportamento consistente da API para ID zero
    When eu consulto o vídeo com o ID 0
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar tempo de resposta para consulta inválida
    When eu consulto o vídeo com o ID 88888888
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar que a API retorna corpo de resposta em erro
    When eu consulto o vídeo com o ID 999999
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"

  Scenario: Validar que o endpoint mantém padrão de erro para múltiplos IDs inválidos
    When eu consulto o vídeo com o ID -1
    Then o status da resposta deve ser 409
    And o corpo da resposta deve conter a mensagem "O vídeo não foi encontrado"