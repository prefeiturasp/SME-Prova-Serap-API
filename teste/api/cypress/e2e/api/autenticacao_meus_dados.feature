# language: pt

Funcionalidade: API - Meus dados

  Cenário: Retorna os dados do estudante autenticado
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Não autenticar com senha inválida
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Não retorna dados com token inválido
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Não retorna dados com token expirado
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Garantir que o endpoint responde corretamente com autenticação válida
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar múltiplas requisições com token válido
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar consistência dos dados retornados para usuário autenticado
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar integridade da resposta do endpoint de meus dados
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar que a API responde rapidamente com token válido
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar estabilidade da API em chamadas autenticadas consecutivas
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar que o endpoint não retorna erro inesperado para token válido
    Dado que gerou um token de acesso válido
    Quando que realizo a busca no endpoint de meus dados
    Então retorna status 200 com as informações do estudante

  Cenário: Validar que usuário não autenticado não acessa informações do estudante
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Validar padronização da resposta de erro para token inválido
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Validar consistência da resposta para token expirado
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Validar que a API não retorna dados sensíveis sem autenticação
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante

  Cenário: Validar que o endpoint mantém comportamento consistente para tokens inválidos
    Dado que não possuo um token de acesso válido
    Quando que tento a busca no endpoint de meus dados
    Então retorna status 401 sem as informações do estudante