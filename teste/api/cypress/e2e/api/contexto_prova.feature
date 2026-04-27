# language: pt

Funcionalidade: API - Contextos da prova

  Cenário: Retorna contexto da prova com sucesso
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: ID do contexto é obrigatório
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Não retorna contexto sem autenticação
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Não retorna contexto com token inválido
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401

  Cenário: Garante consistência ao consultar múltiplas vezes
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Garante que ID continua obrigatório após sucesso
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET sem o ID do contexto
    Então retorna status 404

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso válido
    Quando envio uma requisição GET de contexto da prova
    Então retorna status 200 com os dados do contexto

  Cenário: Garante que chamadas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso válido
    Quando tento a requisição GET de contexto da prova
    Então retorna status 401