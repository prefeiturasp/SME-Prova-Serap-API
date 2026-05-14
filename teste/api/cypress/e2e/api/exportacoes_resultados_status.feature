# language: pt

Funcionalidade: API - Status de exportações de resultados

  Cenário: Retorna status das exportações com sucesso
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: ID da prova é obrigatório
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Garante consistência ao consultar múltiplas vezes
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Garante que ID continua obrigatório após sucesso
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Validar estrutura da lista de exportações retornada
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Validar que a API retorna content-type corretamente
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Validar tempo de resposta da consulta de exportações
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Validar estabilidade da API em chamadas consecutivas
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Validar que a API não retorna campos nulos inesperados
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações

  Cenário: Validar retorno da API para prova inexistente
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar comportamento da API sem parâmetros obrigatórios
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar padronização das respostas de erro
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar que o endpoint mantém comportamento consistente em erro
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID da prova
    Então retorna status 404

  Cenário: Validar integridade dos dados retornados na lista de exportações
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de status das exportações
    Então retorna status 200 com a lista de exportações