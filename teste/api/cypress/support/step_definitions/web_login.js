import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps'
import LoginPage from '../pages/LoginPage'
import GrupoAcessoPage from '../pages/GrupoAcessoPage'

// Acessar a página de login
Given('que acesso a página de login do SERAp', () => {
  LoginPage.visitar()
})

// Login com credenciais válidas
When('informo um login e senha válidos', () => {
  LoginPage.preencherLogin(Cypress.env('WEB_LOGIN'))
  LoginPage.preencherSenha(Cypress.env('WEB_SENHA'))
})

// Login válido + senha inválida
When('informo um login válido e uma senha inválida', () => {
  LoginPage.preencherLogin(Cypress.env('WEB_LOGIN'))
  LoginPage.preencherSenha(Cypress.env('WEB_SENHA_INVALIDA'))
})

// Login inválido
When('informo um login inválido e uma senha qualquer', () => {
  LoginPage.preencherLogin(Cypress.env('WEB_LOGIN_INVALIDO'))
  LoginPage.preencherSenha(Cypress.env('WEB_SENHA'))
})

When('clico no botão de entrar', () => {
  LoginPage.botaoEntrar().click()
})

When('clico no botão de entrar sem preencher os campos', () => {
  LoginPage.botaoEntrar().click()
})

When('seleciono o grupo de acesso Administrador', () => {
  GrupoAcessoPage.selecionarAdministrador()
})

Then('devo visualizar a tela inicial com a saudação de boas-vindas', () => {
  cy.contains('Bem-vindo,', { timeout: 15000 }).should('be.visible')
})

Then('devo permanecer na página de login', () => {
  LoginPage.campoLogin().should('be.visible')
  LoginPage.campoSenha().should('be.visible')
})

Then('devo visualizar uma mensagem de erro de autenticação', () => {
  LoginPage.mensagemErro().should('be.visible')
})
