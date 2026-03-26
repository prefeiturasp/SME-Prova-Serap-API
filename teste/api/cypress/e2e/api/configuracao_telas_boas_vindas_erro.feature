Feature: Consultar lista de vídeos de boas-vindas  
  Como um cliente da API  
  Quero consultar a lista de vídeos de boas-vindas  
  Para verificar se as informações retornadas estão corretas  

  Background:  
    Given que possuo um token de autenticação válido  

  Scenario: Consulta bem sucedida da lista de vídeos de boas-vindas  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  
    And o corpo da resposta deve conter a lista de vídeos com os campos esperados  
    And um dos itens deve falhar a validação de "imagem"  

  Scenario: Validar que a lista retornada não está vazia  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  
    And o corpo da resposta deve conter a lista de vídeos com os campos esperados  

  Scenario: Validar estrutura de todos os itens retornados  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  
    And o corpo da resposta deve conter a lista de vídeos com os campos esperados  

  Scenario: Validar que os campos obrigatórios estão preenchidos  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  
    And o corpo da resposta deve conter a lista de vídeos com os campos esperados  

  Scenario: Validar consistência dos dados retornados  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  
    And o corpo da resposta deve conter a lista de vídeos com os campos esperados  

  Scenario: Validar método não permitido  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  

  Scenario: Validar resposta em múltiplas requisições consecutivas  
    When eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"  
    Then o status da resposta deve ser 200  
    And o corpo da resposta deve conter a lista de vídeos com os campos esperados  