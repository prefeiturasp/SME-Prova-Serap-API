# language: pt

Funcionalidade: API - Imagem Log

  Cenário: Enviar log de imagem com sucesso
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar que a API não permite acesso sem autorização válida
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar consistência da resposta de erro da API
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar que a API responde rapidamente mesmo com erro
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar que o content-type da resposta é retornado corretamente
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar estrutura mínima obrigatória da resposta de erro
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar que a API mantém o padrão de resposta para múltiplas requisições
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar que a mensagem de erro não retorna dados sensíveis
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar que a API retorna corpo de resposta mesmo em falha de autenticação
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log

  Cenário: Validar estabilidade da API ao repetir requisições inválidas
    Dado que possuo acesso à API de imagem log
    Quando envio uma requisição POST para registrar imagem log
    Então o status da resposta deve ser 401
    E o retorno deve ser válido para imagem log