/**
 * Page Object - Tela de Login (SSO Prefeitura de São Paulo / SME Educação)
 */
class LoginPage {
  visitar() {
    cy.visit(Cypress.env('WEB_BASE_URL'))
    return this
  }

  campoUsuario() {
    return cy.get('#Username')
  }

  campoSenha() {
    return cy.get('#Password')
  }

  botaoEntrar() {
    return cy.get('input[type="submit"]')
  }

  preencherUsuario(usuario) {
    this.campoUsuario().clear().type(usuario)
    return this
  }

  preencherSenha(senha) {
    this.campoSenha().clear().type(senha, { log: false })
    return this
  }

  efetuarLogin(usuario, senha) {
    this.preencherUsuario(usuario)
    this.preencherSenha(senha)
    this.botaoEntrar().click()
    return this
  }
}

export default new LoginPage()
