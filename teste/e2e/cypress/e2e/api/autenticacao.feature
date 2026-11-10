# language: pt

Funcionalidade: API - Autenticação

  Cenário: Realiza a autenticação com sucesso
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Login deve ser obrigatório
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Senha deve ser obrigatória
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem a senha
    Então retorna status 422 que é necessário ser informada

  Cenário: Não autenticar com senha inválida
    Dado que acesso o endpoint de autenticação
    Quando envio os dados com senha inválida
    Então retorna status 412 retorna a mensagem que está incorreta

  Cenário: Não autenticar sem login e senha
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Garantir autenticação com dados válidos
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar múltiplas autenticações consecutivas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Não autenticar com credenciais inválidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados com senha inválida
    Então retorna status 412 retorna a mensagem que está incorreta

  Cenário: Validar consistência da autenticação com credenciais válidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar integridade do token retornado na autenticação
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar tempo de resposta da autenticação válida
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar estabilidade da API em autenticações consecutivas válidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar que a API não retorna erro inesperado com dados válidos
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar padronização da resposta para login ausente
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar consistência da resposta para senha ausente
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem a senha
    Então retorna status 422 que é necessário ser informada

  Cenário: Validar que a API não autentica sem login
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar que a API não autentica sem senha
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem a senha
    Então retorna status 422 que é necessário ser informada

  Cenário: Validar estabilidade da API para múltiplas tentativas inválidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados com senha inválida
    Então retorna status 412 retorna a mensagem que está incorreta

  Cenário: Validar que o endpoint mantém padrão de erro para senha inválida
    Dado que acesso o endpoint de autenticação
    Quando envio os dados com senha inválida
    Então retorna status 412 retorna a mensagem que está incorreta

  Cenário: Validar que a resposta de erro contém corpo válido
    Dado que acesso o endpoint de autenticação
    Quando envio os dados com senha inválida
    Então retorna status 412 retorna a mensagem que está incorreta