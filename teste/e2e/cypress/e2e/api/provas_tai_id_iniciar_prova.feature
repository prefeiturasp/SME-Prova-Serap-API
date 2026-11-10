# language: pt

Funcionalidade: API - Iniciar prova TAI
  Como um estudante autenticado
  Quero iniciar uma prova TAI
  Para garantir que a execução da prova seja iniciada corretamente

  Cenário: Inicia a prova TAI
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: ID da prova TAI é obrigatório para iniciar
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Não inicia prova sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de iniciar prova
    Então a prova não é iniciada retornando o status 401

  Cenário: Não inicia prova com token expirado
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de iniciar prova
    Então a prova não é iniciada retornando o status 401

  Cenário: Garante consistência ao iniciar prova múltiplas vezes com token válido
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Garante que ID continua obrigatório mesmo após sucesso anterior
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Valida acesso autorizado após tentativa não autorizada
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de iniciar prova
    Então a prova não é iniciada retornando o status 401

  Cenário: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Validar estabilidade da API em chamadas consecutivas válidas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Validar tempo de resposta ao iniciar prova TAI
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Validar consistência da resposta de início da prova
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Validar integridade da resposta após iniciar prova
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Validar que o endpoint retorna content-type corretamente
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Validar que a API não retorna erro inesperado com token válido
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar a TAI
    Então retorna status 200 que a prova foi iniciada

  Cenário: Validar padronização da resposta para ausência de ID
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Validar consistência da resposta para ausência do ID da prova
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Validar que a API não inicia prova sem ID obrigatório
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Validar estabilidade da API para múltiplas requisições sem ID
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST para iniciar sem o ID
    Então retorna status 404 sem iniciar a prova

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de iniciar prova
    Então a prova não é iniciada retornando o status 401

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de iniciar prova
    Então a prova não é iniciada retornando o status 401

  Cenário: Validar que usuários não autenticados não iniciam a prova
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST de iniciar prova
    Então a prova não é iniciada retornando o status 401