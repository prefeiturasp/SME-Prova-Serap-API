# language: pt

Funcionalidade: API - Próxima questão prova TAI
  Como um estudante autenticado
  Quero solicitar a próxima questão da prova TAI
  Para garantir a continuidade correta da execução da prova

  Cenário: ID da prova TAI é obrigatório na próxima questão
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Não obtem a próxima questão sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Não obtem a próxima questão com token expirado
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Garante que ID continua obrigatório mesmo após tentativa anterior
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Garante que chamadas repetidas sem autenticação continuam bloqueadas
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Garante que ausência de ID sempre retorna erro em chamadas repetidas
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Validar consistência da resposta para ausência do ID da prova
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Validar padronização da resposta para requisição sem ID
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Validar que a API não retorna sucesso sem ID obrigatório
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Validar estabilidade da API em múltiplas chamadas sem ID
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Validar que o endpoint responde corretamente para ausência de parâmetros obrigatórios
    Dado que possuo um token de acesso valido
    Quando envio uma requisição POST da próxima sem o ID
    Então retorna status 404 sem a questão

  Cenário: Validar consistência da resposta sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Validar estabilidade da API para múltiplas tentativas sem autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Validar que usuários não autenticados não acessam próxima questão
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Validar padronização da resposta para token inválido
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Validar que a API mantém comportamento consistente após falha de autenticação
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401

  Cenário: Validar que a resposta de erro permanece estável em chamadas consecutivas
    Dado que não possuo um token de acesso valido
    Quando tento a requisição POST da próxima
    Então não retorna a questão somente 401