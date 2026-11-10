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

  botaoMenu() {
    return cy.contains('MENU', { matchCase: false, timeout: 15000 })
  }

  abrirMenu() {
    this.botaoMenu().click()
    return this
  }

  menuCadastros() {
    return cy.contains('Cadastros', { timeout: 15000 })
  }

  abrirMenuCadastros() {
    this.menuCadastros().click()
    return this
  }

  opcaoComponenteCurricular() {
    return cy.contains('Componente curricular', { timeout: 15000 })
  }

  sair() {
    this.botaoSair().click()
    return this
  }
}

export default new HomePage()
