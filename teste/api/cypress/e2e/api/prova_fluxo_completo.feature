# language: pt

Funcionalidade: API - Execução de prova TAI
  Como um estudante autenticado
  Quero executar o fluxo completo da prova TAI
  Para garantir que todas as etapas da aplicação funcionem corretamente

  Contexto:
    Dado que possuo credenciais válidas para prova TAI

  Cenário: Realizar autenticação com sucesso na API de prova TAI
    Quando realizo login na API de prova TAI
    Então o login deve retornar status válido
    E o retorno do login deve ser válido

  Cenário: Iniciar prova TAI com autenticação válida
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    Então o status da resposta deve ser válido para iniciar prova TAI

  Cenário: Garantir consistência ao iniciar uma prova já iniciada
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    Então o status da resposta deve ser válido para iniciar prova TAI
    Quando inicio a prova TAI
    Então o status da resposta deve ser válido para iniciar prova TAI

  Cenário: Obter questão da prova TAI com sucesso
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida

  Cenário: Obter múltiplas questões sequenciais da prova TAI
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida
    Quando obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida

  Cenário: Responder uma questão da prova TAI com sucesso
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    E respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI

  Cenário: Responder múltiplas questões da prova TAI
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    E respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI
    Quando obtenho uma questão da prova TAI
    E respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI

  Cenário: Consultar resumo da prova TAI após início da execução
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI

  Cenário: Consultar resumo da prova TAI em múltiplas requisições
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI
    Quando consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI

  Cenário: Validar estabilidade da API durante o fluxo completo da prova TAI
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    E respondo a questão da prova TAI
    E consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI

  Cenário: Validar integridade dos dados retornados da questão TAI
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida

  Cenário: Validar consistência das respostas da API em chamadas consecutivas
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    Quando obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI

  Cenário: Validar que o resumo da prova permanece acessível após responder questões
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    E respondo a questão da prova TAI
    E consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI

  Cenário: Validar continuidade da execução da prova após múltiplas respostas
    Quando realizo login na API de prova TAI
    E inicio a prova TAI
    E obtenho uma questão da prova TAI
    E respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI
    Quando obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida