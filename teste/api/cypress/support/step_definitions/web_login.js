import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps'
import LoginPage from '../pages/LoginPage'

Given('que acesso a página de login do SERAp', () => {
  LoginPage.visitar()
})

When('informo um usuário e senha válidos', () => {
  LoginPage.preencherUsuario(Cypress.env('WEB_LOGIN'))
  LoginPage.preencherSenha(Cypress.env('WEB_SENHA'))
})

When('informo um usuário válido e uma senha inválida', () => {
  LoginPage.preencherUsuario(Cypress.env('WEB_LOGIN'))
  LoginPage.preencherSenha(Cypress.env('WEB_SENHA_INVALIDA'))
})

When('informo um usuário inválido e uma senha qualquer', () => {
  LoginPage.preencherUsuario(Cypress.env('WEB_LOGIN_INVALIDO'))
  LoginPage.preencherSenha(Cypress.env('WEB_SENHA'))
})

When('clico no botão de entrar', () => {
  LoginPage.botaoEntrar().click()
})

When('clico no botão de entrar sem preencher os campos', () => {
  LoginPage.botaoEntrar().click()
})

Then('devo permanecer na página de login', () => {
  LoginPage.campoUsuario().should('be.visible')
  LoginPage.campoSenha().should('be.visible')
  cy.url().should('include', '/account/login')
})
