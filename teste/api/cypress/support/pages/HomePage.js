/**
 * Page Object - Tela inicial (Home) do SERAp
 */
class HomePage {
  cabecalho() {
    return cy.contains('SERAp')
  }

  saudacaoUsuario() {
    return cy.contains('Bem-vindo,')
  }

  linkManual() {
    return cy.contains('Manual')
  }

  linkSistemas() {
    return cy.contains('Sistemas')
  }

  botaoSair(options = {}) {
    return cy.contains('Sair', { timeout: 15000, ...options })
  }

  tituloBoasVindas() {
    return cy.contains(/Bem-vindo ao SERAp/i)
  }

  cardsEmDestaque() {
    return cy.contains(/em destaque/i)
  }

  sair() {
    this.botaoSair().click()
    return this
  }
}

export default new HomePage()
