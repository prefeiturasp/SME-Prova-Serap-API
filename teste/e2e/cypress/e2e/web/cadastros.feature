# language: pt

Funcionalidade: Web - Menu Cadastros do SERAp
  Como um usuário autenticado no SERAp
  Quero visualizar as opções disponíveis em Cadastros
  Para acessar os cadastros do sistema

  Contexto:
    Dado que estou autenticado no SERAp

  Cenário: Exibir a opção Componente curricular no menu Cadastros
    Então devo visualizar o menu Cadastros
    E devo visualizar a opção Componente curricular no menu Cadastros
