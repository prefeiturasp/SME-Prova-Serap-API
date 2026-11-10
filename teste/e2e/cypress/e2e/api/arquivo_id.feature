# language: pt

Funcionalidade: Consultar arquivo por ID
  Como cliente da API SERAp
  Quero consultar um arquivo pelo seu ID
  Para validar que os dados da prova estão corretos

  Contexto:
    Dado que possuo um token de autenticação válido

  Cenário: Consultar arquivo existente da prova
    Quando eu consulto o arquivo com o ID 10
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter o arquivo com os dados esperados

  Cenário: Consultar arquivo inexistente
    Quando eu consulto o arquivo com o ID 1099998798
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Consultar arquivo com ID muito alto
    Quando eu consulto o arquivo com o ID 999999999
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Consultar arquivo com ID zero
    Quando eu consulto o arquivo com o ID 0
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Consultar arquivo com ID negativo
    Quando eu consulto o arquivo com o ID -1
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar consistência da resposta para arquivo existente
    Quando eu consulto o arquivo com o ID 10
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter o arquivo com os dados esperados

  Cenário: Validar integridade dos dados retornados do arquivo
    Quando eu consulto o arquivo com o ID 10
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter o arquivo com os dados esperados

  Cenário: Validar estabilidade da API em múltiplas consultas válidas
    Quando eu consulto o arquivo com o ID 10
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter o arquivo com os dados esperados

  Cenário: Validar que a API responde rapidamente para arquivo existente
    Quando eu consulto o arquivo com o ID 10
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter o arquivo com os dados esperados

  Cenário: Validar que o endpoint retorna content-type corretamente para arquivo válido
    Quando eu consulto o arquivo com o ID 10
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter o arquivo com os dados esperados

  Cenário: Validar padronização da resposta para arquivo inexistente
    Quando eu consulto o arquivo com o ID 1099998798
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar consistência da mensagem de erro para ID muito alto
    Quando eu consulto o arquivo com o ID 999999999
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar comportamento da API para ID zero
    Quando eu consulto o arquivo com o ID 0
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar comportamento da API para ID negativo
    Quando eu consulto o arquivo com o ID -1
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar estabilidade da API para múltiplas consultas inválidas
    Quando eu consulto o arquivo com o ID 1099998798
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar que a API não retorna status de sucesso para arquivos inexistentes
    Quando eu consulto o arquivo com o ID 999999999
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar que a API mantém padrão de erro para IDs inválidos
    Quando eu consulto o arquivo com o ID -1
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"

  Cenário: Validar que a resposta de erro contém corpo válido
    Quando eu consulto o arquivo com o ID 0
    Então o status da resposta deve ser 409
    E o corpo da resposta deve conter a mensagem "O Arquivo não foi encontrado"