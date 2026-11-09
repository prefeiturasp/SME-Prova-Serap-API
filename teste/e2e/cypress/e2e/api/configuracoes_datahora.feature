# language: pt

Funcionalidade: Consultar configuração de data e hora
  Como um cliente da API
  Quero consultar a configuração de data e hora
  Para obter os valores retornados corretamente

  Contexto:
    Dado que possuo um token de autenticação válido

  Cenário: Consulta bem-sucedida da configuração de data e hora
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar que os campos obrigatórios estão presentes
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar que os valores retornados não são nulos
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar consistência dos dados de data e hora
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar formato do campo dataHora
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar resposta em múltiplas requisições consecutivas
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar estabilidade da resposta ao longo do tempo
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar integridade dos dados retornados
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar tempo de resposta da consulta de data e hora
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar estabilidade da API em chamadas consecutivas
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar que o endpoint retorna content-type corretamente
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar que a API não retorna erro inesperado
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar padronização dos dados retornados
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar consistência do campo tolerancia
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar que o campo dataHora permanece no padrão esperado
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"

  Cenário: Validar comportamento consistente da API em consultas repetidas
    Quando eu faço uma requisição GET para "/api/v1/configuracoes/datahora"
    Então o status da resposta deve ser 200
    E o corpo da resposta deve conter os campos "dataHora" e "tolerancia"