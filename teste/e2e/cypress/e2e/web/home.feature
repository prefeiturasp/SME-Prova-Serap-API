# language: pt

Funcionalidade: Web - Tela inicial (Home) do SERAp
  Como um usuário autenticado no SERAp
  Quero visualizar a tela inicial do sistema
  Para acessar as informações e ferramentas disponíveis

  Contexto:
    Dado que estou autenticado no SERAp
@ignore
  Cenário: Exibir cabeçalho com o nome do sistema
    Então devo visualizar o cabeçalho com o nome "SERAp"

@ignore
  Cenário: Exibir saudação de boas-vindas ao usuário autenticado
    Então devo visualizar a saudação de boas-vindas ao usuário
@ignore
  Cenário: Exibir mensagem de boas-vindas ao SERAp na página inicial
    Então devo visualizar o título de boas-vindas ao SERAp
@ignore
  Cenário: Exibir seção de ferramentas em destaque
    Então devo visualizar a seção de ferramentas em destaque
@ignore
  Cenário: Exibir links de manual e sistemas no cabeçalho
    Então devo visualizar o link "Manual" no cabeçalho
    E devo visualizar o link "Sistemas" no cabeçalho
@ignore
  Cenário: Encerrar a sessão através do botão sair
    Quando clico no botão "Sair"
    Então devo ser redirecionado para a página de login
