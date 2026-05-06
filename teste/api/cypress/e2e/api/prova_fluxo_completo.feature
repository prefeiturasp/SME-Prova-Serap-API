# language: pt

Funcionalidade: API - Execução de prova TAI

  Cenário: Login válido na API de prova TAI
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Então o login deve retornar status válido
    E o retorno do login deve ser válido

  Cenário: Iniciar prova TAI com sucesso
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Então o status da resposta deve ser válido para iniciar prova TAI

  Cenário: Tentar iniciar prova já iniciada
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Então o status da resposta deve ser válido para iniciar prova TAI
    Quando inicio a prova TAI
    Então o status da resposta deve ser válido para iniciar prova TAI

  Cenário: Obter questões da prova TAI
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Quando obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida

  Cenário: Obter múltiplas questões da prova TAI
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Quando obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida
    Quando obtenho uma questão da prova TAI
    Então o status da resposta deve ser válido para questão TAI
    E a questão da prova TAI deve ser válida

  Cenário: Responder questão da prova TAI
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Quando obtenho uma questão da prova TAI
    Quando respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI

  Cenário: Responder múltiplas questões da prova TAI
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Quando obtenho uma questão da prova TAI
    Quando respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI
    Quando obtenho uma questão da prova TAI
    Quando respondo a questão da prova TAI
    Então o status da resposta deve ser válido para resposta TAI

  Cenário: Consultar resumo da prova TAI
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Quando consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI

  Cenário: Consultar resumo da prova TAI múltiplas vezes
    Dado que possuo credenciais válidas para prova TAI
    Quando realizo login na API de prova TAI
    Quando inicio a prova TAI
    Quando consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI
    Quando consulto o resumo da prova TAI
    Então o status da resposta deve ser válido para resumo TAI