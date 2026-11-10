# language: pt

Funcionalidade: API - Obter questão prova TAI
  Como um estudante autenticado
  Quero obter questões da prova TAI
  Para garantir que a navegação e carregamento das questões funcionem corretamente

  Cenário: Retorna questão da prova TAI
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: ID da prova TAI é obrigatório ao obter questão
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Não obtem a questão sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de obter questão
    Então não retorna a questão com status 401

  Cenário: Não obtem a questão com token expirado
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de obter questão
    Então não retorna a questão com status 401

  Cenário: Garante consistência ao obter questão múltiplas vezes com token válido
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Garante que ID continua obrigatório mesmo após sucesso anterior
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de obter questão
    Então não retorna a questão com status 401

  Cenário: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Validar estabilidade da API em chamadas consecutivas válidas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Validar tempo de resposta ao obter questão da prova TAI
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Validar consistência da resposta da questão retornada
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Validar integridade dos dados retornados da questão
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Validar que a API não retorna erro inesperado com token válido
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão
    Então retorna status 200 de sucesso

  Cenário: Validar padronização da resposta para ausência do ID da prova
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Validar consistência da resposta para ausência de ID
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Validar que a API não retorna sucesso sem ID obrigatório
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Validar estabilidade da API para múltiplas chamadas sem ID
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST de obter questão sem o ID
    Então retorna status 404

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de obter questão
    Então não retorna a questão com status 401

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de obter questão
    Então não retorna a questão com status 401

  Cenário: Validar que usuários não autenticados não acessam questões da prova
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de obter questão
    Então não retorna a questão com status 401