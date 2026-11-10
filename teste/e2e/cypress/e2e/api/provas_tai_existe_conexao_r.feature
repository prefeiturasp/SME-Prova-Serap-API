# language: pt

Funcionalidade: API - Existe conexão
  Como um cliente da API
  Quero verificar se existe conexão com o serviço
  Para garantir que o endpoint esteja acessível e respondendo corretamente

  Cenário: Verifica se existe conexão
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Não verifica conexão sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Não verifica conexão com token expirado
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Garante consistência ao verificar conexão múltiplas vezes com token válido
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Validar estabilidade da API em chamadas consecutivas válidas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar tempo de resposta do endpoint de conexão
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar consistência da resposta positiva da API
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar integridade da resposta de confirmação
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar que a API não retorna erro inesperado com token válido
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Validar que usuários não autenticados não acessam o endpoint
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Validar padronização da resposta de erro para token inválido
    Dado que não possuo um token de acesso valido
    Quando tento a requisição GET para o endpoint de existe conexão
    Então retorna o status 401 não permitindo verificar

  Cenário: Validar que a API mantém comportamento consistente após falhas de autenticação
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação

  Cenário: Validar continuidade das respostas positivas após múltiplas consultas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição GET para o endpoint de existe conexão
    Então retorna status 200 de confirmação