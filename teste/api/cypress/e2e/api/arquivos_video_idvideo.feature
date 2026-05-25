# language: pt

Funcionalidade: Consultar vídeo por ID
  Como um cliente da API
  Quero consultar um vídeo pelo seu ID
  Para obter as informações cadastradas ou uma mensagem de erro adequada

  Contexto:
    Dado que possuo um token de autenticação válido

  Cenário: Consultar vídeo existente
    Quando eu consulto o vídeo com o ID 123456
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Consultar vídeo inexistente
    Quando eu consulto o vídeo com um ID inexistente
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Consultar outro vídeo existente
    Quando eu consulto o vídeo com o ID 123457
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Consultar vídeo com ID muito alto
    Quando eu consulto o vídeo com o ID 999999999
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Consultar vídeo com ID zero
    Quando eu consulto o vídeo com o ID 0
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Consultar vídeo com ID negativo
    Quando eu consulto o vídeo com o ID -1
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar consistência da resposta para vídeo existente
    Quando eu consulto o vídeo com o ID 123456
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Validar integridade dos dados retornados do vídeo
    Quando eu consulto o vídeo com o ID 123457
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Validar estabilidade da API em múltiplas consultas válidas
    Quando eu consulto o vídeo com o ID 123456
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Validar tempo de resposta para vídeo existente
    Quando eu consulto o vídeo com o ID 123457
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Validar que o endpoint retorna content-type corretamente
    Quando eu consulto o vídeo com o ID 123456
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Validar que a API não retorna erro inesperado para vídeos válidos
    Quando eu consulto o vídeo com o ID 123457
    Então o status da resposta deve ser 200
    E o corpo da resposta do vídeo deve conter os campos esperados

  Cenário: Validar padronização da resposta para vídeo inexistente
    Quando eu consulto o vídeo com um ID inexistente
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar consistência da mensagem de erro para ID muito alto
    Quando eu consulto o vídeo com o ID 999999999
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar comportamento da API para ID zero
    Quando eu consulto o vídeo com o ID 0
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar comportamento da API para ID negativo
    Quando eu consulto o vídeo com o ID -1
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar estabilidade da API para múltiplas consultas inválidas
    Quando eu consulto o vídeo com um ID inexistente
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar que a API não retorna status de sucesso para vídeos inexistentes
    Quando eu consulto o vídeo com o ID 999999999
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar que a API mantém padrão de erro para IDs inválidos
    Quando eu consulto o vídeo com o ID -1
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado

  Cenário: Validar que a resposta de erro contém corpo válido
    Quando eu consulto o vídeo com o ID 0
    Então o status da resposta deve ser 409
    E a resposta deve indicar que o vídeo não foi encontrado