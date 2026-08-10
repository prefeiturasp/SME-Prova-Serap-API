# language: pt

Funcionalidade: Web - Login no SERAp
  Como um usuário do sistema SERAp
  Quero acessar a tela de login
  Para autenticar e utilizar o sistema

  Cenário: Realizar login com sucesso utilizando credenciais válidas
    Dado que acesso a página de login do SERAp
    Quando informo um login e senha válidos
    E clico no botão de entrar
    E seleciono o grupo de acesso Administrador
    Então devo visualizar a tela inicial com a saudação de boas-vindas

  Cenário: Não permitir login com senha inválida
    Dado que acesso a página de login do SERAp
    Quando informo um login válido e uma senha inválida
    E clico no botão de entrar
    Então devo permanecer na página de login
    E devo visualizar uma mensagem de erro de autenticação

  Cenário: Não permitir login com usuário inválido
    Dado que acesso a página de login do SERAp
    Quando informo um login inválido e uma senha qualquer
    E clico no botão de entrar
    Então devo permanecer na página de login
    E devo visualizar uma mensagem de erro de autenticação

  Cenário: Não permitir login sem informar usuário e senha
    Dado que acesso a página de login do SERAp
    Quando clico no botão de entrar sem preencher os campos
    Então devo permanecer na página de login
