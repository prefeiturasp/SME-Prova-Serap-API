/**
 * Page Object - Menu lateral do SERAp
 */
class MenuPage {
  botaoMenu(options = {}) {
    return cy.contains('Menu', { timeout: 15000, ...options })
  }

  abrir() {
    this.botaoMenu().click()
    return this
  }

  itens() {
    return [
      'Cadastros',
      'Itens',
      'Provas',
      'Arquivos',
      'Resultados',
      'Relatórios',
      'Parâmetros',
      'Auditoria'
    ]
  }

  item(nome) {
    return cy.get('.menuLateral', { timeout: 15000 }).contains(nome)
  }

  selecionarItem(nome) {
    this.item(nome).click()
    return this
  }
}

export default new MenuPage()
