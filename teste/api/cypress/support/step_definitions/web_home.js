import { Given, When, Then } from 'cypress-cucumber-preprocessor/steps'
import HomePage from '../pages/HomePage'

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

Then('devo visualizar a seção de ferramentas em destaque', () => {
  HomePage.ferramentasEmDestaque().should('be.visible')
})

Then('devo visualizar o link {string} no cabeçalho', (texto) => {
  cy.contains(texto, { timeout: 15000 }).should('be.visible')
})

When('clico no botão {string}', (texto) => {
  cy.contains(texto, { timeout: 15000 }).click()
})

Then('devo ser redirecionado para a página de login', () => {
  cy.url({ timeout: 15000 }).should('not.include', 'hom-serap.sme.prefeitura.sp.gov.br')
})
