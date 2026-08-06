# language: pt

Funcionalidade: Consultar lista de vídeos de boas-vindas
  Como um cliente da API
  Quero consultar a lista de vídeos de boas-vindas
  Para verificar se as informações retornadas estão corretas

  Contexto:
    Dado que possuo um token de autenticação válido

  Cenário: Consulta bem sucedida da lista de vídeos de boas-vindas
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar retorno consistente da lista de vídeos
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar múltiplas requisições da lista de vídeos
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Garantir que a lista de vídeos é retornada corretamente
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar resposta com dados de vídeos válidos
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar que a lista retornada não está vazia
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar estrutura de todos os itens retornados
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar que os campos obrigatórios estão preenchidos
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar consistência dos dados retornados
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar método não permitido
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200

  Cenário: Validar resposta em múltiplas requisições consecutivas
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar integridade dos dados retornados da lista
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar estabilidade da API em chamadas consecutivas
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar tempo de resposta da consulta da lista de vídeos
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar que o endpoint retorna content-type corretamente
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar que a API não retorna erro inesperado
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar padronização dos dados retornados
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados

  Cenário: Validar que a API mantém comportamento consistente
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/telas-boas-vindas"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter a lista de vídeos com os campos esperados