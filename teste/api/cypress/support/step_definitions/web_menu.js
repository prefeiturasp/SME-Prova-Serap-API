import { When, Then } from 'cypress-cucumber-preprocessor/steps'
import MenuPage from '../pages/MenuPage'

Then('devo visualizar as opções do menu de navegação', () => {
  MenuPage.itens().forEach((item) => {
    MenuPage.item(item).should('be.visible')
  })
})

Then('devo visualizar a opção de menu {string}', (nome) => {
  MenuPage.item(nome).should('be.visible')
})

When('seleciono a opção de menu {string}', (nome) => {
  MenuPage.selecionarItem(nome)
})

Then('devo ser redirecionado para a página {string}', (nome) => {
  cy.location('pathname', { timeout: 15000 }).should('match', new RegExp(nome, 'i'))
})
