# language: pt

Funcionalidade: API - Revalidar a autenticação

  Cenário: Revalidar a autenticação com sucesso
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Token deve ser obrigatório
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Não revalidar autenticação com dados inválidos
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Não revalidar autenticação sem credenciais
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Garantir revalidação com credenciais válidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar múltiplas revalidações consecutivas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar consistência da resposta ao revalidar autenticação
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar integridade do token retornado
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar que a API responde rapidamente para autenticação válida
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar estabilidade da API em múltiplas autenticações válidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar que o endpoint não retorna erro inesperado com credenciais válidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados de acesso
    Então retorna status 200 com o token válido

  Cenário: Validar padronização da resposta para login ausente
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar consistência da resposta para credenciais inválidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar que a API não autentica usuário sem login
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar estabilidade da API para múltiplas tentativas inválidas
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar que o endpoint mantém padrão de erro sem credenciais
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido

  Cenário: Validar que a resposta de erro contém corpo válido
    Dado que acesso o endpoint de autenticação
    Quando envio os dados sem o login
    Então retorna status 422 que acesso foi inválido