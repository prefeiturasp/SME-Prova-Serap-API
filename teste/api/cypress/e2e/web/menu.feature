# language: pt

Funcionalidade: Web - Menu de navegação do SERAp
  Como um usuário autenticado no SERAp
  Quero utilizar o menu lateral
  Para navegar entre as funcionalidades do sistema

  Contexto:
    Dado que estou autenticado no SERAp

  Cenário: Exibir o menu ao clicar no botão Menu
    Quando clico no botão "Menu"
    Então devo visualizar as opções do menu de navegação

  Cenário: Exibir a opção Cadastros no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Cadastros"

  Cenário: Exibir a opção Itens no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Itens"

  Cenário: Exibir a opção Provas no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Provas"

  Cenário: Exibir a opção Arquivos no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Arquivos"

  Cenário: Exibir a opção Resultados no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Resultados"

  Cenário: Exibir a opção Relatórios no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Relatórios"

  Cenário: Exibir a opção Parâmetros no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Parâmetros"

  Cenário: Exibir a opção Auditoria no menu
    Quando clico no botão "Menu"
    Então devo visualizar a opção de menu "Auditoria"

  Cenário: Navegar para a tela de Consultar Provas através do menu
    Quando clico no botão "Menu"
    E seleciono a opção de menu "Provas"
    E seleciono a opção de menu "Consultar provas"
    Então devo ser redirecionado para a página "Test"
    
