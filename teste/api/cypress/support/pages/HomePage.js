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

  botaoSair() {
    return cy.contains('Sair')
  }

  tituloBoasVindas() {
    return cy.contains('Bem-vindo ao SERAp')
  }

  ferramentasEmDestaque() {
    return cy.contains('Ferramentas em destaque')
  }

  sair() {
    this.botaoSair().click()
    return this
  }
}

export default new HomePage()
