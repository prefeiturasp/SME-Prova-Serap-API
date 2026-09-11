# language: pt

Funcionalidade: Web - Login no SERAp
  Como um usuário do sistema SERAp
  Quero acessar a tela de login da Prefeitura de São Paulo
  Para autenticar e utilizar o sistema

  Cenário: Não permitir login com senha inválida
    Dado que acesso a página de login do SERAp
    Quando informo um usuário válido e uma senha inválida
    E clico no botão de entrar
    Então devo permanecer na página de login

  Cenário: Não permitir login com usuário inválido
    Dado que acesso a página de login do SERAp
    Quando informo um usuário inválido e uma senha qualquer
    E clico no botão de entrar
    Então devo permanecer na página de login

  Cenário: Não permitir login sem informar usuário e senha
    Dado que acesso a página de login do SERAp
    Quando clico no botão de entrar sem preencher os campos
    Então devo permanecer na página de login
