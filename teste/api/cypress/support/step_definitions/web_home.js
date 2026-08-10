import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps'
import HomePage from '../pages/HomePage'
import MenuPage from '../pages/MenuPage'
import LoginPage from '../pages/LoginPage'

Given('que estou autenticado no SERAp', () => {
  cy.loginWeb()
})

Then('devo visualizar o cabeçalho com o nome {string}', (nome) => {
  HomePage.cabecalho().should('be.visible').and('contain.text', nome)
})

Then('devo visualizar a saudação de boas-vindas ao usuário', () => {
  HomePage.saudacaoUsuario().should('be.visible')
})

Then('devo visualizar o título de boas-vindas ao SERAp', () => {
  HomePage.tituloBoasVindas().should('be.visible')
})

Then('devo visualizar a seção de páginas em destaque', () => {
  HomePage.cardsEmDestaque().should('be.visible')
})

Then('devo visualizar o link {string} no cabeçalho', (texto) => {
  cy.contains(texto, { timeout: 15000 }).should('be.visible')
})

const botoesCabecalho = {
  Menu: () => MenuPage.botaoMenu(),
  Sair: () => HomePage.botaoSair(),
}

When('clico no botão {string}', (texto) => {
  const localizarBotao = botoesCabecalho[texto] || (() => cy.contains(texto, { timeout: 15000 }))
  localizarBotao().click()
})

Then('devo ser redirecionado para a página de login', () => {
  LoginPage.campoLogin().should('be.visible')
  LoginPage.campoSenha().should('be.visible')
})
