Feature: Consultar vídeo existente
  Como um cliente da API
  Quero consultar um vídeo pelo seu ID
  Para obter as informações cadastradas

  Background:
    Given que possuo um token de autenticação válido

  Scenario: Consultar vídeo existente
    When eu consulto o vídeo com o ID 123456
    Then o status da resposta deve ser 200
    And o corpo da resposta do vídeo deve conter os campos esperados

  Scenario: Consultar vídeo inexistente
    When eu consulto o vídeo com o ID 999999
    Then o status da resposta deve ser 409

  Scenario: Consultar vídeo existente com outro ID válido
    When eu consulto o vídeo com o ID 123457
    Then o status da resposta deve ser 200
    And o corpo da resposta do vídeo deve conter os campos esperados

  Scenario: Consultar vídeo com ID muito alto inexistente
    When eu consulto o vídeo com o ID 88888888
    Then o status da resposta deve ser 409

  Scenario: Consultar vídeo com ID negativo
    When eu consulto o vídeo com o ID -1
    Then o status da resposta deve ser 409

  Scenario: Consultar vídeo com ID zero
    When eu consulto o vídeo com o ID 0
    Then o status da resposta deve ser 409