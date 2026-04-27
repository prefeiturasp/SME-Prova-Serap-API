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